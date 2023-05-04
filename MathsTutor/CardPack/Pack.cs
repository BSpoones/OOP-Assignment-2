
namespace MathsTutor
{
    /*
     * Pack class
     * 
     * This class contains functions to create a card pack,
     * as well as shuffle and deal cards.
     */
    public class Pack
    
    {
        // Creates and shuffles card pack when instantiating object
        public List<Card> cardPack;

        public Pack() {
            cardPack = MakePack();
            ShuffleCardPack();
        }
        

        public void ShuffleCardPack()
        /*
        * Shuffles the card pack using the chosen shuffle method.
        * - Fisher-Yates shuffle (https://en.wikipedia.org/wiki/Fisher–Yates_shuffle)
        */
        {
            Shuffle.FisherShuffle(ref cardPack); // SPEC: Shuffle algorithm of your choice
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

        /*
         * As opposed to the original design, this method retrieves a random `amount` of cards
         * from the pack. Instead of deleting them, they are kept in the pack to ensure infinite
         * gameplay.
         * 
         * To get x random cards, the pack is shuffled and the first x cards are taken from the
         * start of the pack, it then converts them to NumberCard and OperatorCard respectively
         */
        public List<Card> DealCard(int amount)
        {
            // SPEC: Deal 3 cards, Deal 5 cards

            // Ensuring correct value
            if (amount %2 == 0 && amount >= 3 && amount <= 51) // && is used instead of & for short circuiting purposes
            {
                throw new ArgumentException($"{amount} must be an odd integer between 3 and 51");
            }

            ShuffleCardPack(); // Shuffling ensures a random card set each time
            List<Card> dealtCards = cardPack.GetRange(0, Math.Min(amount, cardPack.Count));
            List<Card> gameCards = new();
            for (int i = 0; i < dealtCards.Count; i++)
            {
                Card card = dealtCards[i];
                if (i % 2 == 0) // Even card - NumberCard (since it starts at 0)
                {
                    gameCards.Add(new NumberCard(card.Suit, card.Value));
                }
                else
                {
                    gameCards.Add(new OperatorCard(card.Suit, card.Value));
                }
            }

            return gameCards;
        }

        public static List<Card> MakePack()
        {
            /*
             * Creates a list of 52 card objects
             */

            List<Card> cardPack = new();
            // Creating an unshuffled card pack
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
