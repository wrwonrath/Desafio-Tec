using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class EditCardUseCase : IEditCardUseCase
    {
        private readonly ICardRepository cardRepository;

        public EditCardUseCase(ICardRepository cardRepository)
        {
            this.cardRepository = cardRepository;
        }

        public void Execute(Guid cardId, CardDto card)
        {
            cardRepository.UpdateCard(cardId, card);
        }
    }
}
