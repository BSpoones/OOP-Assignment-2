namespace MathsTutor
{
    public interface ICard
    {
        void DrawCard();
        int GetValue();
    }

    public class Card: ICard
    {
        // Private variables
        private int _value;
        private SuitType _suit;

        public int Value
        {
            get { return _value; }
            set
            {
                if (value < 1 || value > 13)
                {
                    throw new ArgumentOutOfRangeException($"Card value must be between 1-13, not {value}");
                }
                else
                {
                    _value = value;
                }
            }
        }
        public SuitType Suit
        {
            get { return _suit; }
            set { _suit = value; }
        }

        public Card(SuitType suit, int value)

        {
            Suit = suit;
            Value = value;
        }

        /*
         * 
         */
        public virtual void DrawCard()
        {
            string cardTemplate = Constants.cardTemplate;
        }

        /*
         * 
         */
        public enum SuitType
        {
            Spades = 1,
            Clubs,
            Heats,
            Diamonds
        }

        /*
         * 
         */
        public virtual int GetValue()
        {
            
            return ((int)Suit - 1) * 13 + Value;
        }

        /*
         * 
         */
        public override string ToString()
        {
            return $"Card: {Value} of {Suit}";
        }
    }
}
