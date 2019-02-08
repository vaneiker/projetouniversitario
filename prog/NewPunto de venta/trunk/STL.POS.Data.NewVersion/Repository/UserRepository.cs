using Entity.Entities;
using STL.POS.Data.NewVersion.EdmxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace STL.POS.Data.NewVersion.Repository
{
    public class UserRepository : BaseRepository
    {
        public UserRepository() { }

        #region Set
        public virtual BaseEntity SetUser(User.Parameter parameter)
        {
            BaseEntity result;
            IEnumerable<SP_SET_USERS_Result> temp;
            temp = PosContex.SP_SET_USERS(
                                           parameter.id,
                                           parameter.username,
                                           parameter.name,
                                           parameter.surname,
                                           parameter.telephone,
                                           parameter.email,
                                           parameter.salt,
                                           parameter.passwordEncoded,
                                           parameter.changePasswordToken,
                                           parameter.userOrigin,
                                           parameter.userStatus,
                                           parameter.userType,
                                           parameter.virtualOfficeId,
                                           parameter.suscriptor_Id,
                                           parameter.agentId
                                         );

            result = temp.Select(p => new BaseEntity
            {
                Action = p.Action,
                EntityId = p.Id
            })
            .FirstOrDefault();

            return
                 result;
        }
        #endregion

        #region Get
        public User GetUser(int? Id, string UserName = null, int? UserType = null, int? AgentId = null)
        {
            User result;
            IEnumerable<SP_GET_USERS_Result> temp;
            temp = PosContex.SP_GET_USERS(Id, UserName, UserType, AgentId);

            result = temp.Select(q => new User()
            {
                Id = q.Id,
                Username = q.Username,
                Name = q.Name,
                Surname = q.Surname,
                Telephone = q.Telephone,
                Email = q.Email,
                Salt = q.Salt,
                PasswordEncoded = q.PasswordEncoded,
                ChangePasswordToken = q.ChangePasswordToken,
                UserOrigin = q.UserOrigin,
                UserStatus = q.UserStatus,
                DateCreated = q.DateCreated,
                LastDateModified = q.LastDateModified.GetValueOrDefault(),
                LastLogin = q.LastLogin.GetValueOrDefault(),
                UserType = q.UserType,
                VirtualOfficeId = q.VirtualOfficeId,
                Suscriptor_Id = q.Suscriptor_Id,
                AgentId = q.AgentId

            })
            .FirstOrDefault();

            return result;
        }

        #endregion

    }
}
