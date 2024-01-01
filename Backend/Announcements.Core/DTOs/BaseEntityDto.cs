using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.Core.DTOs
{
    public abstract class BaseEntityDto:BaseDto
    {
        public DateTime  CreatedTime { get; set; }

        public DateTime UpdatedTime { get; set;}
    }
}
