namespace Thinning.Domain
{
    public class Image
    {
        public int ImageId { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
        public int? AlgorithmId { get; set; }
        public Algorithm Algorithm { get; set; }
        public byte[] ImageContent { get; set; }
        public int OriginalWidth { get; set; }
        public int OriginalHeight { get; set; }
        public int OriginalBpp { get; set; }
        public bool TestImage { get; set; }
    }
}
