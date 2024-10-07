namespace BlackJack.Models;

public class Hand
{
    public Hand()
    {
        PlayerName = "Player";
        anonPlayerNumberCounter++;
    }

    public Hand(string name)
    {
        PlayerName = name;
    }
    public string PlayerName { get; set; }
    public List<Card> Cards { get; set; } = [];

    public int GetHandValue() => Cards.Sum(card => card.Value);

    public void PrintHand()
    {
        Console.WriteLine("Current Hand:");
        foreach (var card in Cards)
        {
            Console.WriteLine("> " + card.PrintCard());
        }
    }

    public static int anonPlayerNumberCounter = 0;
}