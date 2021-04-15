using System;
using System.Collections.Generic;
using PokerHandChecker.Application;
using PokerHandChecker.Domain.Enums;
using PokerHandChecker.Domain.Interfaces;

namespace PokerHandChecker.Console
{
    /*
     * 1. Write a class Card implementing the ICard interface. 
     * Implement the properties. Write a constructor. 
     * Implement the ToString() method. 
     * Test all cases.
     * 
     * 2. Write a class Hand implementing the IHand interface. 
     * Implement the properties. Write a constructor. 
     * Implement the ToString() method. 
     * Test all cases.
     */

    internal static class PokerExample
    {
        internal static void Main()
        {
            ICard card = new Card(CardFace.Ace, CardSuit.Clubs);
            System.Console.WriteLine(card);

            IHand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
            });
            System.Console.WriteLine(hand);

            IHand otherHand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
            });
            System.Console.WriteLine(otherHand);

            IPokerHandsChecker checker = new PokerHandsChecker();
            System.Console.WriteLine(checker.IsStraightFlush(hand));
            System.Console.WriteLine(checker.IsStraight(hand));
            System.Console.WriteLine(checker.IsThreeOfAKind(hand));
            System.Console.WriteLine(checker.IsFlush(hand));
            System.Console.WriteLine(checker.IsOnePair(hand));
            System.Console.WriteLine(checker.IsTwoPair(hand));

            System.Console.WriteLine(checker.CompareHands(hand, otherHand));
        }
    }
}