using System;
using System.Collections.Generic;
using System.Text;

namespace Fuentes_PrelimsP2
{
    internal class UserSession
    {
        internal static UserSession userinstance;
        internal static UserSession UserInstance => userinstance ?? (userinstance = new UserSession());

        //below are the properties recorded in user signup; to be used for user session singleton implementation
        internal string FirstName { get; set; }
        internal string MiddleName { get; set; }
        internal string LastName { get; set; }
        internal string Birthdate { get; set; }
        internal string Address { get; set; }
        internal int Age { get; set; }
        internal string Category { get; set; }

        internal string Gender { get; set; }
        internal string Username { get; set; }
        internal string Password { get; set; }
        internal long ContactNumber { get; set; }
        internal string Email {get; set;}
        internal string Hotline { get; set; }


        private UserSession() { }
    }
}
