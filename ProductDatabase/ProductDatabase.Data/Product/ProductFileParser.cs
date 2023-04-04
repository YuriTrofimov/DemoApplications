// Copyright (c) 2023 Yuri Trofimov.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Data;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ProductDatabase.Data.Product
{
    /// <summary>
    /// Product import file parser
    /// </summary>
    public class ProductFileParser
    {
        /// <summary>
        /// Parse source *.xlsx file and retrieve list of products
        /// </summary>
        /// <param name="filePath">Source *.xlsx file path</param>
        /// <param name="skipFirstRow">True if first row is caption (Column captions)</param>
        /// <returns>Products to import DataTable</returns>
        /// <exception cref="ArgumentException">Columns count in source file and in product table are mismatch</exception>
        public DataTable ParseFromXLSX(string filePath, bool skipFirstRow = true)
        {
            var products = InitProductDataTable();
            using (var spreadsheetDocument = SpreadsheetDocument.Open(filePath, false))
            {
                var workbookPart = spreadsheetDocument.WorkbookPart;
                var worksheetPart = workbookPart.WorksheetParts.First();
                var sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
                var stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();

                bool firstRow = true;
                int rowIndex = 0;
                foreach (Row r in sheetData.Elements<Row>())
                {
                    if (firstRow)
                    {
                        firstRow = false;
                        // Skip first row if needed
                        if (skipFirstRow) continue;
                    }
                    var cells = r.Elements<Cell>().Select(c => c).ToArray();
                    if (cells.Count() != products.Columns.Count)
                    {
                        throw new ArgumentException("Columns count mismatch");
                    }
                    var newRow = products.NewRow();
                    for (int colIndex = 0; colIndex < products.Columns.Count; colIndex++)
                    {
                        ParseXlsxRow(rowIndex, cells, newRow, colIndex, stringTable);
                    }
                    products.Rows.Add(newRow);
                    rowIndex++;
                }
            }
            return products;
        }

        private void ParseXlsxRow(int rowIndex, Cell[] cells, DataRow row, int colIndex, SharedStringTablePart stringTable)
        {
            var cell = cells[colIndex];
            var cellText = GetCellValueAsString(cell, stringTable);

            switch (colIndex)
            {
                case 0:
                case 1:
                    // Article
                    // Name
                    row[colIndex] = cellText;
                    break;

                case 2:
                    // Price
                    if (decimal.TryParse(cellText, out decimal decVal))
                    {
                        row[colIndex] = decVal;
                    }
                    else
                    {
                        throw new ArgumentException($"Row: {rowIndex} Col:{colIndex} MUST be decimal value!");
                    }
                    break;

                case 3:
                    // Quantity
                    if (int.TryParse(cellText, out int intVal))
                    {
                        row[colIndex] = intVal;
                    }
                    else
                    {
                        throw new ArgumentException($"Row: {rowIndex} Col:{colIndex} MUST be integer value!");
                    }
                    break;
            }
        }

        private string GetCellValueAsString(Cell cell, SharedStringTablePart stringTable)
        {
            if (cell.DataType == null) return cell.CellValue.Text;

            switch (cell.DataType.Value)
            {
                case CellValues.SharedString:
                    if (stringTable != null)
                    {
                        return stringTable.SharedStringTable.ElementAt(int.Parse(cell.CellValue.Text)).InnerText;
                    }
                    return null;

                default:
                    return cell.CellValue.Text;
            }
        }

        private DataTable InitProductDataTable()
        {
            var result = new DataTable();
            result.Columns.Add("Article", typeof(string));
            result.Columns.Add("Name", typeof(string));
            result.Columns.Add("Price", typeof(decimal));
            result.Columns.Add("Quantity", typeof(int));
            return result;
        }
    }
}