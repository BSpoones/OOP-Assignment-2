

namespace MathsTutor
{
    /*
     * FiveCardGame class
     * 
     * Handles all aspects of a five card game
     */
    public class FiveCardGame : CardGame
    {
        // Pre-round variables that aren't changed per round
        private int score = 0;
        private Pack PACK = new();
        double answer;

        /*
         * Play method
         * 
         * Starts a game, starting new rounds unless the user requrests otherwise
         */
        public override void Play()
        {
            GameRound();
            bool playAgain = Menus.PlayAgainMenu();
            if (playAgain)
            {
                Play();
            }
            else
            {
                // Add score to leaderboard and return to main menu
                Statistics.AddScore(score);
            }
        }

        /*
         * GameRound override
         * 
         * Handles all aspects of a game round
         * 
         * Every time this function is ran, cards are selected
         * and the question is sent to the user
         */
        protected override void GameRound()
        {
            // SPEC: 5 card presented with maths sum

            // Getting 5 cards
            List<Card> cards = PACK.DealCard(5);

            // Calculating answer
            answer = Calculation.Calculate(cards);

            // Display cards to user
            string cardString = MathsTutor.CombineCards(cards);
            Console.Write(cardString);

            // Get user input
            string input = Console.ReadLine();

            // Requiring correct answer
            while (!double.TryParse(input, out double _))
            {
                Console.Write(cardString);

                input = Console.ReadLine();
            }

            // Informing the user of their answer
            if (double.TryParse(input, out double userguess))
            {
                if (userguess == answer)
                {
                    Console.WriteLine("Correct!");
                    score += 2;
                }
                else
                {
                    Console.WriteLine($"Incorrect! The answer was {answer}");
                }
            }
        }
    }
}