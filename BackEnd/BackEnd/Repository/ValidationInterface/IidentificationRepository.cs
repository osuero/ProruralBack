namespace Repository.ValidationInterface
{
    public interface IidentificationRepository
    {
        Task<bool> ValidateExist(string id);
    }
}
