﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.Account
{
    public class UpdatePasswordAccountParam
    {
        public int AccountID { get; set; }
        public string Password { get; set; }
    }
}
