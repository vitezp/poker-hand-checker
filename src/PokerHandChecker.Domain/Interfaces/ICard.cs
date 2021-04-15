using PokerHandChecker.Domain.Enums;

namespace PokerHandChecker.Domain.Interfaces
{
    public interface ICard
    {
        CardFace Face { get; }
        CardSuit Suit { get; }
        string ToString();
    }
}
