using CMP1903M_A01_2223;


namespace MathsTutor
{
    public class Pack
    /*
     * Pack class
     * 
     * This class contains functions to create a card pack,
     * as well as shuffle and deal cards.
     */
    {
        public List<Card> cardPack;

        public Pack() {
            cardPack = makePack();
            ShuffleCardPack();
        }
        

        public void ShuffleCardPack(int shuffleType = 1)
        /*
        * Shuffles the card pack using the chosen shuffle method.
        * Uses the 3 available shuffle methods:
        * - Fisher-Yates shuffle (https://en.wikipedia.org/wiki/Fisher–Yates_shuffle)
        * - Riffle shuffle (https://www.youtube.com/watch?v=o-KBNdbJOGk)
        * - No shuffle
        */
        {
            ShuffleType shuffle = GetShuffleType(shuffleType);
            switch (shuffle)
            {
                case ShuffleType.Fisheryates:
                    Shuffle.FisherShuffle(ref this.cardPack);
                    break;
                case ShuffleType.Riffle:
                    Shuffle.RiffleShuffle(ref cardPack);
                    break;
                case ShuffleType.None:
                    Shuffle.noShuffle(ref cardPack);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"{shuffle} is an invalid input");
            }
        }
        private static ShuffleType GetShuffleType(int shuffleType)
        /*
         * Converts an integer shuffle type to an enum value
         * from ShuffleType
         */
        {
            switch (shuffleType)
            {
                case 1:
                    return ShuffleType.Fisheryates;
                case 2:
                    return ShuffleType.Riffle;
                case 3:
                    return ShuffleType.None;
                default:
                    throw new ArgumentOutOfRangeException("Invalid shuffle type");
            }
        }

        public Card Deal()
        {
            /*
            * Deals one card from the top of the deck
            */

            if (cardPack.Count < 1)
            {
                throw new ArgumentOutOfRangeException("No cards left to deal");
            }
            Card dealtCard = cardPack.First();
            // Dealing a card means it is removed from the pack
            cardPack.Remove(dealtCard);
            return dealtCard;
        }
        public List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'

            // Getting the cards
            // NOTE: Error handling not required as the smallest value between amount and card count is used
            List<Card> dealtCards = cardPack.GetRange(0, Math.Min(amount, cardPack.Count()));
            cardPack.RemoveRange(0, Math.Min(amount, cardPack.Count()));
            return dealtCards;
        }

        public List<Card> makePack()
        {
            /*
             * Creates a list of 52 card objects
             */
            List<Card> cardPack = new List<Card>();
            // Creating an unsorted card pack
            foreach (Card.SuitType suit in Enum.GetValues(typeof(Card.SuitType)))
            {
                // Each card suit
                for (int j = 1; j <= 13; j++)
                {
                    // Each card value
                    cardPack.Add(new Card(suit, j));
                }
            }
            return cardPack;
        }
        public void OutputPack()
        {
            /*
             * Outputs a given card pack line by line to the console
             */
            foreach (Card card in cardPack)
            {
                Console.WriteLine(card.ToString());
            }
        }
    }
}
