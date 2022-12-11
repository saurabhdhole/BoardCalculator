using System.ComponentModel.DataAnnotations;

namespace BoardCalculator.Models
{
    public class CutListByPiece
    {
        [Key]
        public int CutId { get; set; }
        public int ProjectId { get; set; }

        public string key { get; set; }
        public string Part { get; set; }
        public int SizeId { get; set; }
        public float FinishedCut { get; set; }
        public float CutLength { get; set; }
        public int Pcs { get; set; }
        public int MatId { get; set; }
        public float JigSaw { get; set; }
        public float Milter { get; set; }
        public float TableSaw { get; set; }
        public float Router { get; set; }
        public float Screws { get; set; }
        public float Glue { get; set; }
        public float Finishing { get; set; }
        public float Tennon { get; set; }
        public float HandelingCost { get; set; }
    }
}
