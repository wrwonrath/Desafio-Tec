using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class AddCardUseCase : IAddCardUseCase
    {
        private readonly ICardRepository cardRepository;

        public AddCardUseCase(ICardRepository cardRepository)
        {
            this.cardRepository = cardRepository;
        }

        public void Execute(CardDto card)
        {
            cardRepository.AddCard(card);
        }
    }
}
