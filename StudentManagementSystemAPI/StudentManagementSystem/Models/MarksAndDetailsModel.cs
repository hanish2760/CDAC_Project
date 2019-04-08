using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class MarksAndDetailsModel
    {

        public string Sname { get; set; }
        public string Roll_Number { get; set; }
        public string Domain { get; set; }
        public int Syear { get; set; }
        public string Mailid { get; set; }
        public string UPassword { get; set; }
        public string Phno { get; set; }
        public string Dob { get; set; }
        public string FatherName { get; set; }
        public string FatherDesignation { get; set; }
        public string FatherPhNum { get; set; }
        public string MotherName { get; set; }
        public string MotherDesignation { get; set; }
        public string MotherPhNum { get; set; }
        public string SAddress { get; set; }
        public string BloodGrp { get; set; }
        public string DateOfJoining { get; set; }
        public int Userid { get; set; }
        // faculty will be able to edit....
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




    }
}