﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Security
    {
        public int Id{ get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public int UsersId { get; set; }

    }
}
