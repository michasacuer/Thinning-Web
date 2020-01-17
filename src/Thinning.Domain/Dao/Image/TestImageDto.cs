namespace Thinning.Domain.Dao.Image
{
    using System.Drawing.Imaging;
    
    public class TestImageDto
    {
        public int TestId { get; set; }
        public int TestLineId { get; set; }
        public int OriginalWidth { get; set; }
        public int OriginalHeight { get; set; }
        public PixelFormat OriginalBpp { get; set; }
        public byte[] ImageContent { get; set; }
        public bool TestImage { get; set; }
    }
}
