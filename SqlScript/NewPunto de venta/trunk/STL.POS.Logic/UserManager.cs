﻿using Entity.Entities;
using STL.POS.Data.NewVersion.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Logic
{
    public class UserManager : BaseManager
    {
        private readonly UserRepository userRepository;
        public UserManager()
        {
            userRepository = new UserRepository();            
        }

        public BaseEntity SetUser(User.Parameter parameter)
        {
            return
                  userRepository.SetUser(parameter);
        }

        public User GetUser(int? Id, string UserName = null, int? UserType=null, int? AgentId = null)
        {
            return
                 userRepository.GetUser(Id, UserName,UserType, AgentId);
        }

    }
}