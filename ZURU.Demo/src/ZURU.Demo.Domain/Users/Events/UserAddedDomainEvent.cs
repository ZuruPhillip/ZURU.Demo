using System;

namespace ZURU.Demo.Domain
{
    /// <summary>
    /// 领域事件-新用户被创建
    /// </summary>
    public class UserAddedDomainEvent
    {
        /// <summary>
        /// 被创建的用户
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// 用户被创建的时间(UTC)
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}
