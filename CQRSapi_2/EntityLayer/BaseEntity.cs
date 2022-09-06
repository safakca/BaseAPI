using System;

namespace CQRSapi_2.EntityLayer
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
