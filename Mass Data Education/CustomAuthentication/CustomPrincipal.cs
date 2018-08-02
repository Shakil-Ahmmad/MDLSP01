using System.Linq;
using System.Security.Principal;

namespace Mass_Data_Education.CustomAuthentication
{
    public class CustomPrincipal : IPrincipal
    {
        #region Identity Properties

        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        #endregion

        public IIdentity Identity
        {
            get; private set;
        }

        public bool IsInRole(string usertype)
        {
            var roles = usertype.Split(',');
            if (roles.Contains(UserType))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public CustomPrincipal(string username)
        {
            Identity = new GenericIdentity(username);
        }
    }
}