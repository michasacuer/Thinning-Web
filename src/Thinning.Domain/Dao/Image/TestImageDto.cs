namespace Thinning.Domain.Dao.Image
{
    public class TestImageDto
    {
        public int TestId { get; set; }
        public int TestLineId { get; set; }
        public int OriginalWidth { get; set; }
        public int OriginalHeight { get; set; }
        public int OriginalBpp { get; set; }
        public byte[] ImageContent { get; set; }
        public bool TestImage { get; set; }
    }
}
