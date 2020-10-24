using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvacProj
{
    public class Applicant
    {

        //oracle username and password
        public string Username { get; set; }
        public string Password { get; set; }

        //first name and last name from tables
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Applicant(string username, string password, string firstname, string lastname)
        {
            this.Username = username;
            this.Password = password;
            this.FirstName = firstname;
            this.LastName = lastname;

        }
    }
}