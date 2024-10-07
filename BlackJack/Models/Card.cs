namespace BlackJack.Models;

public class Card
{
    private static Random random = new Random();
    private static readonly List<int> cardValues = [2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11];

    public Card() { }

    public Card(int value, Suit suit, CardType type)
    {
        Value = value;
        Suit = suit;
        CardType = type;
    }
    public int Value { get; set; }
    public Suit Suit { get; set; }
    public CardType CardType { get; set; }

    public bool IsFaceCard() => CardType != CardType.None;

    public string PrintCard() 
        => IsFaceCard() ? $"{CardType.ToString()} of {Suit.ToString()}" : $"{Value} of {Suit.ToString()}";
    
}

public enum Suit
{
    Hearts,
    Spades,
    Clubs,
    Diamonds
}

public enum CardType
{
    None,
    Jack,
    Queen,
    King,
    Ace
}