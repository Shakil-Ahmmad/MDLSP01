using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Web.Security;
using System.Web.UI.WebControls;
using Mass_Data_Education.Models;
using Mass_Data_Education.CustomAuthentication;

namespace Mass_Data_Education.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Login(string ReturnUrl = "")
        {
            if (User.Identity.IsAuthenticated)
            {
                return LogOut();
            }

            var per = new LoginVM();
            ViewBag.ReturnUrl = ReturnUrl;
            return View(per);
        }

        [HttpPost]
        public ActionResult Login(LoginVM login, string ReturnUrl = "")
        {
            if (ModelState.IsValid)
            {
                var db = new MassDataEducationEntities();
                var data = db.Person.ToList();
                if (Membership.ValidateUser(login.Id, login.Password))
                {
                    var user = (CustomMembershipUser)Membership.GetUser(login.Id, false);
                    var userdata = db.Person.Find(user.Id);
                    //var registration = db.Person.Find(user.Id);
                    
                    if (user != null)
                    {
                        CustomSerializeModel userModel = new CustomSerializeModel()
                        {
                            Id = userdata.Id,
                            Name = userdata.Name,
                            Email = userdata.Email,
                            Image = userdata.Image,
                            InstituteID = Convert.ToInt32(userdata.InstituteID),
                            UserType = userdata.Type
                        };

                        string userData = JsonConvert.SerializeObject(userModel);
                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, login.Id, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);

                        string enTicket = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie faCookie = new HttpCookie("Cookie1", enTicket);
                        Response.Cookies.Add(faCookie);
                    }

                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid Username or Password");
            return View(login);
        }

        public ActionResult LogOut()
        {
            HttpCookie cookie = new HttpCookie("Cookie1", "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Access");
        }
    }
}