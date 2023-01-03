using AnnalandWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using NuGet.Common;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace AnnalandWebSite.Controllers
{
	public class HomeController : Controller
	{
		private static byte STATE = 0;
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


		public IActionResult Onsale(int IdPos, string Name, string Type)
		{

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
			if (IdPos == 1)
			{
				ViewBag.IdPos = "IdPos=1";
				if (Name != null && Type == null)
				{

					List<MachineryModel> machinerySort = new List<MachineryModel>();
					machinerySort = (from m in machineryModels where m.FildType == 1 && m.Name == Name orderby m.Name select m).ToList();
					ViewBag.Machinery = machinerySort;

					var SortName = from m in machineryModels where m.FildType == 1 orderby m.Name group m by m.Name;
					var SortType = from m in machinerySort where m.FildType == 1 orderby m.Type group m by m.Type;
					ViewBag.SortName = SortName;
					ViewBag.SortType = SortType;

					List<HadImgPath> sortImg = new List<HadImgPath>();
					for (int i = 0; i < machinerySort.Count(); i++)
					{
						for (int j = 0; j < hadImgPath.Count(); j++)
						{
							if (hadImgPath[j].id == machinerySort[i].id)
							{
								sortImg.Add(hadImgPath[j]);
							}
						}
					}
					ViewBag.imgSource = sortImg;
					ViewBag.Name = "Name=" + Name;
					ViewBag.SelectedNameTab = Name;
					ViewBag.SelectedTypeTab = "Тип";
				}
				else if (Name != null && Type != null)
				{

					List<MachineryModel> machinerySort = new List<MachineryModel>();
					machinerySort = (from m in machineryModels where m.FildType == 1 && m.Type == Type && m.Name == Name orderby m.Name select m).ToList();
					ViewBag.Machinery = machinerySort;

					var SortName = from m in machineryModels where m.FildType == 1 orderby m.Name group m by m.Name;
					var SortType = from m in machinerySort where m.FildType == 1 orderby m.Type group m by m.Type;
					ViewBag.SortName = SortName;
					ViewBag.SortType = SortType;

					List<HadImgPath> sortImg = new List<HadImgPath>();
					for (int i = 0; i < machinerySort.Count(); i++)
					{
						for (int j = 0; j < hadImgPath.Count(); j++)
						{
							if (hadImgPath[j].id == machinerySort[i].id)
							{
								sortImg.Add(hadImgPath[j]);
							}
						}
					}
					ViewBag.imgSource = sortImg;
					ViewBag.SelectedNameTab = Name;
					ViewBag.SelectedTypeTab = Type;
				}
				else if (Name == null && Type != null)
				{

					List<MachineryModel> machinerySort = new List<MachineryModel>();
					machinerySort = (from m in machineryModels where m.FildType == 1 && m.Type == Type orderby m.Name select m).ToList();
					ViewBag.Machinery = machinerySort;

					var SortName = from m in machinerySort where m.FildType == 1 orderby m.Name group m by m.Name;
					var SortType = from m in machinerySort where m.FildType == 1 orderby m.Type group m by m.Type;
					ViewBag.SortName = SortName;
					ViewBag.SortType = SortType;

					List<HadImgPath> sortImg = new List<HadImgPath>();
					for (int i = 0; i < machinerySort.Count(); i++)
					{
						for (int j = 0; j < hadImgPath.Count(); j++)
						{
							if (hadImgPath[j].id == machinerySort[i].id)
							{
								sortImg.Add(hadImgPath[j]);
							}
						}
					}
					ViewBag.imgSource = sortImg;
					ViewBag.SelectedNameTab = "Марка";
					ViewBag.SelectedTypeTab = Type;
				}
				else
				{

					machineryModels = (from m in machineryModels where m.FildType == 1 orderby m.Name select m).ToList();
					ViewBag.Machinery = machineryModels;
					var SortName = from m in machineryModels where m.FildType == 1 orderby m.Name group m by m.Name;
					var SortType = from m in machineryModels where m.FildType == 1 orderby m.Type group m by m.Type;
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
					ViewBag.SelectedNameTab = "Марка";
					ViewBag.SelectedTypeTab = "Тип";
				}
			}
			else
			 if (IdPos == 2)
			{
				ViewBag.IdPos = "IdPos=2";
				if (Name != null && Type == null)
				{

					List<MachineryModel> machinerySort = new List<MachineryModel>();
					machinerySort = (from m in machineryModels where m.FildType == 2 && m.Name == Name orderby m.Name select m).ToList();
					ViewBag.Machinery = machinerySort;

					var SortName = from m in machineryModels where m.FildType == 2 orderby m.Name group m by m.Name;
					var SortType = from m in machinerySort where m.FildType == 2 orderby m.Type group m by m.Type;
					ViewBag.SortName = SortName;
					ViewBag.SortType = SortType;

					List<HadImgPath> sortImg = new List<HadImgPath>();
					for (int i = 0; i < machinerySort.Count(); i++)
					{
						for (int j = 0; j < hadImgPath.Count(); j++)
						{
							if (hadImgPath[j].id == machinerySort[i].id)
							{
								sortImg.Add(hadImgPath[j]);
							}
						}
					}
					ViewBag.imgSource = sortImg;
					ViewBag.Name = "Name=" + Name;
					ViewBag.SelectedNameTab = Name;
					ViewBag.SelectedTypeTab = "Тип";
				}
				else if (Name != null && Type != null)
				{

					List<MachineryModel> machinerySort = new List<MachineryModel>();
					machinerySort = (from m in machineryModels where m.FildType == 2 && m.Type == Type && m.Name == Name orderby m.Name select m).ToList();
					ViewBag.Machinery = machinerySort;

					var SortName = from m in machineryModels where m.FildType == 2 orderby m.Name group m by m.Name;
					var SortType = from m in machinerySort where m.FildType == 2 orderby m.Type group m by m.Type;
					ViewBag.SortName = SortName;
					ViewBag.SortType = SortType;

					List<HadImgPath> sortImg = new List<HadImgPath>();
					for (int i = 0; i < machinerySort.Count(); i++)
					{
						for (int j = 0; j < hadImgPath.Count(); j++)
						{
							if (hadImgPath[j].id == machinerySort[i].id)
							{
								sortImg.Add(hadImgPath[j]);
							}
						}
					}
					ViewBag.imgSource = sortImg;
					ViewBag.SelectedNameTab = Name;
					ViewBag.SelectedTypeTab = Type;
				}
				else if (Name == null && Type != null)
				{

					List<MachineryModel> machinerySort = new List<MachineryModel>();
					machinerySort = (from m in machineryModels where m.FildType == 2 && m.Type == Type orderby m.Name select m).ToList();
					ViewBag.Machinery = machinerySort;

					var SortName = from m in machinerySort where m.FildType == 2 orderby m.Name group m by m.Name;
					var SortType = from m in machinerySort where m.FildType == 2 orderby m.Type group m by m.Type;
					ViewBag.SortName = SortName;
					ViewBag.SortType = SortType;

					List<HadImgPath> sortImg = new List<HadImgPath>();
					for (int i = 0; i < machinerySort.Count(); i++)
					{
						for (int j = 0; j < hadImgPath.Count(); j++)
						{
							if (hadImgPath[j].id == machinerySort[i].id)
							{
								sortImg.Add(hadImgPath[j]);
							}
						}
					}
					ViewBag.imgSource = sortImg;
					ViewBag.SelectedNameTab = "Марка";
					ViewBag.SelectedTypeTab = Type;
				}
				else
				{

					machineryModels = (from m in machineryModels where m.FildType == 2 orderby m.Name select m).ToList();
					ViewBag.Machinery = machineryModels;
					var SortName = from m in machineryModels where m.FildType == 2 orderby m.Name group m by m.Name;
					var SortType = from m in machineryModels where m.FildType == 2 orderby m.Type group m by m.Type;
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
					ViewBag.SelectedNameTab = "Марка";
					ViewBag.SelectedTypeTab = "Тип";
				}
			}
			else
			 if (IdPos == 3)
			{
				ViewBag.IdPos = "IdPos=" + IdPos;
				if (Name != null && Type == null)
				{

					List<MachineryModel> machinerySort = new List<MachineryModel>();
					machinerySort = (from m in machineryModels where m.FildType == IdPos && m.Name == Name orderby m.Name select m).ToList();
					ViewBag.Machinery = machinerySort;

					var SortName = from m in machineryModels where m.FildType == IdPos orderby m.Name group m by m.Name;
					var SortType = from m in machinerySort where m.FildType == IdPos orderby m.Type group m by m.Type;
					ViewBag.SortName = SortName;
					ViewBag.SortType = SortType;

					List<HadImgPath> sortImg = new List<HadImgPath>();
					for (int i = 0; i < machinerySort.Count(); i++)
					{
						for (int j = 0; j < hadImgPath.Count(); j++)
						{
							if (hadImgPath[j].id == machinerySort[i].id)
							{
								sortImg.Add(hadImgPath[j]);
							}
						}
					}
					ViewBag.imgSource = sortImg;
					ViewBag.Name = "Name=" + Name;
					ViewBag.SelectedNameTab = Name;
					ViewBag.SelectedTypeTab = "Тип";
				}
				else if (Name != null && Type != null)
				{

					List<MachineryModel> machinerySort = new List<MachineryModel>();
					machinerySort = (from m in machineryModels where m.FildType == IdPos && m.Type == Type && m.Name == Name orderby m.Name select m).ToList();
					ViewBag.Machinery = machinerySort;

					var SortName = from m in machineryModels where m.FildType == IdPos orderby m.Name group m by m.Name;
					var SortType = from m in machinerySort where m.FildType == IdPos orderby m.Type group m by m.Type;
					ViewBag.SortName = SortName;
					ViewBag.SortType = SortType;

					List<HadImgPath> sortImg = new List<HadImgPath>();
					for (int i = 0; i < machinerySort.Count(); i++)
					{
						for (int j = 0; j < hadImgPath.Count(); j++)
						{
							if (hadImgPath[j].id == machinerySort[i].id)
							{
								sortImg.Add(hadImgPath[j]);
							}
						}
					}
					ViewBag.imgSource = sortImg;
					ViewBag.SelectedNameTab = Name;
					ViewBag.SelectedTypeTab = Type;
				}
				else if (Name == null && Type != null)
				{

					List<MachineryModel> machinerySort = new List<MachineryModel>();
					machinerySort = (from m in machineryModels where m.FildType == IdPos && m.Type == Type orderby m.Name select m).ToList();
					ViewBag.Machinery = machinerySort;

					var SortName = from m in machinerySort where m.FildType == IdPos orderby m.Name group m by m.Name;
					var SortType = from m in machinerySort where m.FildType == IdPos orderby m.Type group m by m.Type;
					ViewBag.SortName = SortName;
					ViewBag.SortType = SortType;

					List<HadImgPath> sortImg = new List<HadImgPath>();
					for (int i = 0; i < machinerySort.Count(); i++)
					{
						for (int j = 0; j < hadImgPath.Count(); j++)
						{
							if (hadImgPath[j].id == machinerySort[i].id)
							{
								sortImg.Add(hadImgPath[j]);
							}
						}
					}
					ViewBag.imgSource = sortImg;
					ViewBag.SelectedNameTab = "Марка";
					ViewBag.SelectedTypeTab = Type;
				}
				else
				{

					machineryModels = (from m in machineryModels where m.FildType == IdPos orderby m.Name select m).ToList();
					ViewBag.Machinery = machineryModels;
					var SortName = from m in machineryModels where m.FildType == IdPos orderby m.Name group m by m.Name;
					var SortType = from m in machineryModels where m.FildType == IdPos orderby m.Type group m by m.Type;
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
					ViewBag.SelectedNameTab = "Марка";
					ViewBag.SelectedTypeTab = "Тип";
				}
			}
			else
			 if (IdPos > 3)
			{
				ViewBag.IdPos = "IdPos=" + IdPos;
				ViewBag.Id = IdPos;
				if (Name != null && Type == null)
				{

					List<TechnicModel> technicSort = new List<TechnicModel>();
					technicSort = (from m in technicModels where m.FildType == IdPos && m.Name == Name orderby m.Name select m).ToList();
					ViewBag.Machinery = technicSort;

					var SortName = from m in technicModels where m.FildType == IdPos orderby m.Name group m by m.Name;
					var SortType = from m in technicSort where m.FildType == IdPos orderby m.Type group m by m.Type;
					ViewBag.SortName = SortName;
					ViewBag.SortType = SortType;

					List<HadImgPathT> sortImg = new List<HadImgPathT>();
					for (int i = 0; i < technicSort.Count(); i++)
					{
						for (int j = 0; j < hadImgPathT.Count(); j++)
						{
							if (hadImgPathT[j].id == technicSort[i].id)
							{
								sortImg.Add(hadImgPathT[j]);
							}
						}
					}
					ViewBag.imgSource = sortImg;
					ViewBag.Name = "Name=" + Name;
					ViewBag.SelectedNameTab = Name;
					ViewBag.SelectedTypeTab = "Тип";
				}
				else if (Name != null && Type != null)
				{

					List<TechnicModel> technicSort = new List<TechnicModel>();
					technicSort = (from m in technicModels where m.FildType == IdPos && m.Type == Type && m.Name == Name orderby m.Name select m).ToList();
					ViewBag.Machinery = technicSort;

					var SortName = from m in technicModels where m.FildType == IdPos orderby m.Name group m by m.Name;
					var SortType = from m in technicSort where m.FildType == IdPos orderby m.Type group m by m.Type;
					ViewBag.SortName = SortName;
					ViewBag.SortType = SortType;

					List<HadImgPathT> sortImg = new List<HadImgPathT>();
					for (int i = 0; i < technicSort.Count(); i++)
					{
						for (int j = 0; j < hadImgPathT.Count(); j++)
						{
							if (hadImgPathT[j].id == technicSort[i].id)
							{
								sortImg.Add(hadImgPathT[j]);
							}
						}
					}
					ViewBag.imgSource = sortImg;
					ViewBag.SelectedNameTab = Name;
					ViewBag.SelectedTypeTab = Type;
				}
				else if (Name == null && Type != null)
				{

					List<TechnicModel> technicSort = new List<TechnicModel>();
					technicSort = (from m in technicModels where m.FildType == IdPos && m.Type == Type orderby m.Name select m).ToList();
					ViewBag.Machinery = technicSort;

					var SortName = from m in technicSort where m.FildType == IdPos orderby m.Name group m by m.Name;
					var SortType = from m in technicSort where m.FildType == IdPos orderby m.Type group m by m.Type;
					ViewBag.SortName = SortName;
					ViewBag.SortType = SortType;

					List<HadImgPathT> sortImg = new List<HadImgPathT>();
					for (int i = 0; i < technicSort.Count(); i++)
					{
						for (int j = 0; j < hadImgPathT.Count(); j++)
						{
							if (hadImgPathT[j].id == technicSort[i].id)
							{
								sortImg.Add(hadImgPathT[j]);
							}
						}
					}
					ViewBag.imgSource = sortImg;
					ViewBag.SelectedNameTab = "Марка";
					ViewBag.SelectedTypeTab = Type;
				}
				else
				{

					technicModels = (from m in technicModels where m.FildType == IdPos orderby m.Name select m).ToList();
					ViewBag.Machinery = technicModels;
					var SortName = from m in technicModels where m.FildType == IdPos orderby m.Name group m by m.Name;
					var SortType = from m in technicModels where m.FildType == IdPos orderby m.Type group m by m.Type;
					ViewBag.SortName = SortName;
					ViewBag.SortType = SortType;
					List<HadImgPathT> sortImg = new List<HadImgPathT>();
					for (int i = 0; i < technicModels.Count(); i++)
					{
						for (int j = 0; j < hadImgPathT.Count(); j++)
						{
							if (hadImgPathT[j].id == technicModels[i].id)
							{
								sortImg.Add(hadImgPathT[j]);
							}
						}
					}
					ViewBag.imgSource = sortImg;
					ViewBag.SelectedNameTab = "Марка";
					ViewBag.SelectedTypeTab = "Тип";
				}
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

		public IActionResult ViewTR(int IdPos, int ID)
		{
			List<MachineryModel> machineryModels = new List<MachineryModel>();
			List<TechnicModel> technicModels = new List<TechnicModel>();
			List<MachinesImg> machineryImg = new List<MachinesImg>();
			List<TechnicImg> technicImg = new List<TechnicImg>();
			using (var db = new DBConect())
			{
				db.Database.Migrate();
				machineryModels = db.Machinery.ToList();
				technicModels = db.Technic.ToList();
				machineryImg = db.MachinesImg.ToList();
				technicImg = db.TechnicImg.ToList();
			}
			if (IdPos <= 3)
			{
				ViewBag.ID = ID;
				ViewBag.IdPos = IdPos;
				List<MachineryModel> technicSort = new List<MachineryModel>();
				technicSort = (from m in machineryModels where m.id == ID select m).ToList();
				ViewBag.MorT = technicSort;
				List<MachinesImg> sortImg = new List<MachinesImg>();
				sortImg = (from m in machineryImg where m.id == ID select m).ToList();

				ViewBag.imgSource = sortImg;
			}
			else if (IdPos > 3)
			{
				ViewBag.ID = ID;
				ViewBag.IdPos = IdPos;
				List<TechnicModel> technicSort = new List<TechnicModel>();
				technicSort = (from m in technicModels where m.id == ID select m).ToList();
				ViewBag.MorT = technicSort;
				List<TechnicImg> sortImg = (from m in technicImg where m.id == ID select m).ToList();
				ViewBag.imgSource = sortImg;
			}



			return View();
		}
		
		public IActionResult SignUp()
		{
			ViewBag.Massage = "";
			return View();
		}
		










		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}