using Repository.ValidationInterface;
using Services.ValidationInterfaces;

namespace Services.ValidationServices
{
    public class IdentificationService : IidentificaciontService
    {
        
        private readonly IidentificationRepository _identificationRepository;

        public IdentificationService(IidentificationRepository identificationRepository)
        {
            _identificationRepository = identificationRepository;
        }

        public async Task<bool> ValidateIdentification(string identificationNumber)
        {
            if (string.IsNullOrWhiteSpace(identificationNumber))
            {
                return false;
            }

            return await _identificationRepository.ValidateExist(identificationNumber);
        }
    }
}
