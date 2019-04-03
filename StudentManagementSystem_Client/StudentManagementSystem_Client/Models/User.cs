using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem_Client.Models
{
    public class User
    {

        public string mail_id
        {
            get;
            set;
        }
        public string password
        {
            get;
            set;
        }
        public int role
        {
            get;
            set;
        }
        public int userid
        {
            get;
            set;
        }
    }
}