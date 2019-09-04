namespace FreeflyAcademy.Domain
{
    public class ProgressSheet
    {
        public ProgressSheet()
        {
            TrackProgressSheet = new TrackProgressSheet();
            HeadUpProgressSheet = new HeadUpProgressSheet();
            HeadDownProgressSheet = new HeadDownProgressSheet();
        }

        public TrackProgressSheet TrackProgressSheet { get; set; }
        public HeadUpProgressSheet HeadUpProgressSheet { get; set; }
        public HeadDownProgressSheet HeadDownProgressSheet { get; set; }
    }
}
