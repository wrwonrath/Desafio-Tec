using CoreBusiness;

namespace UseCases
{
    public interface IEditCardUseCase
    {
        void Execute(Guid cardId, CardDto card);
    }
}