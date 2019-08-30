using System;

namespace FreeflyAcademy.Domain
{
    public class Skydiver : Person
    {
        public bool PersonalRig { get; set; }
        public int JumpsCount { get; set; }
        public DateTime? SkydiveStartingDate { get; set; }
        public DateTime? FreeflyStartingDate { get; set; }

        public string VideoDirectoryPath { get; set; }
    }
}