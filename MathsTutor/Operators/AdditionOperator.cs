namespace MathsTutor
{
    /*
     * AdditionOperator subclass
     * 
     * Handles Calculations for Addition operators
     */
    public class AdditionOperator : Operator
    {
        public override double Calculate(double val1, double val2) // SPEC: Polymorphism
        {
            return val1 + val2;
        }

        public override string ToString()
        {
            return "+";
        }
    }
}
