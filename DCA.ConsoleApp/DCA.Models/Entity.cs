using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCA.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? DeleteDate { get; set; }
        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
