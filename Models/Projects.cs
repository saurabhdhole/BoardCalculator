using System.ComponentModel.DataAnnotations;

namespace BoardCalculator.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public bool Active { get; set; }
    }
}
