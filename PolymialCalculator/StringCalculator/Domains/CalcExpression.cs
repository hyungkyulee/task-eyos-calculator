// using System.Collections.Generic;
// using System.Linq;
// using System.Xml.Serialization;
//
// namespace StringCalculator.Domains
// {
//     public class CalcExpression : IElement
//     {
//         private string _expression;
//
//         public CalcExpression(string expression)
//         {
//             _expression = expression;
//         }
//
//
//         public string Evaluate()
//         {
//             var valueSum = 0;
//             var updatedExpression = string.Empty;
//             var parentheses = new char[] {'(', ')'};
//             var addSubExpressions = _expression.Trim(parentheses).Split("+");
//
//             var singleAddElements = new List<IElement>();
//             foreach (var addSubExpression in addSubExpressions)
//             {
//                 if (addSubExpression.Contains("*"))
//                 {
//                     var elements = addSubExpression.Trim(parentheses)
//                         .Split("*")
//                         .Select(x => new Element(x));
//
//                     var multiply = new Multiply(elements);
//                     updatedExpression += multiply.Evaluate() + "+";
//                 }
//                 else
//                 {
//                     singleAddElements.Add(new Element(addSubExpression));
//                 }
//             }
//             
//             var add = new Add(singleAddElements);
//             return (add.Evaluate() + updatedExpression).Trim('+');
//         }
//     }
// }