using System.ComponentModel.DataAnnotations;

namespace BoardCalculator.Models
{
    public class Material
    {

        [Key]
        public int MatId { get; set; }
        public string MatName { get; set; }
        public int Active { get; set; }


    }
}
