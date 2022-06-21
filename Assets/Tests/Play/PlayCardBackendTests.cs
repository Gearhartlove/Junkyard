using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CardBackendTests {
    
    [UnityTest]
    public IEnumerator DrawSingleCardWorksProperly() {
        var pgo = new GameObject();
        var player = pgo.AddComponent<Player>();
        var card = Card.Create(CardDatabase.CardName.Goblin);

        yield return new WaitForFixedUpdate();

        player.AddCardToDeck(card);
        player.Draw();
        
        Assert.True(player.Hand[0].Equals(card));
    }
    
    [UnityTest]
    public IEnumerator DrawMultipleCardsWorksProperly() {
        var pgo = new GameObject();
        var player = pgo.AddComponent<Player>();
        var cardA = Card.Create(CardDatabase.CardName.Goblin);
        var cardB = Card.Create(CardDatabase.CardName.Goblin);
        
        yield return new WaitForFixedUpdate();
        
        player.AddCardToDeck(cardA);
        player.AddCardToDeck(cardB);
        player.Draw(2);
        
        Assert.True(player.Hand[0].Equals(cardB));
        Assert.True(player.Hand[1].Equals(cardA));
        Assert.True(player.Deck.IsEmpty());
    }
    
    [UnityTest]
    public IEnumerator DrawOverflowWorksProperly() {
        var pgo = new GameObject();
        var player = pgo.AddComponent<Player>();
        var cardA = Card.Create(CardDatabase.CardName.Goblin);
        var cardB = Card.Create(CardDatabase.CardName.Goblin);
        
        yield return new WaitForFixedUpdate();
        
        player.AddCardToDeck(cardA);
        player.AddCardToDeck(cardB);
        player.Draw(10);
        
        Assert.True(player.Hand[0].Equals(cardB));
        Assert.True(player.Hand[1].Equals(cardA));
        Assert.True(player.Deck.IsEmpty());
    }
    
    [UnityTest]
    public IEnumerator HandSizeFullWorksProperly () {
        var pgo = new GameObject();
        var player = pgo.AddComponent<Player>();
        
        yield return new WaitForFixedUpdate();

        while (player.Deck.CardCount != 10) {
            var card = Card.Create(CardDatabase.CardName.Goblin);
            player.AddCardToDeck(card);
        };
        player.Draw(10);
        
        Assert.True(player.Hand.CardCount == player.Hand.MaxHandSize);
        Assert.True(player.Yard.CardCount == 3);
        Assert.True(player.Deck.IsEmpty());
    }
    

    
    [UnityTest]
    public IEnumerator MillOneCardWorksProperly() {
        var pgo = new GameObject();
        var player = pgo.AddComponent<Player>();
        var card = Card.Create(CardDatabase.CardName.Goblin);

        yield return new WaitForFixedUpdate();

        player.AddCardToDeck(card);
        player.Mill();

        Assert.True(player.Yard.Top().Equals(card));
    }

    [UnityTest]
    public IEnumerator MillTwoCardsWorksProperly() {
        var pgo = new GameObject();
        var player = pgo.AddComponent<Player>();
        var card1 = Card.Create(CardDatabase.CardName.Grasslands);
        var card2 = Card.Create(CardDatabase.CardName.Grasslands);

        yield return new WaitForFixedUpdate();

        // Add Cards to Deck
        // Deck Stack (top):    Card2
        //            (bottom): Card1  
        player.AddCardToDeck(card1);
        player.AddCardToDeck(card2);
        // Mill Cards
        // Deck Stack (top):    Card1
        //            (bottom): Card2
        player.Mill(2);
        
        Assert.True(player.Yard.CardCount == 2);
        Assert.True(player.Yard.CardCount == 2);
        Assert.True(player.Deck.IsEmpty());
        Assert.True(player.Deck.IsEmpty());
        Assert.True(player.Yard.Top().Equals(card1));
        Assert.True(player.Yard.Bottom().Equals(card2));
    }

    /// <summary>
    /// The milling of cards must stop when there are no more cards left to mill.
    /// </summary>
    /// <returns></returns>
    [UnityTest]
    public IEnumerator MillOverflowWorksProperly() {
        var pgo = new GameObject();
        var player = pgo.AddComponent<Player>();
        var card1 = Card.Create(CardDatabase.CardName.Grasslands);
        var card2 = Card.Create(CardDatabase.CardName.Grasslands);

        yield return new WaitForFixedUpdate();

        // Add Cards to Deck
        // Deck Stack (top):    Card2
        //            (bottom): Card1  
        player.AddCardToDeck(card1);
        player.AddCardToDeck(card2);
        // Mill Cards
        // Deck Stack (top):    Card1
        //            (bottom): Card2
        player.Mill(10);

        Assert.True(player.Yard.CardCount == 2);
        Assert.True(player.Deck.IsEmpty());
        Assert.True(player.Deck.IsEmpty());
        Assert.True(player.Yard.Top().Equals(card1));
        Assert.True(player.Yard.Bottom().Equals(card2));
    }
    
    // [UnityTest]
    // public IEnumerator ScrySingleCardWorksProperly() {
    //     var pgo = new GameObject();
    //     var player = pgo.AddComponent<Player>();
    //     var card1 = Card.Create(CardDatabase.CardName.Grasslands);
    //     var card2 = Card.Create(CardDatabase.CardName.Grasslands);
    //
    //     yield return new WaitForFixedUpdate();
    //
    //     player.AddCardToDeck(card1);
    //     player.AddCardToDeck(card2);
    // }
    
    [UnityTest]
    public IEnumerator DiscardSingleCardWorksProperly() {
        var pgo = new GameObject();
        var player = pgo.AddComponent<Player>();
        var card = Card.Create(CardDatabase.CardName.Grasslands);

        yield return new WaitForFixedUpdate();
        
        player.AddCardToDeck(card);
        player.Draw();
        player.Discard(0);

        Assert.True(player.Yard.CardCount == 1);
        Assert.True(player.Hand.CardCount == 0);
        Assert.True(player.Yard.Top().Equals(card));
    }
    

}