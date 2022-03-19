using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CardInMemoryRepository : ICardRepository
    {
        private readonly CardContext _context;

        public CardInMemoryRepository(CardContext context)
        {
            _context = context;
        }

        public Card AddCard(CardDto card)
        {
            Guid g = Guid.NewGuid();
            var novoCard = new Card();
            novoCard.Id = g;
            novoCard.Lista = card.Lista;
            novoCard.Conteudo = card.Conteudo;
            novoCard.Titulo = card.Titulo;

            try
            {
                _context.Cards.Add(novoCard);
                _context.SaveChanges();

                return novoCard;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }            

        public Card UpdateCard(Guid cardId, CardDto card)
        {
            var cardToUpdate = GetCardById(cardId);

            try
            {
                if (cardToUpdate != null)
                {
                    cardToUpdate.Titulo = card.Titulo;
                    cardToUpdate.Conteudo = card.Conteudo;
                    cardToUpdate.Lista = card.Lista;
                    _context.Cards.Update(cardToUpdate);
                    _context.SaveChanges();

                    return cardToUpdate;
                }
                else
                {
                    throw new Exception("Card não encontrado");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteCard(Guid cardId)
        {
            var cardToDelete = GetCardById(cardId);

            if (cardToDelete != null)
            {
                _context.Cards.Remove(cardToDelete);
                _context.SaveChanges();
            }
            else
            {
                var ex = new Exception(string.Format("{0} - {1}", "Card não encontrado.", "404"));
                ex.Data.Add("404", "Card não encontrado."); 
                throw ex;
            }
        }

        public IEnumerable<Card> GetCards()
        {
            return _context.Cards;
        }

        public Card GetCardById(Guid cardId)
        {
            return _context.Cards.First(x => x.Id == cardId);
        }
    }
}