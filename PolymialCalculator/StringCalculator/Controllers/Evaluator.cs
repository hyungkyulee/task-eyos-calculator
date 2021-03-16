using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using StringCalculator.Domains;

namespace StringCalculator.Controllers
{
    public class Evaluator
    {
        public string Handle(string input)
        {
            /*
            var inputExpression = input;
            var resultSets = new List<IElement>();
            
            // check if it's a single element - '*'/'+' check
            if (IsSingleElement(inputExpression))
            {
                return new Element(inputExpression).Evaluate();
            }
            
            // check if it's a single group polynomial. - remove parentheses and no '+' operators
            if(IsSingleGroupPolynomial(inputExpression))
            {
                resultSets.AddRange(EvaluateSingleGroupExpression(inputExpression));
            }
            else
            {
                var ePattern = @"([a-z\*]+)?\([\da-z\*\+]+\)([\*\da-z]+)?"; // extract '() and *' combinations
                var groups = new Regex(ePattern).Matches(inputExpression);

                var groupExpressions = new List<IElement>();

                foreach (Match group in groups)
                {
                    groupExpressions.Add(new Element(group.ToString()));
                    inputExpression = inputExpression.Replace(group.ToString(), ""); // extract remain parts with '+' polynomials
                }

                // evaluate the each group expressions
                foreach (var singleGroupExpression in groupExpressions)
                {
                    resultSets.AddRange(EvaluateSingleGroupExpression(singleGroupExpression.Evaluate()));
                }
            }

            // add-evaluation of the result expression
            var add = new Add(resultSets);
            var resultExpression = add.Evaluate(); 
            
            // integrate group expression and remain add sets, and do CalcExpresison to finalise
            if (IsSingleGroupPolynomial(input))
            {
                return resultExpression;
            }
            else
            {
                var auxExpression =   new CalcExpression(inputExpression).Evaluate();
                if (resultExpression == string.Empty && auxExpression != string.Empty)
                {
                    return auxExpression;
                }
                
                if (auxExpression != string.Empty)
                {
                    return resultExpression + "+" + auxExpression;
                }

                return resultExpression;
            }
            */
            return "";
        }

/*        
        
        private bool IsSingleElement(string input)
        {
            return !input.Contains("+") && !input.Contains("*");
        }

        private IEnumerable<IElement> EvaluateSingleGroupExpression(string input)
        {
            var singleGroupExpression = input;
            var resultSets = new List<IElement>();
            
            var pPattern = @"\([\d\sa-z\+\*]+\)";
            var parenthesisExpressions = new Regex(pPattern).Matches(singleGroupExpression);

            // (.. + ..) detection to cross-multiply them each other.
            var prevSets = new List<IElement>();
            foreach (Match parenthesisExpression in parenthesisExpressions)
            {
                var currentSets = new List<IElement>();
                if (parenthesisExpression.ToString().Contains("+"))
                {
                    currentSets.AddRange(parenthesisExpression.ToString()
                        .Trim(new char[] {'(', ')'})
                        .Split("+")
                        .Select(x => new Element(x)));
                }

                if (prevSets.Count > 0)
                {
                    // only for two sets 
                    for (var i = 0; i<prevSets.Count;i++)
                    {
                        for (var j = 0; j < currentSets.Count; j++)
                        {
                            var calSets = new List<IElement> {prevSets[i], currentSets[j]};
                            // resultSets.Add(new Element(new Multiply(new IElement[] {prevSets[i], prevSets[j]})));
                            var multiply = new Multiply(calSets);
                            resultSets.Add(new Element(multiply.Evaluate()));
                        }
                    }
                }
                else
                {
                    // prevSets = currentSets.Select(x => new Element(x.Evaluate()));
                    foreach (var currentSet in currentSets)
                    {
                        prevSets.Add(new Element(currentSet.Evaluate()));
                    }
                }
            }
            
            // do cross-multiplying if '*' connected with ()s 
            var withoutParenthesesExpression = singleGroupExpression;
            foreach (Match parenthesisExpression in parenthesisExpressions)
            {
                withoutParenthesesExpression = withoutParenthesesExpression.Replace(parenthesisExpression.ToString(), "");
            }
            
            // '*' connection with ()s and do multiply them
            if (withoutParenthesesExpression.Contains("*"))
            {
                var elements = withoutParenthesesExpression
                    .Split("*")
                    .Select(x => new Element(x));
                var otherMultiply = new Multiply(elements);
                
                var simplifiedMultiply = otherMultiply.Evaluate();
                if (simplifiedMultiply != string.Empty && prevSets.Count > 0)
                {
                    // only for two sets 
                    for (var i = 0; i<prevSets.Count;i++)
                    {
                        var calSets = new List<IElement> {prevSets[i], new Element(simplifiedMultiply)};
                        // resultSets.Add(new Element(new Multiply(new IElement[] {prevSets[i], prevSets[j]})));
                        var multiply = new Multiply(calSets);
                        resultSets.Add(new Element(multiply.Evaluate()));
                    }
                }
                else
                {
                    resultSets.Add(new Element(simplifiedMultiply));
                }
            }
            else // it's single parentheses
            {
                // (.. + ..) single case
                resultSets = prevSets;
                
                // (.. * ..) all multyply case
                if (resultSets.Count == 0)
                {
                    var elements = singleGroupExpression.Trim(new char[] {'(', ')'})
                        .Split("*")
                        .Select(x => new Element(x));
                    var multiply = new Multiply(elements);
                    resultSets.Add(new Element(multiply.Evaluate()));
                }
            }

            return resultSets;
        }

        private bool IsSingleGroupPolynomial(string input)
        {
            var updatedExpression = input;
            var pPattern = @"\([\d\sa-z\+\*]+\)";
            var parenthesisExpressions = new Regex(pPattern).Matches(updatedExpression);
            
            foreach (Match parenthesisExpression in parenthesisExpressions)
            {
                updatedExpression = updatedExpression.Replace(parenthesisExpression.ToString(), "");
            }

            if (updatedExpression.Contains("+"))
            {
                return false;
            }

            return true;
        }
*/
    }
}