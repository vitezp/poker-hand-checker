using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandChecker.Application;
using PokerHandChecker.Domain.Enums;
using PokerHandChecker.Domain.Interfaces;
using PokerHandChecker.Domain.Models;

namespace PokerHandChecker.Tests;

[TestClass]
public sealed class CompareHandsMethod
{
    private readonly IPokerHandsChecker sut = new PokerHandsChecker();

    private const int LeftIsBigger = 1;
    private const int RightIsBigger = -1;

    #region [Some type of hands - examples]
        
    private readonly IHand handWithNoCards = new Hand(new List<ICard>());

    private readonly IHand handWithHighCard = new Hand(new List<ICard>()
    {
        new Card(CardFace.Ace, CardSuit.Spades),
        new Card(CardFace.King, CardSuit.Diamonds),
        new Card(CardFace.Queen, CardSuit.Clubs),
        new Card(CardFace.Ten, CardSuit.Spades),
        new Card(CardFace.Two, CardSuit.Spades),
    });

    private readonly IHand handWithOnePair = new Hand(new List<ICard>()
    {
        new Card(CardFace.Two, CardSuit.Clubs),
        new Card(CardFace.Two, CardSuit.Diamonds),
        new Card(CardFace.Seven, CardSuit.Spades),
        new Card(CardFace.Nine, CardSuit.Clubs),
        new Card(CardFace.Ten, CardSuit.Clubs),
    });

    private readonly IHand handWithTwoPair = new Hand(new List<ICard>()
    {
        new Card(CardFace.King, CardSuit.Diamonds),
        new Card(CardFace.King, CardSuit.Clubs),
        new Card(CardFace.Nine, CardSuit.Hearts),
        new Card(CardFace.Nine, CardSuit.Diamonds),
        new Card(CardFace.Ace, CardSuit.Spades),
    });

    private readonly IHand handWithThreeOfAKind = new Hand(new List<ICard>()
    {
        new Card(CardFace.Three, CardSuit.Clubs),
        new Card(CardFace.Three, CardSuit.Spades),
        new Card(CardFace.Three, CardSuit.Hearts),
        new Card(CardFace.Seven, CardSuit.Clubs),
        new Card(CardFace.Ace, CardSuit.Clubs),
    });

    private readonly IHand handWithStraight = new Hand(new List<ICard>()
    {
        new Card(CardFace.Five, CardSuit.Clubs),
        new Card(CardFace.Six, CardSuit.Spades),
        new Card(CardFace.Seven, CardSuit.Diamonds),
        new Card(CardFace.Eight, CardSuit.Spades),
        new Card(CardFace.Nine, CardSuit.Clubs)
    });

    private readonly IHand handWithFlush = new Hand(new List<ICard>()
    {
        new Card(CardFace.Ten, CardSuit.Hearts),
        new Card(CardFace.Seven, CardSuit.Hearts),
        new Card(CardFace.Ace, CardSuit.Hearts),
        new Card(CardFace.Two, CardSuit.Hearts),
        new Card(CardFace.Eight, CardSuit.Hearts)
    });

    private readonly IHand handWithFullHouse = new Hand(new List<ICard>()
    {
        new Card(CardFace.Four, CardSuit.Clubs),
        new Card(CardFace.Four, CardSuit.Diamonds),
        new Card(CardFace.Four, CardSuit.Hearts),
        new Card(CardFace.King, CardSuit.Hearts),
        new Card(CardFace.King, CardSuit.Spades),
    });

    private readonly IHand handWithFourOfAKind = new Hand(new List<ICard>()
    {
        new Card(CardFace.Jack, CardSuit.Clubs),
        new Card(CardFace.Jack, CardSuit.Diamonds),
        new Card(CardFace.Jack, CardSuit.Hearts),
        new Card(CardFace.Jack, CardSuit.Spades),
        new Card(CardFace.Ace, CardSuit.Diamonds),
    });

    private readonly IHand handWithStraightFlush = new Hand(new List<ICard>()
    {
        new Card(CardFace.Five, CardSuit.Clubs),
        new Card(CardFace.Six, CardSuit.Clubs),
        new Card(CardFace.Seven, CardSuit.Clubs),
        new Card(CardFace.Eight, CardSuit.Clubs),
        new Card(CardFace.Nine, CardSuit.Clubs)
    });

    #endregion 
        
    #region [Tests -> High card vs. other types]

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    [ExpectedException(typeof(InvalidPokerHandException))]
    public void TestOnHighCardАgainstNoCards()
    {
        var actual = sut.CompareHands(handWithHighCard, handWithNoCards);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnHighCardАgainstOnePair()
    {
        var actual = sut.CompareHands(handWithHighCard, handWithOnePair);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnHighCardАgainstTwoPair()
    {
        var handWithTwoPair = new Hand(new List<ICard>()
        {
            new Card(CardFace.King, CardSuit.Spades),
            new Card(CardFace.King, CardSuit.Clubs),
            new Card(CardFace.Nine, CardSuit.Hearts),
            new Card(CardFace.Nine, CardSuit.Diamonds),
            new Card(CardFace.Ace, CardSuit.Hearts),
        });

        var actual = sut.CompareHands(handWithHighCard, handWithTwoPair);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnHighCardАgainstThreeOfAKind()
    {
        var actual = sut.CompareHands(handWithHighCard, handWithThreeOfAKind);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnHighCardАgainstStraight()
    {
        var actual = sut.CompareHands(handWithHighCard, handWithStraight);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnHighCardАgainstFlush()
    {
        var actual = sut.CompareHands(handWithHighCard, handWithFlush);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnHighCardАgainstFullHouse()
    {
        var actual = sut.CompareHands(handWithHighCard, handWithFullHouse);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnHighCardАgainstFourOfAKind()
    {
        var actual = sut.CompareHands(handWithHighCard, handWithFourOfAKind);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnHighCardАgainstStraightFlush()
    {
        var actual = sut.CompareHands(handWithHighCard, handWithStraightFlush);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnHighCardАgainstUpperHighCard_1()
    {
        var handWithUpperHighCard = new Hand(new List<ICard>()
        {
            new Card(CardFace.Ace, CardSuit.Diamonds),
            new Card(CardFace.King, CardSuit.Spades),
            new Card(CardFace.Queen, CardSuit.Spades),
            new Card(CardFace.Jack, CardSuit.Diamonds),
            new Card(CardFace.Three, CardSuit.Spades),
        });

        var actual = sut.CompareHands(handWithHighCard, handWithUpperHighCard);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnHighCardАgainstUpperHighCard_2()
    {
        var handWithUpperHighCard = new Hand(new List<ICard>()
        {
            new Card(CardFace.Ace, CardSuit.Diamonds),
            new Card(CardFace.Ten, CardSuit.Diamonds),
            new Card(CardFace.Nine, CardSuit.Spades),
            new Card(CardFace.Five, CardSuit.Clubs),
            new Card(CardFace.Four, CardSuit.Clubs),
        });

        var handWithLowerHighCard = new Hand(new List<ICard>()
        {
            new Card(CardFace.King, CardSuit.Clubs),
            new Card(CardFace.Queen, CardSuit.Diamonds),
            new Card(CardFace.Jack, CardSuit.Clubs),
            new Card(CardFace.Eight, CardSuit.Hearts),
            new Card(CardFace.Seven, CardSuit.Hearts),
        });

        var actual = sut.CompareHands(handWithLowerHighCard, handWithUpperHighCard);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnHighCardАgainstUpperHighCard_3()
    {
        var handWithUpperHighCard = new Hand(new List<ICard>()
        {
            new Card(CardFace.Ace, CardSuit.Clubs),
            new Card(CardFace.Queen, CardSuit.Clubs),
            new Card(CardFace.Seven, CardSuit.Diamonds),
            new Card(CardFace.Five, CardSuit.Hearts),
            new Card(CardFace.Two, CardSuit.Clubs),
        });

        var handWithLowerHighCard = new Hand(new List<ICard>()
        {
            new Card(CardFace.Ace, CardSuit.Diamonds),
            new Card(CardFace.Ten, CardSuit.Diamonds),
            new Card(CardFace.Nine, CardSuit.Spades),
            new Card(CardFace.Five, CardSuit.Clubs),
            new Card(CardFace.Four, CardSuit.Clubs),
        });

        var actual = sut.CompareHands(handWithUpperHighCard, handWithLowerHighCard);
        Assert.AreEqual(LeftIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnHighCardАgainstLowerHighCard()
    {
        var handWithLowerHighCard = new Hand(new List<ICard>()
        {
            new Card(CardFace.Three, CardSuit.Hearts),
            new Card(CardFace.King, CardSuit.Spades),
            new Card(CardFace.Queen, CardSuit.Hearts),
            new Card(CardFace.Ten, CardSuit.Hearts),
            new Card(CardFace.Eight, CardSuit.Spades),
        });

        var actual = sut.CompareHands(handWithHighCard, handWithLowerHighCard);
        Assert.AreEqual(LeftIsBigger, actual);
    }

    #endregion

    #region [Tests -> One pair vs. other types]

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    [ExpectedException(typeof(InvalidPokerHandException))]
    public void TestOnOnePairАgainstNoCards()
    {
        var actual = sut.CompareHands(handWithOnePair, handWithNoCards);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnOnePairAgainstHighCard()
    {
        var actual = sut.CompareHands(handWithOnePair, handWithHighCard);
        Assert.AreEqual(LeftIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnOnePairАgainstTwoPair()
    {
        var actual = sut.CompareHands(handWithOnePair, handWithTwoPair);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnOnePairАgainstThreeOfAKind()
    {
        var actual = sut.CompareHands(handWithOnePair, handWithThreeOfAKind);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnOnePairАgainstStraight()
    {
        var handWithOnePair = new Hand(new List<ICard>()
        {
            new Card(CardFace.Two, CardSuit.Clubs),
            new Card(CardFace.Two, CardSuit.Diamonds),
            new Card(CardFace.Seven, CardSuit.Spades),
            new Card(CardFace.Nine, CardSuit.Diamonds),
            new Card(CardFace.Ten, CardSuit.Clubs),
        });

        var actual = sut.CompareHands(handWithOnePair, handWithStraight);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnOnePairАgainstFlush()
    {
        var actual = sut.CompareHands(handWithOnePair, handWithFlush);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnOnePairАgainstFullHouse()
    {
        var actual = sut.CompareHands(handWithOnePair, handWithFullHouse);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnOnePairАgainstFourOfAKind()
    {
        var actual = sut.CompareHands(handWithOnePair, handWithFourOfAKind);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnOnePairАgainstStraightFlush()
    {
        var handWithOnePair = new Hand(new List<ICard>()
        {
            new Card(CardFace.Two, CardSuit.Clubs),
            new Card(CardFace.Two, CardSuit.Diamonds),
            new Card(CardFace.Seven, CardSuit.Spades),
            new Card(CardFace.Nine, CardSuit.Diamonds),
            new Card(CardFace.Ten, CardSuit.Clubs),
        });

        var actual = sut.CompareHands(handWithOnePair, handWithStraightFlush);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnOnePairАgainstUpperOnePair_1()
    {
        var handWithUpperOnePair = new Hand(new List<ICard>()
        {
            new Card(CardFace.King, CardSuit.Spades),
            new Card(CardFace.King, CardSuit.Hearts),
            new Card(CardFace.Seven, CardSuit.Hearts),
            new Card(CardFace.Nine, CardSuit.Diamonds),
            new Card(CardFace.Queen, CardSuit.Clubs),
        });

        var actual = sut.CompareHands(handWithOnePair, handWithUpperOnePair);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnOnePairАgainstUpperOnePair_2()
    {
        var handWithUpperOnePair = new Hand(new List<ICard>()
        {
            new Card(CardFace.Ten, CardSuit.Clubs),
            new Card(CardFace.Ten, CardSuit.Spades),
            new Card(CardFace.Six, CardSuit.Spades),
            new Card(CardFace.Four, CardSuit.Hearts),
            new Card(CardFace.Two, CardSuit.Hearts),
        });

        var handWithLowerOnePair = new Hand(new List<ICard>()
        {
            new Card(CardFace.Nine, CardSuit.Hearts),
            new Card(CardFace.Nine, CardSuit.Clubs),
            new Card(CardFace.Ace, CardSuit.Hearts),
            new Card(CardFace.Queen, CardSuit.Diamonds),
            new Card(CardFace.Ten, CardSuit.Diamonds),
        });

        var actual = sut.CompareHands(handWithLowerOnePair, handWithUpperOnePair);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnOnePairАgainstUpperOnePair_3()
    {
        var handWithUpperOnePair = new Hand(new List<ICard>()
        {
            new Card(CardFace.Two, CardSuit.Diamonds),
            new Card(CardFace.Two, CardSuit.Hearts),
            new Card(CardFace.Eight, CardSuit.Spades),
            new Card(CardFace.Five, CardSuit.Clubs),
            new Card(CardFace.Four, CardSuit.Clubs),
        });

        var handWithLowerOnePair = new Hand(new List<ICard>()
        {
            new Card(CardFace.Two, CardSuit.Clubs),
            new Card(CardFace.Two, CardSuit.Spades),
            new Card(CardFace.Eight, CardSuit.Clubs),
            new Card(CardFace.Five, CardSuit.Hearts),
            new Card(CardFace.Three, CardSuit.Hearts),
        });

        var actual = sut.CompareHands(handWithUpperOnePair, handWithLowerOnePair);
        Assert.AreEqual(LeftIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnOnePairАgainstLowerOnePair()
    {
        var handWithUpperOnePair = new Hand(new List<ICard>()
        {
            new Card(CardFace.King, CardSuit.Hearts),
            new Card(CardFace.King, CardSuit.Spades),
            new Card(CardFace.Seven, CardSuit.Hearts),
            new Card(CardFace.Nine, CardSuit.Diamonds),
            new Card(CardFace.Ten, CardSuit.Clubs)
        });

        var handWithLowerOnePair = new Hand(new List<ICard>()
        {
            new Card(CardFace.King, CardSuit.Clubs),
            new Card(CardFace.King, CardSuit.Diamonds),
            new Card(CardFace.Six, CardSuit.Hearts),
            new Card(CardFace.Nine, CardSuit.Spades),
            new Card(CardFace.Ten, CardSuit.Hearts)
        });

        var actual = sut.CompareHands(handWithUpperOnePair, handWithLowerOnePair);
        Assert.AreEqual(LeftIsBigger, actual);
    }

    #endregion

    #region [Tests -> Two pair vs. other types]

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    [ExpectedException(typeof(InvalidPokerHandException))]
    public void TestOnTwoPairАgainstNoCards()
    {
        var actual = sut.CompareHands(handWithTwoPair, handWithNoCards);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnTwoPairAgainstHighCard()
    {
        var handWithTwoPair = new Hand(new List<ICard>()
        {
            new Card(CardFace.King, CardSuit.Spades),
            new Card(CardFace.King, CardSuit.Clubs),
            new Card(CardFace.Nine, CardSuit.Hearts),
            new Card(CardFace.Nine, CardSuit.Diamonds),
            new Card(CardFace.Ace, CardSuit.Hearts),
        });

        var actual = sut.CompareHands(handWithTwoPair, handWithHighCard);
        Assert.AreEqual(LeftIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnTwoPairAgainstOnePair()
    {
        var actual = sut.CompareHands(handWithTwoPair, handWithOnePair);
        Assert.AreEqual(LeftIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnTwoPairАgainstThreeOfAKind()
    {
        var actual = sut.CompareHands(handWithTwoPair, handWithThreeOfAKind);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnTwoPairАgainstStraight()
    {
        var actual = sut.CompareHands(handWithTwoPair, handWithStraight);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnTwoPairАgainstFlush()
    {
        var actual = sut.CompareHands(handWithTwoPair, handWithFlush);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnTwoPairАgainstFullHouse()
    {
        var actual = sut.CompareHands(handWithTwoPair, handWithFullHouse);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnTwoPairАgainstFourOfAKind()
    {
        var actual = sut.CompareHands(handWithTwoPair, handWithFourOfAKind);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnTwoPairАgainstStraightFlush()
    {
        var actual = sut.CompareHands(handWithTwoPair, handWithStraightFlush);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnTwoPairАgainstUpperTwoPair_1()
    {
        var handWithUpperTwoPair = new Hand(new List<ICard>()
        {
            new Card(CardFace.Ace, CardSuit.Diamonds),
            new Card(CardFace.Ace, CardSuit.Clubs),
            new Card(CardFace.Nine, CardSuit.Spades),
            new Card(CardFace.Nine, CardSuit.Clubs),
            new Card(CardFace.Seven, CardSuit.Spades),
        });

        var actual = sut.CompareHands(handWithTwoPair, handWithUpperTwoPair);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnTwoPairАgainstUpperTwoPair_2()
    {
        var handWithUpperTwoPair = new Hand(new List<ICard>()
        {
            new Card(CardFace.King, CardSuit.Hearts),
            new Card(CardFace.King, CardSuit.Diamonds),
            new Card(CardFace.Two, CardSuit.Clubs),
            new Card(CardFace.Two, CardSuit.Diamonds),
            new Card(CardFace.Jack, CardSuit.Hearts),
        });

        var handWithLowerTwoPair = new Hand(new List<ICard>()
        {
            new Card(CardFace.Jack, CardSuit.Diamonds),
            new Card(CardFace.Jack, CardSuit.Spades),
            new Card(CardFace.Ten, CardSuit.Spades),
            new Card(CardFace.Ten, CardSuit.Clubs),
            new Card(CardFace.Nine, CardSuit.Spades),
        });

        var actual = sut.CompareHands(handWithLowerTwoPair, handWithUpperTwoPair);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnTwoPairАgainstUpperTwoPair_3()
    {
        var handWithUpperTwoPair = new Hand(new List<ICard>()
        {
            new Card(CardFace.Nine, CardSuit.Clubs),
            new Card(CardFace.Nine, CardSuit.Diamonds),
            new Card(CardFace.Five, CardSuit.Diamonds),
            new Card(CardFace.Five, CardSuit.Spades),
            new Card(CardFace.King, CardSuit.Hearts),
        });

        var handWithLowerTwoPair = new Hand(new List<ICard>()
        {
            new Card(CardFace.Four, CardSuit.Hearts),
            new Card(CardFace.Four, CardSuit.Spades),
            new Card(CardFace.Three, CardSuit.Hearts),
            new Card(CardFace.Three, CardSuit.Diamonds),
            new Card(CardFace.King, CardSuit.Clubs),
        });

        var actual = sut.CompareHands(handWithUpperTwoPair, handWithLowerTwoPair);
        Assert.AreEqual(LeftIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnTwoPairАgainstUpperTwoPair_4()
    {
        var handWithUpperTwoPair = new Hand(new List<ICard>()
        {
            new Card(CardFace.Five, CardSuit.Diamonds),
            new Card(CardFace.Five, CardSuit.Spades),
            new Card(CardFace.Nine, CardSuit.Clubs),
            new Card(CardFace.Nine, CardSuit.Diamonds),
            new Card(CardFace.King, CardSuit.Hearts),
        });

        var handWithLowerTwoPair = new Hand(new List<ICard>()
        {
            new Card(CardFace.Six, CardSuit.Hearts),
            new Card(CardFace.Six, CardSuit.Spades),
            new Card(CardFace.Three, CardSuit.Hearts),
            new Card(CardFace.Three, CardSuit.Diamonds),
            new Card(CardFace.King, CardSuit.Clubs),
        });

        var actual = sut.CompareHands(handWithUpperTwoPair, handWithLowerTwoPair);
        Assert.AreEqual(LeftIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnTwoPairАgainstLowerTwoPair()
    {
        var handWithUpperTwoPair = new Hand(new List<ICard>()
        {
            new Card(CardFace.Four, CardSuit.Spades),
            new Card(CardFace.Four, CardSuit.Clubs),
            new Card(CardFace.Three, CardSuit.Spades),
            new Card(CardFace.Three, CardSuit.Hearts),
            new Card(CardFace.King, CardSuit.Diamonds)
        });

        var handWithLowerTwoPair = new Hand(new List<ICard>()
        {
            new Card(CardFace.Four, CardSuit.Hearts),
            new Card(CardFace.Four, CardSuit.Diamonds),
            new Card(CardFace.Three, CardSuit.Diamonds),
            new Card(CardFace.Three, CardSuit.Clubs),
            new Card(CardFace.Ten, CardSuit.Spades)
        });

        var actual = sut.CompareHands(handWithUpperTwoPair, handWithLowerTwoPair);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    #endregion

    #region [Tests -> Three of a kind vs. other types]
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    [ExpectedException(typeof(InvalidPokerHandException))]
    public void TestOnThreeOfAKindАgainstNoCards()
    {
        var actual = sut.CompareHands(handWithThreeOfAKind, handWithNoCards);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnThreeOfAKindAgainstHighCard()
    {
        var actual = sut.CompareHands(handWithThreeOfAKind, handWithHighCard);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnThreeOfAKindAgainstOnePair()
    {
        var actual = sut.CompareHands(handWithThreeOfAKind, handWithOnePair);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnThreeOfAKindАgainstTwoPair()
    {
        var actual = sut.CompareHands(handWithThreeOfAKind, handWithTwoPair);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnThreeOfAKindАgainstStraight()
    {
        var actual = sut.CompareHands(handWithThreeOfAKind, handWithStraight);
        Assert.AreEqual(RightIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnThreeOfAKindАgainstFlush()
    {
        var actual = sut.CompareHands(handWithThreeOfAKind, handWithFlush);
        Assert.AreEqual(RightIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnThreeOfAKindАgainstFullHouse()
    {
        var actual = sut.CompareHands(handWithThreeOfAKind, handWithFullHouse);
        Assert.AreEqual(RightIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnThreeOfAKindАgainstFourOfAKind()
    {
        var actual = sut.CompareHands(handWithThreeOfAKind, handWithFourOfAKind);
        Assert.AreEqual(RightIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnThreeOfAKindАgainstStraightFlush()
    {
        var handWithThreeOfAKind = new Hand(new List<ICard>()
        {
            new Card(CardFace.Seven, CardSuit.Spades),
            new Card(CardFace.Seven, CardSuit.Diamonds),
            new Card(CardFace.Seven, CardSuit.Hearts),
            new Card(CardFace.Eight, CardSuit.Diamonds),
            new Card(CardFace.Ace, CardSuit.Spades),
        });

        var actual = sut.CompareHands(handWithThreeOfAKind, handWithStraightFlush);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnThreeOfAKindАgainstUpperThreeOfAKind()
    {
        var handWithUpperThreeOfAKind = new Hand(new List<ICard>()
        {
            new Card(CardFace.Seven, CardSuit.Spades),
            new Card(CardFace.Seven, CardSuit.Diamonds),
            new Card(CardFace.Seven, CardSuit.Hearts),
            new Card(CardFace.Eight, CardSuit.Diamonds),
            new Card(CardFace.Ace, CardSuit.Spades),
        });

        var actual = sut.CompareHands(handWithThreeOfAKind, handWithUpperThreeOfAKind);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnThreeOfAKindАgainstLowerThreeOfAKind()
    {
        var handWithLowerThreeOfAKind = new Hand(new List<ICard>()
        {
            new Card(CardFace.Two, CardSuit.Clubs),
            new Card(CardFace.Two, CardSuit.Diamonds),
            new Card(CardFace.Two, CardSuit.Hearts),
            new Card(CardFace.Seven, CardSuit.Diamonds),
            new Card(CardFace.Ace, CardSuit.Spades),
        });

        var actual = sut.CompareHands(handWithThreeOfAKind, handWithLowerThreeOfAKind);
        Assert.AreEqual(LeftIsBigger, actual);
    }

    #endregion
        
    #region [Tests -> Straight vs. other types]

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    [ExpectedException(typeof(InvalidPokerHandException))]
    public void TestOnStraightАgainstNoCards()
    {
        var actual = sut.CompareHands(handWithStraight, handWithNoCards);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnStraightAgainstHighCard()
    {
        var actual = sut.CompareHands(handWithStraight, handWithHighCard);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnStraightAgainstOnePair()
    {
        var handWithStraight = new Hand(new List<ICard>()
        {
            new Card(CardFace.Five, CardSuit.Diamonds),
            new Card(CardFace.Six, CardSuit.Spades),
            new Card(CardFace.Seven, CardSuit.Diamonds),
            new Card(CardFace.Eight, CardSuit.Spades),
            new Card(CardFace.Nine, CardSuit.Hearts)
        });

        var actual = sut.CompareHands(handWithStraight, handWithOnePair);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnStraightАgainstTwoPair()
    {
        var actual = sut.CompareHands(handWithStraight, handWithTwoPair);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnStraightАgainstThreeOfAKind()
    {
        var actual = sut.CompareHands(handWithStraight, handWithThreeOfAKind);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnStraightАgainstFlush()
    {
        var actual = sut.CompareHands(handWithStraight, handWithFlush);
        Assert.AreEqual(RightIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnStraightАgainstFullHouse()
    {
        var actual = sut.CompareHands(handWithStraight, handWithFullHouse);
        Assert.AreEqual(RightIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnStraightАgainstFourOfAKind()
    {
        var actual = sut.CompareHands(handWithStraight, handWithFourOfAKind);
        Assert.AreEqual(RightIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnStraightАgainstStraightFlush()
    {
        var handWithStraight = new Hand(new List<ICard>()
        {
            new Card(CardFace.Five, CardSuit.Diamonds),
            new Card(CardFace.Six, CardSuit.Spades),
            new Card(CardFace.Seven, CardSuit.Diamonds),
            new Card(CardFace.Eight, CardSuit.Spades),
            new Card(CardFace.Nine, CardSuit.Hearts)
        });

        var actual = sut.CompareHands(handWithStraight, handWithStraightFlush);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnStraightАgainstUpperStraight()
    {
        var handWithUpperStraight = new Hand(new List<ICard>()
        {
            new Card(CardFace.Six, CardSuit.Diamonds),
            new Card(CardFace.Seven, CardSuit.Hearts),
            new Card(CardFace.Eight, CardSuit.Diamonds),
            new Card(CardFace.Nine, CardSuit.Spades),
            new Card(CardFace.Ten, CardSuit.Clubs)
        });

        var actual = sut.CompareHands(handWithStraight, handWithUpperStraight);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnStraightАgainstLowerStraight()
    {
        var handWithLowerStraight = new Hand(new List<ICard>()
        {
            new Card(CardFace.Four, CardSuit.Diamonds),
            new Card(CardFace.Five, CardSuit.Hearts),
            new Card(CardFace.Six, CardSuit.Diamonds),
            new Card(CardFace.Seven, CardSuit.Clubs),
            new Card(CardFace.Eight, CardSuit.Clubs)
        });

        var actual = sut.CompareHands(handWithStraight, handWithLowerStraight);
        Assert.AreEqual(LeftIsBigger, actual);
    }

    #endregion
        
    #region [Tests -> Flush vs. other types]

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    [ExpectedException(typeof(InvalidPokerHandException))]
    public void TestOnFlushАgainstNoCards()
    {
        var actual = sut.CompareHands(handWithFlush, handWithNoCards);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFlushAgainstHighCard()
    {
        var actual = sut.CompareHands(handWithFlush, handWithHighCard);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFlushAgainstOnePair()
    {
        var actual = sut.CompareHands(handWithFlush, handWithOnePair);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFlushАgainstTwoPair()
    {
        var actual = sut.CompareHands(handWithFlush, handWithTwoPair);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFlushАgainstThreeOfAKind()
    {
        var actual = sut.CompareHands(handWithFlush, handWithThreeOfAKind);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFlushАgainstStraight()
    {
        var actual = sut.CompareHands(handWithFlush, handWithStraight);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFlushАgainstFullHouse()
    {
        var actual = sut.CompareHands(handWithFlush, handWithFullHouse);
        Assert.AreEqual(RightIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFlushАgainstFourOfAKind()
    {
        var actual = sut.CompareHands(handWithFlush, handWithFourOfAKind);
        Assert.AreEqual(RightIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFlushАgainstStraightFlush()
    {
        var actual = sut.CompareHands(handWithFlush, handWithStraightFlush);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFlushАgainstUpperFlush_1()
    {
        var handWithUpperFlush = new Hand(new List<ICard>()
        {
            new Card(CardFace.King, CardSuit.Spades),
            new Card(CardFace.Seven, CardSuit.Spades),
            new Card(CardFace.Ace, CardSuit.Spades),
            new Card(CardFace.Two, CardSuit.Spades),
            new Card(CardFace.Eight, CardSuit.Spades)
        });

        var actual = sut.CompareHands(handWithFlush, handWithUpperFlush);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFlushАgainstUpperFlush_2()
    {
        var handWithUpperFlush = new Hand(new List<ICard>()
        {
            new Card(CardFace.Ace, CardSuit.Hearts),
            new Card(CardFace.Queen, CardSuit.Hearts),
            new Card(CardFace.Ten, CardSuit.Hearts),
            new Card(CardFace.Five, CardSuit.Hearts),
            new Card(CardFace.Three, CardSuit.Hearts)
        });

        var handWithLowerFlush = new Hand(new List<ICard>()
        {
            new Card(CardFace.King, CardSuit.Spades),
            new Card(CardFace.Queen, CardSuit.Spades),
            new Card(CardFace.Jack, CardSuit.Spades),
            new Card(CardFace.Nine, CardSuit.Spades),
            new Card(CardFace.Six, CardSuit.Spades)
        });

        var actual = sut.CompareHands(handWithLowerFlush, handWithUpperFlush);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFlushАgainstUpperFlush_3()
    {
        var handWithUpperFlush = new Hand(new List<ICard>()
        {
            new Card(CardFace.Ace, CardSuit.Diamonds),
            new Card(CardFace.King, CardSuit.Diamonds),
            new Card(CardFace.Seven, CardSuit.Diamonds),
            new Card(CardFace.Six, CardSuit.Diamonds),
            new Card(CardFace.Two, CardSuit.Diamonds)
        });

        var handWithLowerFlush = new Hand(new List<ICard>()
        {
            new Card(CardFace.Ace, CardSuit.Hearts),
            new Card(CardFace.Queen, CardSuit.Hearts),
            new Card(CardFace.Ten, CardSuit.Hearts),
            new Card(CardFace.Five, CardSuit.Hearts),
            new Card(CardFace.Three, CardSuit.Hearts)
        });

        var actual = sut.CompareHands(handWithUpperFlush, handWithLowerFlush);
        Assert.AreEqual(LeftIsBigger, actual);
    }

    #endregion
        
    #region [Tests -> Full House vs. other types]

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    [ExpectedException(typeof(InvalidPokerHandException))]
    public void TestOnFullHouseАgainstNoCards()
    {
        var actual = sut.CompareHands(handWithFullHouse, handWithNoCards);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFullHouseAgainstHighCard()
    {
        var actual = sut.CompareHands(handWithFullHouse, handWithHighCard);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFullHouseAgainstOnePair()
    {
        var actual = sut.CompareHands(handWithFullHouse, handWithOnePair);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFullHouseАgainstTwoPair()
    {
        var actual = sut.CompareHands(handWithFullHouse, handWithTwoPair);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFullHouseАgainstThreeOfAKind()
    {
        var actual = sut.CompareHands(handWithFullHouse, handWithThreeOfAKind);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFullHouseАgainstStraight()
    {
        var actual = sut.CompareHands(handWithFullHouse, handWithStraight);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFullHouseАgainstFlush()
    {
        var actual = sut.CompareHands(handWithFullHouse, handWithFlush);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFullHouseАgainstFourOfAKind()
    {
        var actual = sut.CompareHands(handWithFullHouse, handWithFourOfAKind);
        Assert.AreEqual(RightIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFullHouseАgainstStraightFlush()
    {
        var actual = sut.CompareHands(handWithFullHouse, handWithStraightFlush);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFullHouseАgainstUpperFullHouse()
    {
        var handWithUpperFullHouse = new Hand(new List<ICard>()
        {
            new Card(CardFace.Seven, CardSuit.Clubs),
            new Card(CardFace.Seven, CardSuit.Diamonds),
            new Card(CardFace.Seven, CardSuit.Hearts),
            new Card(CardFace.King, CardSuit.Diamonds),
            new Card(CardFace.King, CardSuit.Clubs),
        });

        var actual = sut.CompareHands(handWithFullHouse, handWithUpperFullHouse);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFullHouseАgainstLowerFullHouse()
    {
        var handWithUpperFullHouse = new Hand(new List<ICard>()
        {
            new Card(CardFace.Three, CardSuit.Clubs),
            new Card(CardFace.Three, CardSuit.Diamonds),
            new Card(CardFace.Three, CardSuit.Hearts),
            new Card(CardFace.King, CardSuit.Diamonds),
            new Card(CardFace.King, CardSuit.Clubs),
        });

        var actual = sut.CompareHands(handWithFullHouse, handWithUpperFullHouse);
        Assert.AreEqual(LeftIsBigger, actual);
    }

    #endregion
        
    #region [Tests -> Four of a kind vs. other types]

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    [ExpectedException(typeof(InvalidPokerHandException))]
    public void TestOnFourOfAKindАgainstNoCards()
    {
        var actual = sut.CompareHands(handWithFourOfAKind, handWithNoCards);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFourOfAKindAgainstHighCard()
    {
        var actual = sut.CompareHands(handWithFourOfAKind, handWithHighCard);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFourOfAKindAgainstOnePair()
    {
        var actual = sut.CompareHands(handWithFourOfAKind, handWithOnePair);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFourOfAKindАgainstTwoPair()
    {
        var actual = sut.CompareHands(handWithFourOfAKind, handWithTwoPair);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFourOfAKindАgainstThreeOfAKind()
    {
        var actual = sut.CompareHands(handWithFourOfAKind, handWithThreeOfAKind);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFourOfAKindАgainstStraight()
    {
        var actual = sut.CompareHands(handWithFourOfAKind, handWithStraight);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFourOfAKindАgainstFlush()
    {
        var actual = sut.CompareHands(handWithFourOfAKind, handWithFlush);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFourOfAKindАgainstFullHouse()
    {
        var actual = sut.CompareHands(handWithFourOfAKind, handWithFullHouse);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFourOfAKindАgainstStraightFlush()
    {
        var actual = sut.CompareHands(handWithFourOfAKind, handWithStraightFlush);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFourOfAKindАgainstUpperFourOfAKind()
    {
        var handWithUpperFourOfAKind = new Hand(new List<ICard>()
        {
            new Card(CardFace.King, CardSuit.Clubs),
            new Card(CardFace.King, CardSuit.Diamonds),
            new Card(CardFace.King, CardSuit.Hearts),
            new Card(CardFace.King, CardSuit.Spades),
            new Card(CardFace.Ace, CardSuit.Clubs),
        });

        var actual = sut.CompareHands(handWithFourOfAKind, handWithUpperFourOfAKind);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnFourOfAKindАgainstLowerFourOfAKind()
    {
        var handWithLowerFourOfAKind = new Hand(new List<ICard>()
        {
            new Card(CardFace.Five, CardSuit.Clubs),
            new Card(CardFace.Five, CardSuit.Diamonds),
            new Card(CardFace.Five, CardSuit.Hearts),
            new Card(CardFace.Five, CardSuit.Spades),
            new Card(CardFace.Ace, CardSuit.Clubs),
        });

        var actual = sut.CompareHands(handWithFourOfAKind, handWithLowerFourOfAKind);
        Assert.AreEqual(LeftIsBigger, actual);
    }

    #endregion
        
    #region [Tests -> Straight Flush vs. other types]

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    [ExpectedException(typeof(InvalidPokerHandException))]
    public void TestOnStraightFlushАgainstNoCards()
    {
        var actual = sut.CompareHands(handWithStraightFlush, handWithNoCards);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnStraightFlushAgainstHighCard()
    {
        var actual = sut.CompareHands(handWithStraightFlush, handWithHighCard);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnStraightFlushAgainstOnePair()
    {
        var handWithOnePair = new Hand(new List<ICard>()
        {
            new Card(CardFace.Two, CardSuit.Diamonds),
            new Card(CardFace.Two, CardSuit.Hearts),
            new Card(CardFace.Seven, CardSuit.Hearts),
            new Card(CardFace.Nine, CardSuit.Hearts),
            new Card(CardFace.Ten, CardSuit.Hearts),
        });

        var actual = sut.CompareHands(handWithStraightFlush, handWithOnePair);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnStraightFlushАgainstTwoPair()
    {
        var actual = sut.CompareHands(handWithStraightFlush, handWithTwoPair);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnStraightFlushАgainstThreeOfAKind()
    {
        var handWithStraightFlush = new Hand(new List<ICard>()
        {
            new Card(CardFace.Six, CardSuit.Spades),
            new Card(CardFace.Seven, CardSuit.Spades),
            new Card(CardFace.Eight, CardSuit.Spades),
            new Card(CardFace.Nine, CardSuit.Spades),
            new Card(CardFace.Ten, CardSuit.Spades)
        });

        var actual = sut.CompareHands(handWithStraightFlush, handWithThreeOfAKind);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnStraightFlushАgainstStraight()
    {
        var handWithStraight = new Hand(new List<ICard>()
        {
            new Card(CardFace.Five, CardSuit.Diamonds),
            new Card(CardFace.Six, CardSuit.Spades),
            new Card(CardFace.Seven, CardSuit.Diamonds),
            new Card(CardFace.Eight, CardSuit.Spades),
            new Card(CardFace.Nine, CardSuit.Spades)
        });

        var actual = sut.CompareHands(handWithStraightFlush, handWithStraight);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnStraightFlushАgainstFlush()
    {
        var actual = sut.CompareHands(handWithStraightFlush, handWithFlush);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnStraightFlushАgainstFullHouse()
    {
        var actual = sut.CompareHands(handWithStraightFlush, handWithFullHouse);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnStraightFlushАgainstFourOfAKind()
    {
        var actual = sut.CompareHands(handWithStraightFlush, handWithFourOfAKind);
        Assert.AreEqual(LeftIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnStraightFlushАgainstUpperStraightFlush()
    {
        var handWithUpperStraightFlush = new Hand(new List<ICard>()
        {
            new Card(CardFace.Six, CardSuit.Spades),
            new Card(CardFace.Seven, CardSuit.Spades),
            new Card(CardFace.Eight, CardSuit.Spades),
            new Card(CardFace.Nine, CardSuit.Spades),
            new Card(CardFace.Ten, CardSuit.Spades)
        });

        var actual = sut.CompareHands(handWithStraightFlush, handWithUpperStraightFlush);
        Assert.AreEqual(RightIsBigger, actual);
    }

    [TestMethod]
    [Description("Test on PokerHandsChecker.cs")]
    public void TestOnStraightFlushАgainstLowerStraightFlush()
    {
        var handWithLowerStraightFlush = new Hand(new List<ICard>()
        {
            new Card(CardFace.Four, CardSuit.Diamonds),
            new Card(CardFace.Five, CardSuit.Diamonds),
            new Card(CardFace.Six, CardSuit.Diamonds),
            new Card(CardFace.Seven, CardSuit.Diamonds),
            new Card(CardFace.Eight, CardSuit.Diamonds),
        });

        var actual = sut.CompareHands(handWithStraightFlush, handWithLowerStraightFlush);
        Assert.AreEqual(LeftIsBigger, actual);
    }
        
    #endregion
}