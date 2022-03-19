using CoreBusiness;

namespace UseCases
{
    public interface IAddCardUseCase
    {
        void Execute(CardDto card);
    }
}