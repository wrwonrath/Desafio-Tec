using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class ViewCardUseCase : IViewCardsUseCase
    {
        private readonly ICardRepository cardRepository;

        public ViewCardUseCase(ICardRepository cardRepository)
        {
            this.cardRepository = cardRepository;
        }

        public IEnumerable<Card> Execute()
        {
            return cardRepository.GetCards();
        }


    }
}
