namespace BlackJack.Models;

public class Deck
{
    private static Random random = new Random();
    private static List<int> cardNums = [2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11];

    public Deck()
    {
        foreach (var suit in Enum.GetValues(typeof(Suit)).Cast<Suit>())
        {
            var cardValsCopy = new List<int>(cardNums);
            var faceCardsAvailable = new List<CardType> { CardType.Jack, CardType.Queen, CardType.King };
            while (cardValsCopy.Count > 0)
            {
                var newCard = new Card(cardValsCopy[random.Next(cardValsCopy.Count)], suit, CardType.None);
                cardValsCopy.Remove(newCard.Value);
                if (newCard.Value >= 10)
                {
                    if (newCard.Value == 11)
                    {
                        newCard.CardType = CardType.Ace; 
                    }
                    else if (faceCardsAvailable.Count > 0)
                    {
                        newCard.CardType = faceCardsAvailable[random.Next(faceCardsAvailable.Count)];
                        faceCardsAvailable.Remove(newCard.CardType);
                    }
                }
                DeckCards.Add(newCard);
            }
        }
    }
    
    private int CurrentCard { get; set; }
    public List<Card> DeckCards { get; set; } = [];

    public Card Deal() => DeckCards[CurrentCard++];
    
    public void PrintDeck()
    {
        foreach (var card in DeckCards)
        {
            Console.WriteLine($"> {card.PrintCard()}");
        }
    }

    public void ShuffleDeck()
    {
        CurrentCard = 0;
        for (var i = 0; i < DeckCards.Count; i++)
        {
            var tempCard = DeckCards[i];
            var tempPosition = random.Next(DeckCards.Count);
            DeckCards[i] = DeckCards[tempPosition];
            DeckCards[tempPosition] = tempCard;
        }
    }
}