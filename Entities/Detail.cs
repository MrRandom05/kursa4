﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika4Kurs.Entities
{
    public class Detail
    {
        public int DetailId { get; set; }
        public string DetailName { get; set; }
        [NotMapped]
        public int Count { get; set; }
    }
}
