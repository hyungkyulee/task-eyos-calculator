// using System.Collections.Generic;
// using System.Linq;
//
// namespace StringCalculator.Domains
// {
//     public class Add : IElement
//     {
//         private readonly IEnumerable<IElement> _variables;
//         private readonly IEnumerable<IElement> _numbers;
//
//         public Add(IElement element)
//         {
//             if(!int.TryParse(element.Evaluate(), out _)) _variables = new[] {element};
//             if(int.TryParse(element.Evaluate(), out _)) _numbers = new[] {element};
//         }
//         public Add(IEnumerable<IElement> elements)
//         {
//             _variables = elements.Where(x => !int.TryParse(x.Evaluate(), out _));
//             _numbers = elements.Where(x => int.TryParse(x.Evaluate(), out _));
//         }
//         
//         public string Evaluate()
//         {
//             int valueSum = 0;
//             string variableName = string.Empty;
//
//             // 1) n only (single n, or n+n+ ...)
//             if (_numbers != null && _variables == null)
//             {
//                 foreach (var number in _numbers)
//                 {
//                     valueSum += int.Parse(number.Evaluate());
//                 }    
//             }
//             
//             // 2) v aonly (single v or v+v+v ...)
//             if (_variables != null && _numbers == null)
//             {
//                 var variableNames = new List<IElement>();
//                 // foreach (var variable in _variables)
//                 // {
//                 //     var factors = variable.Evaluate().Split("*");
//                 //     if(variableNames.Where(v => v.Evaluate().))
//                 //     variableName += variable.Evaluate() + "+";
//                 // }
//             }
//             
//             // 3) 
//
//             if (_variables != null)
//             {
//                 
//             }
//
//             if (variableName == string.Empty)
//             {
//                 return (valueSum > 0) ? valueSum.ToString() : "";
//             }
//             else
//             {
//                 return (valueSum > 0) ? $"{valueSum}+{variableName.Trim('+')}" : variableName.Trim('+');
//             }
//         }
//     }
// }