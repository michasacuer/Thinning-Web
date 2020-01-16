namespace Thinning.Domain.Dao
{
    public class PaginationModel
    {
        public int Skip { get; set; }
        public int Size { get; set; }
        public string OrderBy { get; set; }
        public string OrderDir { get; set; }
    }
}
