﻿using System;

namespace FreeflyAcademy.Domain.Model
{
    public abstract class ModuleProgressSheet
    {
        public bool Validated { get; set; }
        public DateTime? ValidationDate { get; set; }
        public string Coach { get; set; }
    }
}
