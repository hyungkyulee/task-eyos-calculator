using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StringCalculator.Domains
{
    public interface IElement
    {
        int Value { get; }
        IEnumerable<IElement> Elements { get; }
        string Evaluate();
    }
}