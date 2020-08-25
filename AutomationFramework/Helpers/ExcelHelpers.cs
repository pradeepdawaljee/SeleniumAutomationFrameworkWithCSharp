using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Helpers
{
    public class ExcelHelpers
    {


        // This code works for excel library - less than 3.0 v only
        /*public static DataTable ExcelToDataTable(string fileName,string sheetName)
        {
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader=ExcelReaderFactory.CreateOpenXmlReader(stream);
            //excelReader.
            DataTableCollection table= excelReader.AsDataSet().Tables;

            DataTable resultTable=table[sheetName];//table["sheet1"];

            return resultTable;

        }*/


        public static DataTable ExcelToDataTable(string fileName, string sheetName)
        {

            using(var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {

                using(var reader = ExcelReaderFactory.CreateReader(stream))
                {

                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {

                        ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }

                    });

                    DataTableCollection table = result.Tables;

                    DataTable resultTable = table[sheetName];//table["sheet1"];

                    return resultTable;

                }

            }

        }

        List<DataCollection> dataCol = new List<DataCollection>();

        public void PopulateInCollection(string fileName, string sheetName)
        {

            DataTable table = ExcelToDataTable(fileName,sheetName);

            for(int row = 2; row <= table.Rows.Count + 1; row++) {

                for(int col = 0; col < table.Columns.Count; col++)
                {
                    DataCollection dataCollection = new DataCollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 2][col].ToString()
                    };

                    //Add all the details for each row
                    dataCol.Add(dataCollection);
                }


            }

        }


        public string ReadData(int rowNumber,string columnName)
        {

            try
            {
                //Retrieving data using LINQ to reduce much of iterations
                string data = "";
                data = (from colData in dataCol
                        where colData.colName == columnName && colData.rowNumber == rowNumber
                        select colData.colValue).SingleOrDefault();
                return data.ToString();

            }
            catch (Exception)
            {
                return null;
            }

        }


    }


    public class DataCollection
    {

        public int rowNumber { get; set; }

        public string colName { get; set; }

        public string colValue { get; set; }

    }

}
