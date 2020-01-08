namespace Thinning.Domain
{
    using System.Collections.Generic;
    
    public class Algorithm
    {
        public int AlgorithmId { get; set; }
        public string Name { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
