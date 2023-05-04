
namespace MathsTutor
{
    /*
     * ICardGame interface
     * 
     * Handles the Play method requirement
     */
    public interface ICardGame
    {
        void Play();
    }

    /*
     * CardGame abstract class
     * 
     * Parent class for FiveCardGame and ThreeCardGame
     */
    public abstract class CardGame : ICardGame
    {
        public abstract void Play();
        protected abstract void GameRound();
    }
}