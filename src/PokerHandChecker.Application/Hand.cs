using System;
using System.Collections.Generic;
using PokerHandChecker.Domain.Interfaces;

namespace PokerHandChecker.Application
{
    public class Hand : IHand
    {
        public IEnumerable<ICard> Cards { get; }

        public Hand(IEnumerable<ICard> cards)
        {
            Cards = cards;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}