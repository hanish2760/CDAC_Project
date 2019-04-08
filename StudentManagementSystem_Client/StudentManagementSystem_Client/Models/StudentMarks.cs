using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem_Client.Models
{
    public class StudentMarks
    {
        /*
         * 
Create table Curriculum_Table (User_id int , 
Subject1 int , 
Subject2 int ,
Subject3 int,
Attendance float,
foreign key(User_id) references StudentDetails(Userid));
         * 
         */
         public int User_id
        {
            get;set;
        }
        public int Subject1
        {
            get; set;
        }
        public int Subject2
        {
            get; set;
        }
        public int Subject3
        {
            get; set;
        }
        public float Average
        {
            get; set;
        }
        public float Attendance
        {
            get; set;
        }
        public int Serial_No
        {
            get; set;
        }

    }
}