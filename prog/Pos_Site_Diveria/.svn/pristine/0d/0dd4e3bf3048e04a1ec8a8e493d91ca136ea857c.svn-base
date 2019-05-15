using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data
{

    public enum UserOrigins
    {
        POS,
        VO//AD
    }

    public enum UserType
    {
        WebUser,
        Agent,
        Subscriptor
    }

    public enum UserStatus
    {
        Created,
        Active,
        Inactive
    }

    [Table("USERS")]
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public string Salt { get; set; }

        public string PasswordEncoded { get; set; }

        public string ChangePasswordToken { get; set; }

        public UserOrigins UserOrigin { get; set; }

        public UserType UserType { get; set; }

        public UserStatus UserStatus { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? LastDateModified { get; set; } 

        public DateTime? LastLogin { get; set; }

        public int? VirtualOfficeId { get; set; }

        public ICollection<Quotation> Quotations { get; set; }

        public int? AgentId { get; set; }

        public User Suscriptor { get; set; }

        public ICollection<User> Agents { get; set; }

        public string GetFullName()
        {
            return Name + " " + Surname;
        }

    }
}
