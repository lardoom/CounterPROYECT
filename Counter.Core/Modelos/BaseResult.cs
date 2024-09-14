﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Core.Modelos
{
    public class BaseResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? ExceptionMessage { get; set; }
    }
}