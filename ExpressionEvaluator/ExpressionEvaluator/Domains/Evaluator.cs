namespace ExpressionEvaluator.Domains
{
    public class Evaluator
    {
        public int Evaluate(string input)
        {
            var elem = new Elem(input);
            return elem.Number;
            
            
        }
    }
}