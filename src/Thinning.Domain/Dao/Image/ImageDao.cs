namespace Thinning.Domain.Dao.Image
{
    using System.Drawing.Imaging;
    
    public class ImageDao
    {
        public int? AlgorithmId { get; set; }
        public string AlgorithmName { get; set; }
        public int OriginalWidth { get; set; }
        public int OriginalHeight { get; set; }
        public PixelFormat OriginalBpp { get; set; }
        public bool TestImage { get; set; }
        public byte[] ImageContent { get; set; }
    }
}
