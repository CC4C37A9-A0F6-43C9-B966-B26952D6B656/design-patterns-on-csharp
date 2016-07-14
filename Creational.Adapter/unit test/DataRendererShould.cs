using Creational.Adapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.OleDb;
using System.IO;
using System.Linq;

namespace Creational
{
    [TestClass]
    public class DataRendererShould 
    {
        [TestMethod]
        public void RenderOneRowGivenStubDataAdapter()
        {
            var myRenderer = new DataRenderer(new StubDataAdapter()/*1-IF WE PROVIDE A STUB DB ADAPTER WE DO EXPECT*/);
            var writer = new StringWriter();
            myRenderer.Render(writer);/*2-WE GET THE OUTPUT THAT WE EXPECT*/

            string result = writer.ToString();
            Console.Write(result);

            int lineCount = result.Count(k => k == '\n');
            Assert.AreEqual(3, lineCount);
        }
        [TestMethod]
        public void RenderTwoRowsGivenOleDbDataAdapter()
        {
            var adapter = new OleDbDataAdapter();
            adapter.SelectCommand = new OleDbCommand("select * from Pattern");
            adapter.SelectCommand.Connection
                = new OleDbConnection(@"Provider=SQLNCLI11;Data Source=PC-WANDERSON\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=DbCustomer");
            var myRenderer = new DataRenderer(adapter);

            var writer = new StringWriter();
            myRenderer.Render(writer);

            string result = writer.ToString();
            Console.Write(result);
            int lineCount = result.Count(k => k == '\n');
            Assert.AreEqual(4, lineCount);
        }
    }
}