using System.Collections.Generic;
using TexodeApi.Models;

namespace TexodeApi.Data
{
    public interface ICardRepo
    {
        IEnumerable<Card> GetAllCards();
        Card GetCardById(int id);
        void CreateCard(Card crd);
        void UpdateCard(Card crd);
        void DeleteCard(Card crd);
    }
}