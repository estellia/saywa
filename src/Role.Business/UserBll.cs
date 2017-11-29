﻿using Role.Entities;
using Role.Service;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Role.Business
{
    public class UserBll : BaseBll<User>
    {
        private UserService _service;

        public UserBll(UserService service, IDatabase cache):base(service,"User",cache)
        {
            _service = service;
        }

    }
}
