namespace Thinning.Domain.Dao.Image
{
    using System.Drawing.Imaging;
    
    public class ImageDto
    {
        public int TestLineId { get; set; }
        public int OriginalWidth { get; set; }
        public int OriginalHeight { get; set; }
        public PixelFormat OriginalBpp { get; set; }
        public byte[] ImageContent { get; set; }
    }
}
