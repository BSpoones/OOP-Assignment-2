namespace MathsTutor
{
    /*
     * MultiplicationOperator subclass
     * 
     * Handles Calculations for Multiplication operators
     */
    public class MultiplicationOperator : Operator
    {
        public override double Calculate(double val1, double val2)
        {
            return val1 * val2;
        }

        public override string ToString()
        {
            return "x";
        }
    }
}
