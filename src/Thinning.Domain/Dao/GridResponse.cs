namespace Thinning.Domain.Dao
{
    using System.Collections.Generic;
    
    public class GridResponse<T>
        where T : class
    {
        public List<T> List { get; set; }
        public int Size { get; set; }
    }
}
