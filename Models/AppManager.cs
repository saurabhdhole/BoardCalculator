using BoardCalculator.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BoardCalculator.Models
{
    public class AppManager
    {
        BoardDbContext db;
        public AppManager(BoardDbContext db)
        {
            this.db = db;
        }

        public List<SelectListItem> GetCommonSizes()
        {
            List<SelectListItem> ddlItems = new List<SelectListItem>();

            foreach (var item in db.CommonSize)
            {
                ddlItems.Add(new SelectListItem( item.Size, item.SizeId.ToString()));
            }

            return ddlItems;
        }

        public List<SelectListItem> GetMaterials()
        {
            List<SelectListItem> ddlItems = new List<SelectListItem>();

            foreach (var item in db.Material)
            {
                ddlItems.Add(new SelectListItem( item.MatName, item.MatId.ToString()));
            }

            return ddlItems;
        }
    }
}
