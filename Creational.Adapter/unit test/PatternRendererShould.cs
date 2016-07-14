using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Creational.Adapter.Model;

namespace Creational.Adapter.unit_test
{
    [TestClass]
    public class PatternRendererShould
    {
        [TestMethod]
        public void RenderOnePattern()
        {
            var myRenderer = new Creational.Adapter.Model.PatternRenderer();
            var myList = new List<Pattern>
            {
                new Pattern {Id=1, Name="Pattern one", Description="Pattern one Description" },
                new Pattern {Id=1, Name="Pattern two", Description="Pattern two Description" }
            };

            string result = myRenderer.ListPatterns(myList);
            Console.Write(result);

            int lineCount = result.Count(k => k == '\n');
            Assert.AreEqual(myList.Count + 2, lineCount);
        }
    }
}
