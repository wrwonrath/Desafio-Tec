using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ICardRepository
    {
        IEnumerable<Card> GetCards();

        Card AddCard(CardDto card);

        Card UpdateCard(Guid cardId, CardDto card);

        Card GetCardById(Guid cardId);

        void DeleteCard(Guid cardId);
    }
}
