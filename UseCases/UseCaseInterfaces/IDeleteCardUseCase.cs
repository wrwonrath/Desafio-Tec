using CoreBusiness;

namespace UseCases
{
    public interface IDeleteCardUseCase
    {
        void Delete(Guid cardId);
    }
}