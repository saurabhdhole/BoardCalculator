using System.ComponentModel.DataAnnotations;

namespace BoardCalculator.Models
{
    public class CutByBoard
    {

        [Key]
        public int CutId { get; set; }
        public int ProjectId { get; set; }
        public string key { get; set; }
        public int NumberOfCuts { get; set; }
        public float Scrap { get; set; }
        public float MinLength { get; set; }
        public float Weight { get; set; }
        public float Cut1 { get; set; }
        public float Cut2 { get; set; }
        public float Cut3 { get; set; }
        public float Cut4 { get; set; }
        public float Cut5 { get; set; }
        public float Cut6 { get; set; }
        public float Cut7 { get; set; }
        public float Cut8 { get; set; }
        public float Cut9 { get; set; }
        public float Cut10 { get; set; }
        public float Cut11 { get; set; }
        public float Cut12 { get; set; }

    }
}
