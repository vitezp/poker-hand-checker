using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandChecker.Application;
using PokerHandChecker.Domain.Enums;
using PokerHandChecker.Domain.Interfaces;

namespace PokerHandChecker.Tests;

[TestClass]
public sealed class IsValidHandMethod
{
    private readonly IPokerHandsChecker sut = new PokerHandsChecker();

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnHandWithNoCards()
    {
        var handWithNoCards = new Hand(new List<ICard>());
        var expected = false;
        var actual = sut.IsValidHand(handWithNoCards);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnHandWithFiveDifferentCards()
    {
        var handWithFiveDifferentCards = new Hand(new List<ICard>()
        {
            new Card(CardFace.Ten, CardSuit.Clubs),
            new Card(CardFace.Seven, CardSuit.Diamonds),
            new Card(CardFace.Ace, CardSuit.Hearts),
            new Card(CardFace.Two, CardSuit.Spades),
            new Card(CardFace.Eight, CardSuit.Diamonds)
        });

        var expected = true;
        var actual = sut.IsValidHand(handWithFiveDifferentCards);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnHandWithSixDifferentCards()
    {
        var handWithSixDifferentCards = new Hand(new List<ICard>()
        {
            new Card(CardFace.Ten, CardSuit.Clubs),
            new Card(CardFace.Seven, CardSuit.Diamonds),
            new Card(CardFace.Ace, CardSuit.Hearts),
            new Card(CardFace.Two, CardSuit.Spades),
            new Card(CardFace.Eight, CardSuit.Diamonds),
            new Card(CardFace.Three, CardSuit.Spades)
        });

        var expected = false;
        var actual = sut.IsValidHand(handWithSixDifferentCards);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnHandWithTwoEqualCards()
    {
        var handWithTwoEqualCard = new Hand(new List<ICard>()
        {
            new Card(CardFace.Ten, CardSuit.Clubs),
            new Card(CardFace.Ten, CardSuit.Clubs),
            new Card(CardFace.Ace, CardSuit.Hearts),
            new Card(CardFace.Two, CardSuit.Spades),
            new Card(CardFace.Eight, CardSuit.Diamonds)
        });

        var expected = false;
        var actual = sut.IsValidHand(handWithTwoEqualCard);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnHandWithFiveEqualCards()
    {
        var handWithFiveEqualCards = new Hand(new List<ICard>()
        {
            new Card(CardFace.Ten, CardSuit.Clubs),
            new Card(CardFace.Ten, CardSuit.Clubs),
            new Card(CardFace.Ten, CardSuit.Clubs),
            new Card(CardFace.Ten, CardSuit.Clubs),
            new Card(CardFace.Ten, CardSuit.Clubs)
        });

        var expected = false;
        var actual = sut.IsValidHand(handWithFiveEqualCards);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnHandWithTwoEqualPairOfCards()
    {
        var handWithTwoEqualPairOfCards = new Hand(new List<ICard>()
        {
            new Card(CardFace.Ten, CardSuit.Clubs),
            new Card(CardFace.Ten, CardSuit.Clubs),
            new Card(CardFace.Ace, CardSuit.Hearts),
            new Card(CardFace.Ace, CardSuit.Hearts),
            new Card(CardFace.Eight, CardSuit.Diamonds)
        });

        var expected = false;
        var actual = sut.IsValidHand(handWithTwoEqualPairOfCards);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnHandWithTwoEqualOfFourCards()
    {
        var handWithTwoEqualOfFourCards = new Hand(new List<ICard>()
        {
            new Card(CardFace.Ten, CardSuit.Clubs),
            new Card(CardFace.Ace, CardSuit.Hearts),
            new Card(CardFace.Ace, CardSuit.Hearts),
            new Card(CardFace.Eight, CardSuit.Diamonds)
        });

        var expected = false;
        var actual = sut.IsValidHand(handWithTwoEqualOfFourCards);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnHandWithTwoEqualOfSixCards()
    {
        var handWithTwoEqualOfSixCards = new Hand(new List<ICard>()
        {
            new Card(CardFace.Ten, CardSuit.Clubs),
            new Card(CardFace.Ten, CardSuit.Clubs),
            new Card(CardFace.Seven, CardSuit.Diamonds),
            new Card(CardFace.Ace, CardSuit.Hearts),
            new Card(CardFace.Two, CardSuit.Spades),
            new Card(CardFace.Eight, CardSuit.Diamonds)
        });

        var expected = false;
        var actual = sut.IsValidHand(handWithTwoEqualOfSixCards);
        Assert.AreEqual(expected, actual);
    }
}