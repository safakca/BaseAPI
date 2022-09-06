using System;

namespace CQRSapi_2.EntityLayer
{
    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
