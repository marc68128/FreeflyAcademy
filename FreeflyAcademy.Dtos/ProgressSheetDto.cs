namespace FreeflyAcademy.Dtos
{
    public class ProgressSheetDto
    {
        public ProgressSheetDto()
        {
            TrackProgressSheet = new TrackProgressSheetDto();
            HeadUpProgressSheet = new HeadUpProgressSheetDto();
            HeadDownProgressSheet = new HeadDownProgressSheetDto();
        }

        public TrackProgressSheetDto TrackProgressSheet { get; set; }
        public HeadUpProgressSheetDto HeadUpProgressSheet { get; set; }
        public HeadDownProgressSheetDto HeadDownProgressSheet { get; set; }
    }
}
