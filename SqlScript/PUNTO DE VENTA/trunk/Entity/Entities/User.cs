using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class User
    {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Telephone { get; set; }
            public string Email { get; set; }
            public string Salt { get; set; }
            public string PasswordEncoded { get; set; }
            public string ChangePasswordToken { get; set; }
            public int UserOrigin { get; set; }
            public int UserStatus { get; set; }
            public DateTime DateCreated { get; set; }
            public DateTime LastDateModified { get; set; }
            public DateTime LastLogin { get; set; }
            public int UserType { get; set; }
            public int? VirtualOfficeId { get; set; }
            public int? Suscriptor_Id { get; set; }
            public int? AgentId { get; set; }

        public class Parameter
        {
            public Nullable<int> id {get; set;}
            public string username {get; set;}
            public string name {get; set;}
            public string surname {get; set;}
            public string telephone {get; set;}
            public string email {get; set;}
            public string salt {get; set;}
            public string passwordEncoded {get; set;}
            public string changePasswordToken {get; set;}
            public Nullable<int> userOrigin {get; set;}
            public Nullable<int> userStatus {get; set;}
            public Nullable<int> userType {get; set;}
            public Nullable<int> virtualOfficeId {get; set;}
            public Nullable<int> suscriptor_Id {get; set;}
            public Nullable<int> agentId { get; set; }
        }
    }
}
