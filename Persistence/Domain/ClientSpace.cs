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
        public decimal Age { get; set; }


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


		public DateTime SignUpDate { get; set; }
        public int BeltLvl { get; set; }
	}

	public class TKD_Schedule_Info
    {
		public int ClientID { get; set; }
		public String FirstName { get; set; }
		public String LastName { get; set; }
		public decimal Age { get; set; }
		public int BeltLvl { get; set; }
		public String Class { get; set; }
		public String Ready { get; set; }
		public int FormsRdy { get; set; }
		public int HandAtksRdy { get; set; }
		public int KicksRdy { get; set; }
		public int BlocksRdy { get; set; }
    }

	public class Lil_Roster_Check
    {
		public int ClientID { get; set; }
		public String FirstName { get; set; }
		public String LastName { get; set; }
		public bool Present { get; set; }
    }

	public class Class_Progress_Info
    {
		public int ClientID { get; set; }
		public String FirstName { get; set; }
		public String LastName { get; set; }
		public bool Present { get; set; }
		public int BeltLvl { get; set; }
		public int FormsTID { get; set; }
		public int HandAtksTID { get; set; }
		public int KicksTID { get; set; }
		public int BlocksTID { get; set; }
    }

	public class Student_Info_Blocks
    {
		public String IDBlocksMeaning { get; set; }
	}
	public class Student_Info_Forms
    {
		public String IDFormMeaning { get; set; }
	}
	public class Student_Info_HandAttacks
    {
		public String IDHandAtksMeaning { get; set; }
	}
	public class Student_Info_Kicks
    {
		public String IDKicksMeaning { get; set; }
    }
	public class Belt_Requirement
    {
		public int BeltReq { get; set; }
    }
	public class Test_Ready
    {
		public int ClientID { get; set; }
		public int FormsRdy { get; set; }
		public int HandAtksRdy { get; set; }
		public int KicksRdy { get; set; }
		public int BlocksRdy { get; set; }
	}

	public class Date_Time_Storage
    {
		public String DateTime { get; set; }
		public String Page { get; set; }
    }

	public class Location_Addition
    {
		public String LocationName { get; set; }
    }

	public class Push_Yes
    {
		public String PushYes { get; set; }
    }

	public class Change_Test_Ready
    {
		public int ClientID { get; set; }
		public int FormsRdy { get; set; }
		public int HandAtksRdy { get; set; }
		public int KicksRdy { get; set; }
		public int BlocksRdy { get; set; }
	}
}
