
namespace MathsTutor.Gameplay
{
    /*
     * Tutorial class
     * 
     * Handles all aspects of the tutorial
     */
    public class Tutorial
    {
        public static void ShowTutorial()
        {
            Console.Clear();
            Console.Write(
                "Welcome to MathsTutor!\n"+
                "----------------------\n"+
                "\n" +
                "MathsTutor is a primary school game to teach students how to add, subtract, multiply, and divide.\n" +
                "In this game you are presented with 2 game modes, here's how the first game mode will work:\n"+
                "\n"+
                "You are given 3 cards. 2 of these cards will be numbers and the other will be an operator (+ - x ÷). For example you may be given the following:\n"+
                "\n" +
                "3 x 5\n" +
                "\n" +
                "To get the correct answer, you must work out what 3 x 5 is and enter it. If you enter the correct answer (15), you score a point.\n" +
                "\n" +
                "The second game mode is more advanced as you are given 5 cards, 3 numbers and 2 operators. You must use BODMAS to calculate the solution. For example you may be given the following:\n" +
                "\n" +
                "3 + 10 * 5\n" +
                "\n" +
                "You must implement BODMAS to get the correct answer of 53. If you get this question right, you score 2 points\n" +
                "\n" +
                "After each round you are given the choice to pull another set of 3/5 cards. If you chose to end the game, your score is shown and stored in statistics.txt.\n" +
                "You are then returned to the main menu\n" +
                "\n" +
                "Press any key to return to the main menu..."
                );

            Console.ReadLine();
            Console.Clear();
        }
    }
}
