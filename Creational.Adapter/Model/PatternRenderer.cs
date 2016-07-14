using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational.Adapter.Model
{
    public class PatternRenderer
    {
        private readonly IDataPatternRendererAdapter _dataPatternRenderer;

        public PatternRenderer():this(new DataPaternRendererAdapter())
        {
        }

        public PatternRenderer(IDataPatternRendererAdapter dataPatternRenderer)
        {
            _dataPatternRenderer = dataPatternRenderer;
        }
        public string ListPatterns(IEnumerable<Pattern> patterns)
        {
            return _dataPatternRenderer.ListPatterns(patterns);
        }
    }
}
