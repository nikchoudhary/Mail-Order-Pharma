using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailOrderPharmacy_Authorization.Repository
{
    public class Auth:IAuth
    {
        public dynamic Login(Authorization obj)
        {
            return ("Ok");
        }
    }
}
