using FluentValidation;
using System.Linq;

namespace ZURU.Demo.Application
{
    public class CreateRoleDtoValidator: AbstractValidator<CreateRoleDto>
    {
        public CreateRoleDtoValidator() 
        {
            // 库位编码{0}不存在
            RuleFor(p => p.RoleName).NotEmpty().WithMessage("RoleName不能为空");

            RuleFor(p => p.Desc)
                .Must(value=>!string.IsNullOrWhiteSpace(value) && value.Length<=128)
                .WithMessage("Desc不能为空，且长度不能超过128");

            RuleFor(p => p.PermissionCodes)
                .Must(value => value != null && value.Any())
                .WithMessage("角色的权限不能为空");
        }
    }
}
