using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsTutor
{

    public class OperatorCard : Card
    {
        public OperatorCard(SuitType suit, int value) : base(suit, value)
        {
        }

        public override void DrawCard()
        {

        }

        public override int GetValue()
        {
            return (int)Suit;
        }
    }
}
