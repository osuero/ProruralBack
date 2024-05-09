using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ValidationInterfaces
{
    public interface IidentificaciontService
    {
        Task<bool> ValidateIdentification(string identificationNumber);
    }
}
