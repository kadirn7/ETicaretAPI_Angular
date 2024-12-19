﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities.Common
{
    public class BaseEntity:IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; }

    }
}
