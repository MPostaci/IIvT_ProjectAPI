﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Domain.Entities.Common
{
    public class SoftDeleteEntity : BaseEntity, ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}
