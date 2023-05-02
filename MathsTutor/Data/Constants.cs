using System.Collections.Generic;

namespace MathsTutor

{
    public class Constants
    {
        public static readonly Random random = new();
        public static readonly string cardTemplate =
            " _____ \n" +
            "|X    |\n" +
            "|YYYYY|\n" +
            "|YYYYY|\n" +
            "|YYYYY|\n" +
            "|____X|"
            ;
        public static readonly Dictionary<int, string> cardBitmap = new()
        {
            { 1,  "000000010000000" },
            { 2,  "001000000000100" },
            { 3,  "001000010000100" },
            { 4,  "010100000001010" },
            { 5,  "010100010001010" },
            { 6,  "010100101001010" },
            { 7,  "010101010101010" },
            { 8,  "101010010101010" },
            { 9,  "101011010110101" },
            { 10, "010101111101010" },
            { 11, "011101111101110" },
            { 12, "111100111111110" },
            { 13, "011101111111111" }
        };
    }
}