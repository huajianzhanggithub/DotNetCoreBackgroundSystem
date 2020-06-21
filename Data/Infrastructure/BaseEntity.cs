using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructure
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public string ModifyUserId { get; set; }
        public DateTime? ModifyTime { get; set; }

        public string CreatorId { get; set; }
        public DateTime? CreateTime { get; set; }

        public void Create(object userId)
        {
            CreatorId = userId.ToString();
            CreateTime = DateTime.Now;
        }

        public void Create(object userId, DateTime createtime)
        {
            CreatorId = userId.ToString();
            CreateTime = createtime;
        }
        public void Modify(object userId)
        {
            ModifyUserId = userId.ToString();
            ModifyTime = DateTime.Now;
        }
        public void Modify(object userId, DateTime modifyTime)
        {
            ModifyUserId = userId.ToString();
            ModifyTime = modifyTime;
        }
    }
}
