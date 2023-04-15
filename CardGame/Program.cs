using CardGame.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
});

ILogger<Program> logger = loggerFactory.CreateLogger<Program>();
ILogger<Deck> deckLogger = loggerFactory.CreateLogger<Deck>();

Deck deck = new Deck(deckLogger);
deck.Shuffle();

for (int i = 0; i < 52; i++)
{
    Card card = deck.DealOneCard();
    if (card != null)
    {
        Console.WriteLine("{0} of {1}", card.Rank, card.Suit);
    }
    else
    {
        Console.WriteLine("No more cards left in the deck.");
    }
}