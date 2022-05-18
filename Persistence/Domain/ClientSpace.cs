using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPF_App.Persistence.Domain
{
	public class Client_Space
	{
		public int ClientID { get; set; }
		public String FirstName { get; set; }
		public String MiddleName { get; set; }
		public String LastName { get; set; }
		public String PhoneNumber { get; set; }
		public String HomeNumber { get; set; }
		public String Email { get; set; }
		public String StreetAddress { get; set; }
		public String State { get; set; }
		public String City { get; set; }
		public int PostalCode { get; set; }
		public String Gender { get; set; }
		public String ClientType { get; set; }
		public String Location { get; set; }
		public String TransactionDate { get; set; }

		public Client_Space()
		{
		}
	}
}
