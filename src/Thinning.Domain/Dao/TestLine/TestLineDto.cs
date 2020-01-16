namespace Thinning.Domain.Dao.TestLine
{
    using Thinning.Domain;
    using Thinning.Domain.Dao.Image;

    public class TestLineDto : TestLineDao
    {
        public int TestLineId { get; set; }
        public ImageDto Image { get; set; }
    }
}
