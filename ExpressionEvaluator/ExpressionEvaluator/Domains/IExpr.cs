namespace ExpressionEvaluator.Domains
{
    public interface IExpr
    {
        int Evaluate();
        string EvaluateVariable();
    }
}