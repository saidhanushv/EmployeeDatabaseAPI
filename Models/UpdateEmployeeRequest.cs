using System.Data.SqlTypes;

namespace EmployeeDatabase.Models
{
    public class UpdateEmployeeRequest
    {
        public string? FIRSTNAME { get; set; }
        public string? MIDDLENAME { get; set; }
        public string? LASTNAME { get; set; }
        public string? DEPT { get; set; }
        public int CONTACT { get; set; }
        public string? DEGREE { get; set; }
        public string? GENDER { get; set; }
        public int SALARY { get; set; }
    }
}
