using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational.Adapter
{
    /// <summary>
    /// This is also an example of Strategy pattern in this cause, because we're able to change how this class behaves based on what type of interface we
    /// pass into it
    /// </summary>
    public class DataRenderer
    {
        private readonly IDataAdapter _dataAdapter;
        public DataRenderer(IDataAdapter dataApater)
        {
            _dataAdapter = dataApater;
        }
        public void Render(TextWriter writer)
        {
            writer.WriteLine("rendenring data:");
            var myDataSet = new DataSet();

            _dataAdapter.Fill(myDataSet);
            foreach (DataTable table in myDataSet.Tables)
            {
                foreach (DataColumn column in table.Columns)
                {
                    writer.Write(column.ColumnName.PadRight(20) + " ");
                }
                writer.WriteLine();
                foreach (DataRow row in table.Rows)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        writer.Write(row[i].ToString().PadRight(20) + " ");
                    }
                    writer.WriteLine();
                }
            }
        }
    }
}
