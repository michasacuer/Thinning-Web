namespace Thinning.Domain
{
    using Thinning.Domain.Dao.Image;
    
    public class Image
    {
        public int ImageId { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
        public int? AlgorithmId { get; set; }
        public Algorithm Algorithm { get; set; }
        public int? TestLineId { get; set; }
        public TestLine TestLine { get; set; }
        public byte[] ImageContent { get; set; }
        public int OriginalWidth { get; set; }
        public int OriginalHeight { get; set; }
        public int OriginalBpp { get; set; }
        public bool TestImage { get; set; }

        public Image()
        {
        }

        public Image(ImageDao imageDao)
        {
            AlgorithmId = imageDao.AlgorithmId.GetValueOrDefault();
            ImageContent = imageDao.ImageContent;
            OriginalWidth = imageDao.OriginalWidth;
            OriginalHeight = imageDao.OriginalHeight;
            OriginalBpp = imageDao.OriginalBpp;
            TestImage = imageDao.TestImage;
        }
    }
}
