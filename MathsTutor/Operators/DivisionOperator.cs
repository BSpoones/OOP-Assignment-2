namespace MathsTutor
{
    /*
     * DivisionOperator subclass
     * 
     * Handles Calculations for Division operators
     */
    public class DivisionOperator : Operator
    {
        public override double Calculate(double val1, double val2)
        {
            return val1 / val2;
        }

        public override string ToString()
        {
            return "÷";
        }
    }
}
