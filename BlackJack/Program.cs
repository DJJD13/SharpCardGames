using BlackJack.Models;
using CodeHelpers;


Console.WriteLine("Welcome to JD's Blackjack!");
Console.WriteLine("Press any key to get started.");
Console.ReadKey();
Console.WriteLine("Getting everything ready...");

var game = new BlackjackGame();

var keepPlayingFlag = true;

Thread.Sleep(2000);

while (keepPlayingFlag)
{
    game.RunGame();
    Console.WriteLine("Play Again?");
    var keepPlayingKey = InputHelpers.GetAllowedCharsFromConsole(['Y', 'N']);
    keepPlayingFlag = keepPlayingKey == 'Y';
}
Console.WriteLine("Thank you for playing JD's Blackjack!");
Thread.Sleep(2000);