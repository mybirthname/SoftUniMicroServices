﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Identity.Models
{
    public class ChangePasswordInputModel
    {
        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

    }
}
