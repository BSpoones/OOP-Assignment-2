namespace MathsTutor
{
    /*
     * OperatorCard subclass
     * 
     * Used for all Operator Cards
     */
    public class OperatorCard : Card
    {
        public OperatorCard(SuitType suit, double value) : base(suit, value)
        {
            // Getting the operator when instantiating to ensure
            // the correct Operator class is used
            GetOperator();
        }

        /*
         * DrawCard override
         * 
         * Unlike the numbercards, it only makes sense
         * to have the operator shown in ASCII art, instead
         * of the object's value
         */
        public override string DrawCard()
        {
            return 
                "       \n"+
                "       \n"+
                "       \n"+
                $"   {GetOperator()}   \n"+
                "       \n" +
                "       \n"
                ;
        }

        /*
         * GetOperator method
         * 
         * Assigns an Operator Class dependant on
         * the SuitType int
         */
        public Operator GetOperator()
        {
            Operator OPERATOR = (int)Suit switch
            {
                1 => new AdditionOperator(),
                2 => new SubtractionOperator(),
                3 => new MultiplicationOperator(),
                4 => new DivisionOperator(),
                _ => throw new Exception(),
            };
            return OPERATOR;
        }

        /*
         * GetValue Override
         * 
         * Only the SuitType should be shown in the GetValue
         */
        public override double GetValue()
        {
            return (double)Suit;
        }

        /*
         * ToString Override
         * 
         * Only the operator (+-*÷) should be shown here
         */
        public override string ToString()
        {
            return GetOperator().ToString();
        }
    }
}
