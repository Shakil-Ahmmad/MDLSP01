using System.Web;
using Mass_Data_Education.Models;

namespace Mass_Data_Education.Repository
{
    public class ContextHelper
    {
        public static MassDataEducationEntities GetContext()
        {
            if (HttpContext.Current.Items["context"] == null)
                HttpContext.Current.Items.Add("context", new MassDataEducationEntities());
            return (MassDataEducationEntities)HttpContext.Current.Items["context"];
        }
    }
}