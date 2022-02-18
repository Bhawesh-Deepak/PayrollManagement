﻿using HRMS.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Entities.Talent
{
    [Table("AwardType", Schema = "Talent")]
    public class AwardType : BaseModel<int>
    {
        public string Name { get; set; }
    }
}
