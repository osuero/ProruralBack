using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EntityInterfaces
{
    public interface IFinancingGroupService
    {
        Task<FinancingGroup> GetFinancingGroupByIdAsync(Guid id);
        Task<IEnumerable<FinancingGroup>> GetAllFinancingGroupsAsync();
        Task AddFinancingGroupAsync(FinancingGroup financingGroup);
        Task UpdateFinancingGroupAsync(FinancingGroup financingGroup);
        Task DeleteFinancingGroupAsync(Guid id);
    }
}
