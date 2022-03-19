using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class DeleteCardUseCase : IDeleteCardUseCase
    {
        private readonly ICardRepository cardRepository;

        public DeleteCardUseCase(ICardRepository cardRepository)
        {
            this.cardRepository = cardRepository;
        }

        public void Delete(Guid cardId)
        {
            cardRepository.DeleteCard(cardId);
        }
    }
}
