using OfficeOpenXml;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace ConsoleApp8
{
    
    public class ExcelDataLoader
    {
        public List<Outfit> LoadOutfitsFromExcel(string filePath)
        {
            List<Outfit> outfits = new List<Outfit>();

            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException("Файл базы данных не найден!");
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(fileInfo))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++) // Предполагаем, что первая строка — заголовки
                {
                    int id = int.Parse(worksheet.Cells[row, 1].Text);
                    string name = worksheet.Cells[row, 2].Text;
                    string weather = worksheet.Cells[row, 3].Text;
                    string occasion = worksheet.Cells[row, 4].Text;
                    string style = worksheet.Cells[row, 5].Text;

                    outfits.Add(new Outfit(id, name, weather, occasion, style));
                }
            }

            return outfits;
        }
    }
}
