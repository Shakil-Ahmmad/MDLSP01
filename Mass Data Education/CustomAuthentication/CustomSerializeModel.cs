using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mass_Data_Education.CustomAuthentication
{
    public class CustomSerializeModel
    {
        public string Id { get; set; }
        public int InstituteID { get; set; }
        public string Name { get; set; }
        public string UserType { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
    }
}