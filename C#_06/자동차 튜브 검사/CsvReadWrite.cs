using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;

namespace chsj
{
    /// <summary>
    /// Class to store one CSV row
    /// </summary>
    public class CsvRow : List<string>
    {
        public string LineText { get; set; }
    }

    /// <summary>
    /// Class to write data to a CSV file
    /// </summary>
    public class CsvFileReadWrite
    {
        /// <summary>
        /// Writes a single row to a CSV file.
        /// </summary>
        /// <param name="row">The row to be written</param>
        public void WriteCSV(CsvRow row, string Path)
        {
            using (var writer = new StreamWriter(Path, true, Encoding.Default))
            {
                StringBuilder builder = new StringBuilder();

                bool firstColumn = true;
                foreach (string value in row)
                {
                    // Add separator if this isn't the first value
                    if (!firstColumn)
                        builder.Append(',');
                    // Implement special handling for values that contain comma or quote
                    // Enclose in quotes and double up any double quotes
                    if (value.IndexOfAny(new char[] { '"', ',' }) != -1)
                        builder.AppendFormat("\"{0}\"", value.Replace("\"", "\"\""));
                    else
                        builder.Append(value);
                    firstColumn = false;
                }
                row.LineText = builder.ToString();
                writer.WriteLine(row.LineText);
            }

        }

        public DataSet ReadCSV(string csvFile)
        {
            try
            {
                if (System.IO.File.Exists(csvFile))
                {
                    System.IO.FileInfo fi = new FileInfo(csvFile);
                    string filePath = fi.DirectoryName.ToString();
                    string fileName = fi.Name.ToString();
                    // odbc connection string

                    string connectString = "Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" + filePath + ";Extensions=asc,csv,tab,txt;Persist Security Info=False";

                    OdbcConnection conn = null;
                    OdbcDataAdapter da = null;
                    DataSet ds = new DataSet();
                    conn = new OdbcConnection(connectString);
                    conn.Open();

                    string strQuery = string.Format(@"SELECT BOWL, CAM, FLAG, DATE, DETAILDATE, FILENAME AS 파일명, PATH, BLOBAREA FROM [{0}]", fileName);
                    da = new OdbcDataAdapter(strQuery, conn);
                    da.Fill(ds);
                    conn.Close();
                    return ds;
                }
                else
                {
                    return (DataSet)null;
                }
            }
            catch
            {
                return (DataSet)null;
            }
        }


    }
}
