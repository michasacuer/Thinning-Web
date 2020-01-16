namespace Thinning.Domain.Dao.Image
{
    public class ImageDto
    {
        public int TestLineId { get; set; }
        public int OriginalWidth { get; set; }
        public int OriginalHeight { get; set; }
        public int OriginalBpp { get; set; }
        public byte[] ImageContent { get; set; }
    }
}
