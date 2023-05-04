using System.Text;

namespace MathsTutor
{
    /*
     * ICard interface
     * 
     * Responsible for ensuring DrawCard and GetValue are present
     */
    public interface ICard // SPEC: Interfaces
    {
        string DrawCard();
        double GetValue();
    }

    /*
     * Card Class
     * 
     * Responsible for instantiation of a card
     *  - SuitType Suit
     *  - Double Value
     *  
     * Also repsonsible for drawing a base card (overriden in OperatorCard.cs
     */
    public class Card: ICard
    {
        // Private variables
        private double _value; // SPEC: Encapsulation
        private SuitType _suit;

        // Setting properties
        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public SuitType Suit
        {
            get { return _suit; }
            set { _suit = value; }
        }

        public Card(SuitType suit, double value)

        {
            Suit = suit;
            Value = value;
        }

        /*
         * Uses the card template and bitmaps in Constants.cs
         * to draw an ASCII interpretation of a card. See powerpoint
         * for why this helps the target audience
         */
        public virtual string DrawCard()
        {
            string cardTemplate = Constants.cardTemplate;

            // Creating string builder
            StringBuilder newCardTemplate = new(cardTemplate);

            // Replace each instance of Y with the bitmap
            string cardBitMap = Constants.cardBitmap[(int)Value];

            // Replacing Ys
            foreach (char c in cardBitMap.ToList())
            {
                // Similar to BODMAS, this finds an index and replaces it
                int Yindex = newCardTemplate.ToString().IndexOf("Y");

                char replaceChar = '_';
                switch (c)
                {
                    case '0': // Empty space
                        replaceChar = ' ';
                        break;
                    case '1': // Suit image required
                        switch (Suit)
                        {
                            case SuitType.Spades: replaceChar = '♠'; break;
                            case SuitType.Clubs: replaceChar = '♣'; break;
                            case SuitType.Hearts: replaceChar = '♥'; break;
                            case SuitType.Diamonds: replaceChar = '♦'; break;
                        }
                        break;
                    default: // Bitmaps are manually set, meaning this won't happen
                        break;
                }
                // Replacing the char in the template
                newCardTemplate[Yindex] = replaceChar;
            }

            // Replacing Xs to numbers
            string XreplaceString;
            for (int i = 0; i < 2; i++)
            {
                int Xindex = newCardTemplate.ToString().IndexOf("X");
                if (Value < 10)
                {
                    // The image changes depending if the value is 1 or 2 chars long
                    if (i == 1) { 
                        XreplaceString = $"_{Value}"; // Ensuring no gaps on bottom template
                    }
                    else
                    {
                        XreplaceString = $"{Value} "; // Top template
                    }
                }
                else
                {
                    XreplaceString = $"{Value}";
                }
                // Replacing chars in template
                newCardTemplate[Xindex] = XreplaceString[0];
                newCardTemplate[Xindex+1] = XreplaceString[1];
            }

            return newCardTemplate.ToString();

        }

        /*
         * SuitType enum
         * 
         * Responsible for mapping values to SuitTypes
         */
        public enum SuitType
        {
            Spades = 1,
            Clubs,
            Hearts,
            Diamonds
        }

        /*
         * GetValue base function
         * 
         * Overriden in OperatorCard.cs
         */
        public virtual double GetValue()
        {
            
            return ((int)Suit - 1) * 13 + Value;
        }

        /*
         * ToString override
         * 
         * Formats card into easy to read string
         */
        public override string ToString()
        {
            return $"Card: {Value} of {Suit}";
        }
    }
}
