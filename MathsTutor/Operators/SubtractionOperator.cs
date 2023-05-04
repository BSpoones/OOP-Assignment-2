namespace MathsTutor
{
    /*
     * SubtractionOperator subclass
     * 
     * Handles Calculations for Subtraction operators
     */
    public class SubtractionOperator : Operator
    {
        public override double Calculate(double val1, double val2)
        {
            return val1 - val2;
        }

        public override string ToString()
        {
            return "-";
        }
    }
}
