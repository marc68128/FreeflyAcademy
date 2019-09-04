using System;

namespace FreeflyAcademy.Dtos
{
    public abstract class ProgressSheetModuleDto
    {
        public bool Validated { get; set; }
        public DateTime? ValidationDate { get; set; }
        public string Coach { get; set; }
    }
}