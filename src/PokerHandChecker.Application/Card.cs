using System;
using PokerHandChecker.Domain.Enums;
using PokerHandChecker.Domain.Interfaces;

namespace PokerHandChecker.Application
{
    public class Card : ICard
    {
        public CardFace Face { get; }
        public CardSuit Suit { get; }

        public Card(CardFace face, CardSuit suit)
        {
            Face = face;
            Suit = suit;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}