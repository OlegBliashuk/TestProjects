using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace TestMVCASP.Models
{

	public class PersonalModel
	{
		private DateTime dayOfBirth;


		public int ID
		{
			get;
			set;
		}

		public byte Photo
		{
			get;
			set;
		}

		public List<SelectListItem> Title
		{
			get;
			
			set;
		}
		public string SelectedTitle
		{
			get;
			set;
		}

		public string FirstName
		{
			get;
			set;
		}

		public string LastName
		{
			get;
			set;
		}

		public IEnumerable<ContactTable> Contacts
		{
			get;
			set;
		}

		public String DayOfBirth
		{
			get;

			set;

		}

		public int Age
		{
			get;
			set;
		}
	}

	public class ContactTable
	{
		public string Type
		{
			get;
			set;
		}
		public string EmailNumber
		{
			get;
			set;
		}
		public string Note
		{
			get;
			set;
		}
	}
}
