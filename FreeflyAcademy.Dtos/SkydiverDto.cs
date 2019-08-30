using System;

namespace FreeflyAcademy.Dtos
{
    public class SkydiverDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool PersonalRig { get; set; }
        public int JumpsCount { get; set; }
        public DateTime? SkydiveStartingDate { get; set; }
        public DateTime? FreeflyStartingDate { get; set; }
        
        public string VideoDirectoryPath { get; set; }
    }
}