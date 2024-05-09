using Data.Entities;
using Repository.EtitiyInterfaces;
using Services.EntityInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EntityServices
{
    public class ProjectTypeService : IProjectTypeService
    {
        private readonly IProjectTypeRepository _projectTypeRepository;

        public ProjectTypeService(IProjectTypeRepository projectTypeRepository)
        {
            _projectTypeRepository = projectTypeRepository;
        }

        public async Task<IEnumerable<ProjectType>> GetAllProjectTypesAsync()
        {
            // Here, additional business logic can be applied if necessary
            return await _projectTypeRepository.GetAllAsync();
        }
    }

}
