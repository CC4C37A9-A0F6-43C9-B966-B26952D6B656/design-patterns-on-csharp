using System.Collections;
using System.Collections.Generic;

namespace Creational.Adapter.Model
{
    public interface IDataPatternRendererAdapter
    {
        string ListPatterns(IEnumerable<Pattern> patterns);
    }
}