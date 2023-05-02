using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsTutor
{

    public class NumberCard : Card
    {
        public NumberCard(SuitType suit, int value) : base(suit, value)
        {
        }

        public override void DrawCard()
        {

        }

        public override int GetValue()
        {
            return Value; // 1-4, corresponding to +-*/
        }
    }
}
