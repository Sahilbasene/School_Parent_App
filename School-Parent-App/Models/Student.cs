using Microsoft.Win32;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace School_Parent_App.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentRegisterNumber { get; set; }
        public string StudentName { get; set; }


    }
}