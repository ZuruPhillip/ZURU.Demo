using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using ZURU.Demo.Domain;

namespace ZURU.Demo.Application
{
    public class PermissionAppService : DemoAppService, IPermissionAppService
    {
        private readonly IRepository<Permission> _repository;
        public PermissionAppService(IRepository<Permission> repository)
        {
            _repository = repository;
        }

        public async Task<PermissionDto> CreateAsync(CreatePermissionDto dto)
        {
            var obj = new Permission(dto.Name,dto.Desc);

            var permission = await _repository.InsertAsync(obj);

            return ObjectMapper.Map<Permission,PermissionDto>(permission);
        }
    }
}
