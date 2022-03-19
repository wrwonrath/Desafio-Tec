using CoreBusiness;

namespace UseCases
{
    public interface IViewCardsUseCase
    {
        IEnumerable<Card> Execute();
    }
}