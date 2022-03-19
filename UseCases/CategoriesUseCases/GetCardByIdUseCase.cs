using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class GetCardByIdUseCase : IGetCardByIdUseCase
    {
        private readonly ICardRepository cardRepository;

        public GetCardByIdUseCase(ICardRepository cardRepository)
        {
            this.cardRepository = cardRepository;
        }

        public Card Execute(Guid cardId)
        {
            return cardRepository.GetCardById(cardId);
        }
    }
}
