﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Way2Buy.BusinessObjects.Helpers
{
    public interface IAuthProvider
    {
        bool Authenticate(string userName, string passWord);
    }
}
