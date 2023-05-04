using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsTutor
{
    /*
     * Test class
     * 
     * Responsible for handling all tests
     * 
     * NOTE: See report for more information
     */
    public class Tests
    {
        public static void RunTests()
        {
            // Pack creation test
            Pack TestPack = new();
            Console.WriteLine("Pack creation test passed");

            // Pack deal test
            TestPack.DealCard(5);
            Console.WriteLine("Pack deal test passed");

            
            List<Card> basicTestPack = new()
            {
                // Card creation test
                // NumberCard creation test
                new NumberCard(Card.SuitType.Spades, 10), // 10
                // OperatorCard creation test
                new OperatorCard(Card.SuitType.Hearts,1), // *
                new NumberCard(Card.SuitType.Spades, 8),  // 8
            }; // 10 * 8 = 80

            Console.WriteLine("Card creation test passed");
            Console.WriteLine("NumberCard creation test passed");
            Console.WriteLine("OperatorCard creation test passed");

            List<Card> advancedTestPack = new()
            {
                new NumberCard(Card.SuitType.Spades, 6), // 6
                new OperatorCard(Card.SuitType.Spades, 1), // +
                new NumberCard(Card.SuitType.Spades, 3),  // 3
                new OperatorCard(Card.SuitType.Hearts,1), // *
                new NumberCard(Card.SuitType.Spades, 10),  // 10

            }; // 6 + 3 * 10 = 36

            // BODMAS test
            double basicAnswer = Calculation.Calculate(basicTestPack);
            Console.WriteLine("BODMAS test passed");

            if (basicAnswer == (double)80)
            {
                Console.WriteLine("Basic Test Passed");
            }
            else
            {
                Console.WriteLine("Basic Test Failed");
            }

            double advancedAnswer = Calculation.Calculate(advancedTestPack);
            if (advancedAnswer == (double)36)
            {
                Console.WriteLine("Advanced Test Passed");
            }
            else
            {
                Console.WriteLine("Advanced Test Failed");
            }
        }

    }
}
