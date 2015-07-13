using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using TestMVCASP.Models;
using TestMVCASP.Models.DataModels;

namespace TestMVCASP.Controllers
{
	public class HomeController : Controller
	{
		
	   //homepage
		public ActionResult Index()
		{
			return this.View();
		}



		// For error, if I can`t search record with input ID
		public ActionResult ErrorResult()
		{
			return this.View("ErrorResult");
		}

		//for view main form with person
		public ActionResult ResultSearchAction(InputModel inputModel)
		{
			//initialization parametres
			var list = new List<ContactTable>();
			
			var personalModel = new PersonalModel();
			personalModel.ID = inputModel.InputID;
			var titeleLists = new List<SelectListItem>();
			//for title selection
			titeleLists.Add(new SelectListItem()
			                {
				                Text = "Mr.",
				                Value = "0"
			                });
			titeleLists.Add(new SelectListItem()
			                {
				                Text = "Mrs.",
				                Value = "1",
			                });

			//get from data base all data what we need and formation a model
			using (var db = new CMSEntities())
			{
				var recordmem = db.Members.FirstOrDefault(x => x.MemberID == inputModel.InputID);
				var recordphone = db.PhoneNumbers.Where(x => x.MemberID == inputModel.InputID);

				if (recordmem==null)
				{
					return ErrorResult();
				}
				var typesphone = db.PhoneTypes.ToList();
				personalModel.Contacts = new List<ContactTable>();

				if (recordmem != null)
				{
					personalModel.SelectedTitle = recordmem.Title;
					personalModel.FirstName = recordmem.FirstName;
					personalModel.LastName = recordmem.LastName;

					if (recordmem.DOB != null)
					{
						personalModel.DayOfBirth = recordmem.DOB.Value.ToShortDateString();

						var age = DateTime.Today.Year - recordmem.DOB.Value.Year;
						if (recordmem.DOB.Value > DateTime.Today.AddYears(-age))
						{
							age--;
						}
						personalModel.Age = age;
					}
					foreach (var phonerec in recordphone)
					{
						var a = new ContactTable();
						a.EmailNumber = phonerec.PhoneNumber;
						a.Note = phonerec.Note ?? String.Empty;
						var phoneTypes = typesphone.FirstOrDefault(x => x.PhoneTypeID == phonerec.PhoneTypeID);
						if (phoneTypes != null)
						{
							a.Type = phoneTypes.Type;
						}

						list.Add(a);
					}
				}

				//magic for  choice in the selector is exactly what we need from the database
				var p = titeleLists.FirstOrDefault(x => x.Text == personalModel.SelectedTitle);
				if (p != null)
				{
					titeleLists.Add(new SelectListItem()
					                {
						                Selected = true,
						                Text = p.Text,
						                Value = p.Value
					                });
					titeleLists.Remove(p);
				}
				else
				{
					titeleLists.Add(new SelectListItem()
					                {
						                Selected = true,
						                Text = String.Empty,
						                Value = "2"
					                });
				}
				this.ViewBag.DropDown = titeleLists;
				personalModel.Title = titeleLists;
			}
			personalModel.Contacts = list;
			return View(personalModel);
		}
	}
}
