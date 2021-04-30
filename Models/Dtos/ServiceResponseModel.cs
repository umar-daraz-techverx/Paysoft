﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techverx.Paysoft.Enums;

namespace Techverx.Paysoft.Models
{
        public class ServiceResponse<T>
        {
            public T Data { get; set; }
            public bool Success { get; set; } = true;
            public String Message { get; set; } = null;
        }
}
