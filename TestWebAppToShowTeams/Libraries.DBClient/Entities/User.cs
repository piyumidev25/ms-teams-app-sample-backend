using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libraries.DBClient.Entities
{
    [Table("Tbl_User")]
    public class User
    {
        [Key]
        [Column("UserId")]
        public int UserId { get; set; }

        [Column("DisplayName")]
        public string DisplayName { get; set; }

        [Column("DepartmentName")]
        public string DepartmentName { get; set; }

        [Column("CompanyName")]
        public string CompanyName { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        public User(string displayName, string departmentName, string companyName, string email)
        {
            DisplayName = displayName;
            DepartmentName = departmentName;
            CompanyName = companyName;
            Email = email;
        }
    }
}
