using System.ComponentModel.DataAnnotations;

namespace BoardCalculator.Models
{
    public class CommonSize
    {
        [Key]
        public int SizeId { get; set; }
        public string Size { get; set; }
        public float Value { get; set; }
    }
}
