using BoardCalculator.Data;
using BoardCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BoardCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private BoardDbContext _context;

        public HomeController(ILogger<HomeController> logger, BoardDbContext boardDbContext)
        {
            _logger = logger;
            _context = boardDbContext;
        }

        public IActionResult Index()
        {

            return RedirectToActionPermanent("Projects");
        }
        #region project

        public IActionResult Projects()
        {
            var res = _context.Project.ToList();
            return View(res);
        }

        public IActionResult EditProjects(int id)
        {
            Project project = null;
            if (id == -1)
            {
                project = new Project()
                {
                    Active = true,
                    ProjectName = "",
                    ProjectId = -1,
                };
            }
            else
            {
                project = _context.Project.Find(id);
            }
            return PartialView(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProjects(Project project)
        {
            var res = new Dictionary<string, string>();
            try
            {
                if (ModelState.IsValid)
                {
                    if (project.ProjectId == -1)
                    {
                        project.ProjectId = _context.Project.Max(x => x.ProjectId) + 1;
                        _context.Project.Add(project);

                        _context.SaveChanges();
                    }
                    else
                    {
                        Project projectExisting = _context.Project.Find(project.ProjectId);
                        projectExisting.ProjectName = project.ProjectName;
                        _context.SaveChanges();
                    }
                }
                res.Add("Res", "success");
                res.Add("Msg", "Project " + project.ProjectName + "Created/Updated Successfully");
            }
            catch (Exception ex)
            {
                res.Add("Res", "failure");
                res.Add("Msg", "Error occured while creating/udpating Project " + project.ProjectName + "");
            }



            return new JsonResult(res);
        }


        #endregion


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ViewProject(int id)
        {
            ViewData["ViewCutByBoard"] = _context.CutByBoard.Where(x => x.ProjectId == id).ToList();
            ViewData["ViewCutListByPiece"] = _context.CutListByPiece.Where(x => x.ProjectId == id).ToList();
            // ViewData["ViewCutByBoard"] = _context.CutByBoard.Where(x => x.ProjectId == id).ToList();
            //HttpContext.Session.SetInt32("ProjectId",id);
            ViewData["CommonSizesDdl"] = new AppManager(_context).GetCommonSizes();
            ViewData["MaterialsDdl"] = new AppManager(_context).GetMaterials();

            ViewData["ProjectId"] = id;
            return View();
        }

        public IActionResult ViewCutByBoard(int id)
        {
            List<CutByBoard> cutByBoards = _context.CutByBoard.Where(x => x.ProjectId == id).ToList();
            return View(cutByBoards);
        }

        public IActionResult ViewCutListByPiece(int id)
        {
            List<CutListByPiece> cutListByPieces = _context.CutListByPiece.Where(x => x.ProjectId == id).ToList();
            return View(cutListByPieces);
        }

        #region CutByBoard

        public IActionResult EditCutByBoard(int cutId, int projectId)
        {
            CutByBoard cutByBoard = null;

            if (cutId == -1)
            {
                cutByBoard = new CutByBoard()
                {

                    CutId = -1,
                    ProjectId = projectId,
                };
            }
            else
            {
                cutByBoard = _context.CutByBoard.Find(cutId);
            }
            return PartialView(cutByBoard);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCutByBoard(CutByBoard cutByBoard)
        {
            var res = new Dictionary<string, string>();
            try
            {
                if (ModelState.IsValid)
                {
                    if (cutByBoard.CutId == -1)
                    {
                        cutByBoard.CutId = !_context.CutByBoard.Any() ? 1 : _context.CutByBoard.Max(x => x.CutId) + 1;

                        _context.CutByBoard.Add(cutByBoard);
                        _context.SaveChanges();
                    }
                    else
                    {
                        CutByBoard ExtObj = _context.CutByBoard.Find(cutByBoard.CutId);
                        _context.Entry(ExtObj).CurrentValues.SetValues(cutByBoard);
                        ExtObj = cutByBoard;
                        _context.SaveChanges();
                    }
                }
                res.Add("Res", "success");
                res.Add("Msg", "CutByBoard Created/Updated Successfully");
            }
            catch (Exception ex)
            {
                res.Add("Res", "failure");
                res.Add("Msg", "Error occured while creating/udpating CutByBoard ");
            }



            return new JsonResult(res);
        }
        #endregion  


        #region CutListByPiece

        public IActionResult EditCutListByPiece(int cutId, int projectId)
        {
            CutListByPiece cutListByPiece = null;

            if (cutId == -1)
            {
                cutListByPiece = new CutListByPiece()
                {

                    CutId = -1,
                    ProjectId = projectId,
                };
            }
            else
            {
                cutListByPiece = _context.CutListByPiece.Find(cutId);
            }
            ViewData["CommonSizesDdl"] = new AppManager(_context).GetCommonSizes();
            ViewData["MaterialsDdl"] = new AppManager(_context).GetMaterials();
            return PartialView(cutListByPiece);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCutListByPiece(CutListByPiece cutListByPiece)
        {
            var res = new Dictionary<string, string>();
            try
            {
                if (ModelState.IsValid)
                {
                    if (cutListByPiece.CutId == -1)
                    {
                        cutListByPiece.CutId = !_context.CutListByPiece.Any() ? 1 : _context.CutListByPiece.Max(x => x.CutId) + 1;
                        _context.CutListByPiece.Add(cutListByPiece);

                        _context.SaveChanges();
                    }
                    else
                    {
                        CutListByPiece ExtObj = _context.CutListByPiece.Find(cutListByPiece.CutId);
                        _context.Entry(ExtObj).CurrentValues.SetValues(cutListByPiece);
                        ExtObj = cutListByPiece;
                        _context.SaveChanges();
                    }
                }
                res.Add("Res", "success");
                res.Add("Msg", "CutListByPiece Created/Updated Successfully");
            }
            catch (Exception ex)
            {
                res.Add("Res", "failure");
                res.Add("Msg", "Error occured while creating/udpating CutListByPiece ");
            }
            ViewData["CommonSizesDdl"] = new AppManager(_context).GetCommonSizes();
            ViewData["MaterialsDdl"] = new AppManager(_context).GetMaterials();


            return new JsonResult(res);
        }
        #endregion


        #region Print Project

        public IActionResult PrintProject(int id)
        {
            ViewData["ViewCutByBoard"] = _context.CutByBoard.Where(x => x.ProjectId == id).ToList();
            ViewData["ViewCutListByPiece"] = _context.CutListByPiece.Where(x => x.ProjectId == id).ToList();

            ViewData["CommonSizesDdl"] = new AppManager(_context).GetCommonSizes();
            ViewData["MaterialsDdl"] = new AppManager(_context).GetMaterials();

            return View();
        }

        #endregion

        [HttpPost]
        public IActionResult CreateCutByBoard(int id)
        {
            var res = new Dictionary<string, string>();

            //Add Logic here

            res.Add("Res", "success");
            res.Add("Msg", "CutListByPiece Created/Updated Successfully");
            return new JsonResult(res);
        }

    }
}