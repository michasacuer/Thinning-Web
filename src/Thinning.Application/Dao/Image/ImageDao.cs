namespace Thinning.Service.Dao.Image
{
    public class ImageDao
    {
        public int OriginalWidth { get; set; }
        public int OriginalHeight { get; set; }
        public int OriginalBpp { get; set; }
        public bool TestImage { get; set; }
        public byte[] ImageContent { get; set; }
    }
}
