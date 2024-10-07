using CodeHelpers;

namespace BlackJack.Models;

public class BlackjackGame
{
    public BlackjackGame()
    {
        Deck = new Deck();
        Dealer = new Hand("Dealer");
        Player = new Hand("Player");
    }
    
    public void RunGame()
    {
        while (true)
        {
            SetupGame();
            // Edge case for an initial 21 dealt
            if (Player.GetHandValue() == 21)
            {
                if (Dealer.GetHandValue() == 21)
                {
                    Console.WriteLine($"Both you and the dealer have blackjack. It's a push.");
                    break;
                }
                Console.WriteLine("You have a blackjack! You win!");
                break;
            }
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Dealer is showing a {Dealer.Cards[1].PrintCard()}");
            
                Console.WriteLine($"You currently have {Player.GetHandValue()}");
                Console.WriteLine("Would you like to [H]it or [S]tand?");
                var hitOrStand = InputHelpers.GetAllowedCharsFromConsole(['H', 'S']);

                if (hitOrStand == 'H')
                {
                    DealCardToPlayer();
                    if (DidPlayerBust())
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            if (DidPlayerBust())
            {
                Console.WriteLine($"Your hand value is {Player.GetHandValue()}. You busted!");
                break;
            }
        
            Console.WriteLine($"Dealer has {Dealer.GetHandValue()}");

            while (ShouldDealerBeDealt())
            {
                DealCardToDealer();
                Console.WriteLine($"Dealer has {Dealer.GetHandValue()}");
            }

            if (DidDealerBust())
            {
                Console.WriteLine($"Dealer has {Dealer.GetHandValue()}. Dealer busts and you win!");
                break;
            }
            if (Dealer.GetHandValue() > Player.GetHandValue())
            {
                Console.WriteLine($"Dealer has {Dealer.GetHandValue()} to your {Player.GetHandValue()}! Dealer wins!");
                break;
            }

            if (Player.GetHandValue() > Dealer.GetHandValue())
            {
                Console.WriteLine($"You have {Player.GetHandValue()} to the dealer's {Dealer.GetHandValue()}! You win!");
                break;
            }

            if (Player.GetHandValue() == Dealer.GetHandValue())
            {
                Console.WriteLine($"You and the dealer both have {Player.GetHandValue()}. It's a push.");
            }
        }
    }
    
    private Deck Deck { get; set; }
    private Hand Dealer { get; set; }
    private Hand Player { get; set; }

    private void SetupGame()
    {
        Deck.ShuffleDeck();
        Dealer.Cards.Clear();
        Player.Cards.Clear();
        Console.WriteLine("Dealing cards...");
        Thread.Sleep(500);
        Player.Cards.Add(Deck.Deal());
        Console.WriteLine($"You are dealt a {Player.Cards[0].PrintCard()}");
        Thread.Sleep(500);
        Dealer.Cards.Add(Deck.Deal());
        Console.WriteLine("Dealer dealt their first card...");
        Thread.Sleep(500);
        Player.Cards.Add(Deck.Deal());
        Console.WriteLine($"You are dealt a {Player.Cards[1].PrintCard()}");
        Thread.Sleep(500);
        Dealer.Cards.Add(Deck.Deal());
        Console.WriteLine("Dealer dealt their second card...");
    }
    
    private void DealCardToPlayer()
    {
        Player.Cards.Add(Deck.Deal());
        Console.WriteLine($"{Player.PlayerName} dealt a {Player.Cards[^1].PrintCard()}");
    }

    private void DealCardToDealer()
    {
        Dealer.Cards.Add(Deck.Deal());
        Console.WriteLine($"{Dealer.PlayerName} dealt a {Dealer.Cards[^1].PrintCard()}");
    }

    private bool DidPlayerBust()
    {
        return Player.GetHandValue() > 21;
    }

    private bool DidDealerBust()
    {
        return Dealer.GetHandValue() > 21;
    }

    private bool ShouldDealerBeDealt()
    {
        return Dealer.GetHandValue() < 16;
    }
    
}