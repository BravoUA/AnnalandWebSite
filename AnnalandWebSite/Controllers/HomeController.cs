using AnnalandWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AnnalandWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }





        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Onsale(int IdPos, string Name, string Type) {

            List<MachineryModel> machineryModels = new List<MachineryModel>();
            List<TechnicModel> technicModels = new List<TechnicModel>();
            List<HadImgPath> hadImgPath = new List<HadImgPath>();
            List<HadImgPathT> hadImgPathT = new List<HadImgPathT>();
            using (var db = new DBConect())
            {
                db.Database.Migrate();
                machineryModels = db.Machinery.ToList();
                technicModels = db.Technic.ToList();
                hadImgPath = db.HadImgPath.ToList();
                hadImgPathT = db.HadImgPathT.ToList();
            }
            if (IdPos == 1) {
                ViewBag.Machinery = machineryModels;
                var SortName = from m in machineryModels where m.FildType == 1 orderby m.Name group m by m.Name;
                var SortType = from m in machineryModels where m.FildType == 1 orderby m.Type group m by m.Type;
                ViewBag.SortName = SortName;
                ViewBag.SortType = SortType;
                ViewBag.imgSource = hadImgPath;
            }
            else
            if (IdPos == 2)
            {
                var SortName = from m in machineryModels where m.FildType == 2 orderby m.Name group m by m.Name;
				var SortType = from m in machineryModels where m.FildType == 2 orderby m.Type group m by m.Type;

                machineryModels = (from m in machineryModels
                                  where m.FildType == 2
								  orderby m.Name select m).ToList();

				ViewBag.Machinery = machineryModels;
				ViewBag.SortName = SortName;
				ViewBag.SortType = SortType;
                List<HadImgPath> sortImg = new List<HadImgPath>();
                for (int i = 0; i < machineryModels.Count(); i++)
                {
                    for (int j = 0; j < hadImgPath.Count(); j++)
                    {
						if (hadImgPath[j].id == machineryModels[i].id)
						{
							sortImg.Add(hadImgPath[j]);
						}
						
					}
                    

				}

				
				ViewBag.imgSource = sortImg;
			}
			else
            if (IdPos == 0)
            {
				ViewBag.Machinery = machineryModels;
				var SortName = from m in machineryModels where m.FildType == 1 orderby m.Name group m by m.Name;
				var SortType = from m in machineryModels where m.FildType == 1 orderby m.Type group m by m.Type;
				ViewBag.SortName = SortName;
				ViewBag.SortType = SortType;
				ViewBag.imgSource = hadImgPath;
			}

            return View();
        }








        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}