namespace Thinning.Domain.Dao.Test
{
    public class AcceptTestDao
    {
        public AcceptTestDao(string guid, bool accepted)
        {
            Guid = guid;
            Accepted = accepted;
        }

        public string Guid { get; set; }
        public bool Accepted { get; set; }
    }
}
