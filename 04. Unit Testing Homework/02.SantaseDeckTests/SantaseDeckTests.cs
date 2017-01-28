// https://github.com/NikolayIT/SantaseGameEngine/blob/master/Source/Santase.Logic/Cards/Deck.cs
namespace SantaseDeckTests
{
    using System.Collections.Generic;

    using Santase.Logic;
    using Santase.Logic.Cards;

    using NUnit.Framework;

    [TestFixture]
    public class SantaseDeckTests
    {
        Deck deck;

        [SetUp]
        public void SetUpTest()
        {
            deck = new Deck();
        }

        [Test]
        public void TestDeck_CreateDeckCheckCardsLeft_ShouldPass()
        {
            Assert.AreEqual(24, deck.CardsLeft);
        }

        [Test]
        public void TestDeck_CreateDeckCheckCardsLeft_ShouldFail()
        {
            Assert.AreNotEqual(25, deck.CardsLeft);
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(7)]
        public void TestDeck_CheckIfTrumpCardIsDifferentEveryTime_ShouldPass(int rotations)
        {

            List<Card> trumps = new List<Card>();
            for (int i = 0; i < rotations; i++)
            {
                Deck deck = new Deck();
                trumps.Add(deck.TrumpCard);
            }

            bool areTrumpsSame = true;

            for (int i = 1; i < trumps.Count; i++)
            {
                if (trumps[i] != trumps[i-1])
                {
                    areTrumpsSame = false;
                    break;
                }
            }

            Assert.AreEqual(false, areTrumpsSame);
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(7)]
        public void TestDeck_RemoveCardsFromDeck_CheckCount_ShouldPass(int rotations)
        {
            for (int i = 0; i < rotations; i++)
            {
                deck.GetNextCard();
            }

            Assert.AreEqual(24 - rotations, deck.CardsLeft);
        }

        
        [Test]
        public void ChangeTrumpCard_CheckForSameness_ShouldNotBeSame()
        {
            Card oldTrump = deck.TrumpCard;
            if (oldTrump.Suit == CardSuit.Club)
            {
                deck.ChangeTrumpCard(new Card(CardSuit.Heart, CardType.Ace));
            }
            else
            {
                deck.ChangeTrumpCard(new Card(CardSuit.Club, CardType.Ace));
            }
            
            Assert.AreNotEqual(oldTrump, deck.TrumpCard);
        }
    }
}
