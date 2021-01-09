using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Basecore.Model
{
    public class BaseEntity :BaseModel
    {
        public BaseEntity()
        {
            UpdatedAt = DateTime.UtcNow;
            CreatedAt = DateTime.UtcNow;
            IsDeleted = false;
            IsActive = true;
        }
        public int ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

    }
}
