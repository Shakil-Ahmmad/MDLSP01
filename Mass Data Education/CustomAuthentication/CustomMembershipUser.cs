using System;
using System.Web.Security;
using Mass_Data_Education.Models;

namespace Mass_Data_Education.CustomAuthentication
{
    public class CustomMembershipUser : MembershipUser
    {
        #region person Properties

        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public int InstituteID { get; set; }

        #endregion

        public CustomMembershipUser(Person person) : base("CustomMembership", person.Name, person.Id, person.Email, person.InstituteID.ToString(), person.Image, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
            Id = person.Id;
            Name = person.Name;
            Image = person.Image;
            Password = person.Password;
            UserType = person.Type;
            InstituteID = Convert.ToInt32(person.InstituteID);
        }
    }
}