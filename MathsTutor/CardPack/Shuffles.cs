namespace MathsTutor
{
    public enum ShuffleType
    {
        Fisheryates = 1,
    }
    public class Shuffle
    /*
     * This class contains 2 shuffle algorithms
     * Fisher-Yates shuffle and Riffle shuffle
     * Contains enum to convert shuffle type to int
     */
    {
        public static void FisherShuffle(ref List<Card> cards)
        {
            /*
             * Fisher-Yates shuffle works by iterating through the deck,
             * swapping the current card with a random card all the way
             * through the deck until 52 swaps have occured
             */
            // Ensuring that a 52 card deck is used
            if (cards.Count != 52)
            {
                throw new ArgumentOutOfRangeException("Invalid deck length");
            }

            for (int i = cards.Count - 1; i > 0; i--)
            {
                // Finding a random card to swap with
                int j = Constants.random.Next(i + 1);

                // Swapping the cards around
                (cards[j], cards[i]) = (cards[i], cards[j]);
            }
        }
    }
}
