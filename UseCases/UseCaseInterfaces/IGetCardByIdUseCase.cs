using CoreBusiness;

namespace UseCases
{
    public interface IGetCardByIdUseCase
    {
        Card Execute(Guid cardId);
    }
}