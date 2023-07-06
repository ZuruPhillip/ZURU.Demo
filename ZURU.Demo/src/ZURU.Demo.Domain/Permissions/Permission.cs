using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace ZURU.Demo.Domain
{
    public class Permission: BasicAggregateRoot<Guid>
    {
        /// <summary>
        /// 权限编号
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; private set; }

        private Permission() { }

        public Permission(string name,string desc)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            Name = name;
            Desc = desc;
        }
    }
}
