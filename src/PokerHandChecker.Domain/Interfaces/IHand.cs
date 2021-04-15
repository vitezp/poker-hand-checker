using System.Collections.Generic;

namespace PokerHandChecker.Domain.Interfaces
{
    public interface IHand
    {
        IEnumerable<ICard> Cards { get; }
        string ToString();
    }
}
