namespace MathsTutor
{
    /*
     * NumberCard subclass
     * 
     * Used for all Number cards
     */
    public class NumberCard : Card // SPEC: Inheritance
    {
        public NumberCard(SuitType suit, double value) : base(suit, value)
        {
        }

        /*
         * GetValue override
         * 
         * Only returning the number part of the object
         */
        public override double GetValue()
        {
            return Value; // 1-13
        }

        /*
         * ToString override
         * 
         * Only showing the value, not the suit
         */
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
