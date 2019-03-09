using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Way2Buy.BusinessObjects.Helpers;

namespace Way2Buy.BusinessObjects.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string userName, string passWord)
        {
            bool result = FormsAuthentication.Authenticate(userName, passWord);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(userName,true);
            }

            return result;
        }
    }
}
