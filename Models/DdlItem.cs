namespace BoardCalculator.Models
{
    public class DdlItem
    {
        public string val { get; set; }
        public string txt { get; set; }

        public DdlItem()
        {

        }

        public DdlItem(string v, string t)
        {
            val = v;
            txt = t;
        }
    }
}
