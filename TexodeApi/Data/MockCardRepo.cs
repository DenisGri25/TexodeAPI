using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TexodeApi.Models;

namespace TexodeApi.Data
{
    public class MockCardRepo : ICardRepo
    {
        public IEnumerable<Card> GetAllCards()
        {
            var cards = new List<Card>()
            {
                new Card {Id = 0, CardName = "first", Image = "firstI"},
                new Card {Id = 1, CardName = "second", Image = "secondI"},
                new Card {Id = 2, CardName = "third", Image = "thirdI"}
            };

            return cards;
        }

        public Card GetCardById(int id)
        {
            return new Card { Id = 0, CardName = "lgl", Image = "ll" };
        }

        public void CreateCard(Card crd)
        {
            if (crd == null)
            {
                throw new ArgumentException(nameof(crd));
            }

            var card = new Card();
        }

        public void UpdateCard(Card crd)
        {
        }

        public void DeleteCard(Card crd)
        {
        }
    }
}