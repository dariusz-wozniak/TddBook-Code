using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using ExcelDataReader;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace TddBook.Tests.Integration.ParametrizedTests
{
    public class Log2NData
    {
        private static DataTable ReadExcelData()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ParametrizedTests", "Log2N.xlsx");
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            using (var reader = ExcelReaderFactory.CreateOpenXmlReader(stream))
            {
                DataSet dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                });
                return dataSet.Tables[0];
            }
        }

        internal static IEnumerable<ITestCaseData> Data
        {
            get
            {
                DataTable results = ReadExcelData();
                if (results == null) throw new InvalidOperationException("Well, something went wrong and results is null");

                foreach (DataRow row in results.Rows)
                {
                    double a = Convert.ToDouble(row["n"]);
                    double result = Convert.ToDouble(row["log2(n)"]);
                    yield return new TestCaseData(a, result);
                }
            }
        }
    }
}