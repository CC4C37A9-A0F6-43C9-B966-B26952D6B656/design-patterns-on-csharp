using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational.Adapter.Model
{
    public class DataPaternRendererAdapter : IDataPatternRendererAdapter
    {
        private DataRenderer _dataRenderer;
        public string ListPatterns(IEnumerable<Pattern> patterns)
        {
            var adapter = new PatternCollectionDbAdapter(patterns);
            _dataRenderer = new DataRenderer(adapter);

            var writer = new StringWriter();
            _dataRenderer.Render(writer);

            return writer.ToString();
        }
        internal class PatternCollectionDbAdapter : IDbDataAdapter
        {
            private readonly IEnumerable<Pattern> _patterns;
            public PatternCollectionDbAdapter(IEnumerable<Pattern> patterns)
            {
                _patterns = patterns;
            }
            int IDataAdapter.Fill(DataSet dataSet)
            {
                var myDataTable = new DataTable();
                myDataTable.Columns.Add(new DataColumn("Id", typeof(int)));
                myDataTable.Columns.Add(new DataColumn("Name", typeof(string)));
                myDataTable.Columns.Add(new DataColumn("Description", typeof(string)));

                foreach (var pattern in _patterns)
                {
                    var myRow = myDataTable.NewRow();
                    myRow[0] = pattern.Id;
                    myRow[1] = pattern.Name;
                    myRow[2] = pattern.Description;
                    myDataTable.Rows.Add(myRow);
                }

                dataSet.Tables.Add(myDataTable);
                dataSet.AcceptChanges();


                return myDataTable.Rows.Count;
            }
            #region not implemented
            IDbCommand IDbDataAdapter.DeleteCommand
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            IDbCommand IDbDataAdapter.InsertCommand
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            MissingMappingAction IDataAdapter.MissingMappingAction
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            MissingSchemaAction IDataAdapter.MissingSchemaAction
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            IDbCommand IDbDataAdapter.SelectCommand
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            ITableMappingCollection IDataAdapter.TableMappings
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            IDbCommand IDbDataAdapter.UpdateCommand
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }



            DataTable[] IDataAdapter.FillSchema(DataSet dataSet, SchemaType schemaType)
            {
                throw new NotImplementedException();
            }

            IDataParameter[] IDataAdapter.GetFillParameters()
            {
                throw new NotImplementedException();
            }

            int IDataAdapter.Update(DataSet dataSet)
            {
                throw new NotImplementedException();
            } 
            #endregion
        }
    }
}
