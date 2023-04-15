using CardGame.Enums;
using CardGame.Utils;
using Microsoft.Extensions.Logging;
using System;

namespace CardGame.Models
{
    internal class Deck
    {
        private readonly List<Card> _cards;
        private readonly ILogger<Deck> _logger;

        public Deck(ILogger<Deck> logger)
        {
            _logger = logger;
            _cards = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    _cards.Add(new Card(suit, rank));
                }
            }
        }

        public void Shuffle()
        {
            int minRange = 1;
            int maxRange = _cards.Count;
            Randomizer _randomizer = new Randomizer();

            try
            {
                int n = _cards.Count;
                while (n > 1)
                {
                    n--;
                    int k = _randomizer.GetRandomNumber(minRange, maxRange);
                    Card card = _cards[k];
                    _cards[k] = _cards[n];
                    _cards[n] = card;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while shuffling the deck");
                throw;
            }
        }

        public Card DealOneCard()
        {
            if (_cards.Count > 0)
            {
                Card card = _cards[0];
                _cards.RemoveAt(0);
                return card;
            }
            else
            {
                _logger.LogWarning("No cards left in the deck");
                return null;
            }
        }
    }
}
