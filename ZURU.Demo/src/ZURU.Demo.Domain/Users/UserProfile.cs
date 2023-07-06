using Volo.Abp.Domain.Values;
using System.Collections.Generic;

namespace ZURU.Demo.Domain
{
    public class UserProfile : ValueObject
    {
        public string Mobile { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }

        private UserProfile() { }

        public UserProfile(string mobile,string email, string address)
        {
            //Check.NotNullOrWhiteSpace(mobile,nameof(mobile));
            //Check.NotNullOrWhiteSpace(email, nameof(email));

            Mobile = mobile;
            Email = email;
            Address = address;
        }

        /// <summary>
        /// 用于返回值对象的所有属性
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetAtomicValues()
        {
            /*
             * 该方法基本是固定写法，就是返回当前值对象的所有属性值，
             * 用于后期值对象之间的比较
             */

            yield return Mobile;
            yield return Email;
            yield return Address;
        }
    }
}
