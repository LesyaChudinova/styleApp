using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp8
{
    public class ExcelDataLoader
    {
        public List<ClothingItem> LoadClothingItemsFromExcel(string filePath, string sheetName = "Лист1")
        {
            List<ClothingItem> items = new List<ClothingItem>();

            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException("Файл базы данных не найден!");
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(fileInfo))
            {
                var worksheet = package.Workbook.Worksheets[sheetName];
                if (worksheet == null)
                {
                    throw new Exception($"Лист '{sheetName}' не найден в файле.");
                }

                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                var headers = new List<string>();
                for (int col = 2; col <= colCount; col++)
                {
                    headers.Add(worksheet.Cells[1, col].Text);
                }

                for (int row = 2; row <= rowCount; row++)
                {
                    string itemName = worksheet.Cells[row, 1].Text; 
                    var attributes = new Dictionary<string, List<string>>();

                    for (int col = 2; col <= colCount; col++)
                    {
                        string header = headers[col - 2];
                        string cellValue = worksheet.Cells[row, col].Text;

                        var values = cellValue.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                        var trimmedValues = new List<string>();

                        foreach (var value in values)
                        {
                            trimmedValues.Add(value.Trim());
                        }

                        attributes.Add(header, trimmedValues);
                    }

                    items.Add(new ClothingItem(itemName, attributes));
                }
            }

            return items;
        }
    }
}
