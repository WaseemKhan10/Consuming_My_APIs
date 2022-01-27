using System.ComponentModel;

namespace Consuming_My_APIs.Models
{
    public class ModelEmployee
    {
        [DisplayName("Employee ID")]

        public int EmployeeID { get; set; }
        [DisplayName("Employee Name")]

        public string? EmployeeName { get; set; }
        [DisplayName("Mobile")]

        public string? EmployeePhone { get; set; }
        [DisplayName("Residence Address")]

        public string? EmployeeAddress { get; set; }
        [DisplayName("Department")]

        public string? EmployeeDept { get; set; }
    }
}
