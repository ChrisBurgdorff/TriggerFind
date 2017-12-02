using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using Trigger4.App_Code.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web;

namespace Trigger4.Controller
{
    public class Result
    {
        public int id { get; set; }
        public string value { get; set; }
        public string info { get; set; }
    }

    public class ResultObject
    {
        public int id;
        public string company;
        public string trigger;
        public string date;
        public string bodyText;
    }

    public class RequestObject
    {
        public string type;
        public string username;
        public string pw;
        public string firstName;
        public string lastName;
        public string email;
        public string comp;
        public string trig;
        //type=fake&username=sgarcia&pw=~ahib0914&firstname=~chris%lastname=~burg&email=fucki&comp=tf&trig=all
    }

    public class ResultsController : ApiController
    {
        private MyUser CreateMyUser(string gu, RequestObject req)
        {
            MyUser mu = new MyUser();

            mu.GUI = gu;
            mu.Email = req.email;
            mu.AccountType = 0;
            mu.BillingCycle = 0;
            mu.LastLogin = DateTime.Now;
            mu.FirstName = req.firstName;
            mu.LastName = req.lastName;
            mu.UserName = req.username;
            mu.StartDate = DateTime.Now;
            mu.Newsletter = "Yes";

            return mu;
        }
        
        public string ChangeCase(string oldString)
        {
            //Capitalizes every charachter after a ~ and removes the ~
            string newString = "";
            bool changeToCaps = false;
            for (int i = 0; i < oldString.Length; i++)
            {
                if (oldString[i] == '~')
                {
                    if (oldString.Length > (i + 1))
                    {
                        if (oldString[i + 1] == '~')
                        {
                            newString += '.';
                        }
                        else
                        {
                            changeToCaps = true;
                        }
                    }
                    else
                    {
                        changeToCaps = true;
                    }
                }
                else 
                {
                    if (changeToCaps)
                    {
                        newString += Char.ToUpper(oldString[i]);
                        changeToCaps = false;   
                    }
                    else {
                        newString += oldString[i];
                    }
                }
            }
            newString = newString.Replace("~", "");
            return newString;
        }
        
        public RequestObject Parse(string req)
        {
            string[] allTerms = new string[8];
            string oldPass = "";
            allTerms = req.Split('&');
            RequestObject ret = new RequestObject();
            ret.type = allTerms[0].Remove(0, 5);
            ret.username = allTerms[1].Remove(0, 9);
            oldPass = allTerms[2].Remove(0, 3);
            ret.pw = ChangeCase(oldPass);
            ret.firstName = ChangeCase(allTerms[3].Remove(0, 10));
            ret.lastName = ChangeCase(allTerms[4].Remove(0, 9));
            ret.email = ChangeCase(allTerms[5].Remove(0, 6));
            ret.comp = ChangeCase(allTerms[6].Remove(0, 5));
            ret.trig = ChangeCase(allTerms[7].Remove(0, 5));

            return ret;
        }
        // GET api/Results/GetAll/
        [ActionName("GetAll")]
        [HttpGet]
        public object jsonvalues()
        {
            var x = new
            {
                status = "Success",
                numProp = 3
            };
            return x;
        }

        // GET api/Results/GetNew/5
        [ActionName("GetNew")]
        [HttpGet]
        public object jsonvalues(int id)
        {
            var x = new
            {
                status = "Success",
                numProp = 3,
                numNew = id
            };
            return x;
        }

        //Start of real GET Methods
        // GET api/Results/GetResults/(name)
        //[ActionName("GetResults")]
        //[HttpGet]
        public object ResultFind(string id)
        {
            
            MyUserModel userModel = new MyUserModel();
            
            MyUser myUser = new MyUser();

            string userRes = "";

            myUser = userModel.GetUserByName(id);
            if (myUser != null)
            {
                userRes = myUser.Results;
            }
            else
            {
                return "User is null: " + id;
            }

            ResultModel resModel = new ResultModel();

            List<Trigger4.Result> myResults = new List<Trigger4.Result>();

            myResults = resModel.GetResultsForUser(userRes);
            
           ResultObject[] x = new ResultObject[myResults.Count];

           for (int i = 0; i < myResults.Count; i++ )
           {
               //Fix this shit.
               //Initialize??
               x[i] = new ResultObject();
               //http://stackoverflow.com/questions/20649606/nullreferenceexception-when-assigning-data-to-variable
               x[i].id = myResults[i].ID;
               x[i].date = myResults[i].DateSearched.ToString();
               x[i].company = myResults[i].Company;
               x[i].trigger = myResults[i].Triggers;
               x[i].bodyText = myResults[i].BodyText;
           }
            
            return x;
        }

        public string SignInUser(RequestObject req)
        {
            string status = "Error - Could Not Find User.";
            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();

            userStore.Context.Database.Connection.ConnectionString =
                System.Configuration.ConfigurationManager.
                ConnectionStrings["triggerDBConnectionString"].ConnectionString;

            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

            var user = manager.Find(req.username, req.pw);

            if (user != null)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                //Sign in
                authenticationManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = false
                }, userIdentity);

                //Redirect for now
                status = "Success";
            }
            else
            {
                status = "Invalid Username or Password.";
            }
            return status;
        }

        public string AddUser(RequestObject req)
        {
            string status = "";
            
            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();

            userStore.Context.Database.Connection.ConnectionString =
                System.Configuration.ConfigurationManager.
                ConnectionStrings["triggerDBConnectionString"].ConnectionString;

            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

            //Create new user and store in DB
            IdentityUser user = new IdentityUser();
            user.UserName = req.username;

            //Store new user in MyUser database
            Trigger4.App_Code.Models.MyUserModel model = new Trigger4.App_Code.Models.MyUserModel();

            string g = user.Id;
            MyUser m = CreateMyUser(g,req);
            
            try
            {
                //Create user object and add it to the Database
                IdentityResult result = manager.Create(user, req.pw);

                if (result.Succeeded)
                {
                    //Store user in MyUser dateabase
                    status = model.InsertMyUser(m);
                    status = "Success";
                    //litStatus.Text = "Got Here."

                    //Store user in database
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

                    //Set to login user by cookie
                    //var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    //Login user and redirect to Main (for now)
                    //authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                }
                else
                {
                    status = result.Errors.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                status = ex.ToString();
            }
            return status;
        }
        private Company CreateCompany(string name)
        {
            Company c = new Company();

            c.Name = name;
            return c;
        }
        protected void UpdateCompanies(MyUser u, string comps)
        {
            MyUserModel userModel = new MyUserModel();

            MyUser myUser = new MyUser();

            myUser.AccountType = u.AccountType;
            myUser.BillingCycle = u.BillingCycle;
            myUser.Email = u.Email;
            myUser.FirstName = u.FirstName;
            myUser.GUI = u.GUI;
            myUser.ID = u.ID;
            myUser.LastLogin = u.LastLogin;
            myUser.LastName = u.LastName;
            myUser.Newsletter = u.Newsletter;
            myUser.Results = u.Results;
            myUser.StartDate = u.StartDate;
            myUser.Triggers = u.Triggers;
            myUser.UserName = u.UserName;

            myUser.Companies = comps;

            userModel.UpdateMyUser(myUser.ID, myUser);
        }
        public string AddComp(RequestObject req)
        {
            string status = "";
            status += req.comp;
            MyUserModel userModel = new MyUserModel();

            MyUser myUser = new MyUser();

            myUser = userModel.GetUserByName(req.username);

            CompanyModel compModel = new CompanyModel();

            Company c = CreateCompany(req.comp);

            if (myUser != null)
            {
                Company test = compModel.GetCompanyByName(req.comp);
                string currentComps = myUser.Companies;
                if (currentComps == "" || currentComps == null)
                {
                    currentComps += req.comp;
                }
                else if (!currentComps.Contains(req.comp))
                {
                    currentComps += "," + req.comp;
                }
                if (test != null)
                {
                    UpdateCompanies(myUser, currentComps);
                    status = "Success";
                }
                else
                {
                    UpdateCompanies(myUser, currentComps);
                    string wasAdded = compModel.InsertCompany(c);
                    status = "Success";
                }
            }
            return status;
        }
        protected void UpdateTriggers(MyUser u, string trigs)
        {
            MyUserModel userModel = new MyUserModel();

            MyUser myUser = new MyUser();

            myUser.AccountType = u.AccountType;
            myUser.BillingCycle = u.BillingCycle;
            myUser.Email = u.Email;
            myUser.FirstName = u.FirstName;
            myUser.GUI = u.GUI;
            myUser.ID = u.ID;
            myUser.LastLogin = u.LastLogin;
            myUser.LastName = u.LastName;
            myUser.Newsletter = u.Newsletter;
            myUser.Results = u.Results;
            myUser.StartDate = u.StartDate;
            myUser.Companies = u.Companies;
            myUser.UserName = u.UserName;

            myUser.Triggers = trigs;

            userModel.UpdateMyUser(myUser.ID, myUser);
        }
        public string AddTrig(RequestObject req)
        {
            MyUserModel userModel = new MyUserModel();

            MyUser myUser = new MyUser();

            myUser = userModel.GetUserByName(req.username);

            string myTriggers = myUser.Triggers;

            if (myTriggers == "" || myTriggers == null)
            {
                myTriggers = req.trig;
            }
            else
            {
                myTriggers += ",";
                myTriggers += req.trig;
            }
            UpdateTriggers(myUser, myTriggers);
            string status = "Success";
            return status;
        }
        public string DeleteTrig(RequestObject req)
        {
            string status = "";
            MyUserModel userModel = new MyUserModel();

            MyUser myUser = new MyUser();

            myUser = userModel.GetUserByName(req.username);

            string myTriggers = myUser.Triggers;
            List<string> allTrigs = new List<string>();
            allTrigs = myTriggers.Split(',').ToList();
            int index = -1;
            for (int j = 0; j < allTrigs.Count; j++)
            {
                if (allTrigs[j] == req.trig)
                {
                    index = j;
                }
            }
            if (index > -1)
            {
                allTrigs.RemoveAt(index);
            }
            string newTriggers = "";
            if(allTrigs.Count > 0)
            { newTriggers = allTrigs[0]; }
            for (int j = 1; j < allTrigs.Count; j++)
            {
                newTriggers += ",";
                newTriggers += allTrigs[j];
            }
            UpdateTriggers(myUser, newTriggers);
            status = "Success";
            return status;
        }
        public string DeleteComp(RequestObject req)
        {
            string status = "";
            MyUserModel userModel = new MyUserModel();

            MyUser myUser = new MyUser();

            myUser = userModel.GetUserByName(req.username);

            string myCompanies = myUser.Companies;
            List<string> allComps = new List<string>();
            allComps = myCompanies.Split(',').ToList();
            int index = -1;
            for (int j = 0; j < allComps.Count; j++)
            {
                if (allComps[j] == req.comp)
                {
                    index = j;
                }
            }
            if (index > -1)
            {
                allComps.RemoveAt(index);
            }
            string newCompanies = "";

            if (allComps.Count > 0)
            { newCompanies = allComps[0]; }
            for (int j = 1; j < allComps.Count; j++)
            {
                newCompanies += ",";
                newCompanies += allComps[j];
            }
            UpdateCompanies(myUser, newCompanies);
            status =  "Success";
            return status;
        }
        public string GetComp(RequestObject req)
        {
            string comps = "";
            MyUserModel userModel = new MyUserModel();

            MyUser myUser = new MyUser();

            myUser = userModel.GetUserByName(req.username);
            if (myUser != null)
            {
                comps = myUser.Companies;
            }
            return comps;
        }
        public string GetTrig(RequestObject req)
        {
            string trigs = "";
            MyUserModel userModel = new MyUserModel();
            MyUser myUser = new MyUser();
            myUser = userModel.GetUserByName(req.username);
            if (myUser != null)
            {
                trigs = myUser.Triggers;
            }
            return trigs;
        }
        //Test for one long ass string
        [ActionName("GetResults")]
        [HttpGet]
        public object jsonvalues(string id)
        {
            var req = new RequestObject();
            req = Parse(id);
            var resp = new object();
            if (req.type == "add")
            {
                resp = AddUser(req);
            }
            if (req.type == "verify")
            {
                resp = SignInUser(req);
            }
            if (req.type == "get")
            {
                resp = ResultFind(req.username);
            }
            if (req.type == "addcomp")
            {
                resp = AddComp(req);
            }
            if (req.type == "addtrig")
            {
                resp = AddTrig(req);
            }
            if (req.type == "deletecomp")
            {
                resp = DeleteComp(req);
            }
            if (req.type == "deletetrig")
            {
                resp = DeleteTrig(req);
            }
            if (req.type == "getcomp")
            {
                resp = GetComp(req);
            }
            if (req.type == "gettrig")
            {
                resp = GetTrig(req);
            }
            return resp;
        }


        //Sign in user
        [ActionName("GetSignIn")]
        [HttpGet]
        public string GetSignIn(string name, string pw)
        {
            string status = "called";
            return status;
        }



        // GET api/Results/SignIn/(name+ "," + pw)
        //api/Results/name/pw/
        [ActionName("SignIn")]
        [HttpGet]
        public object jsonvalues(string name, int id, string pw)
        {
            
            string status = "Error - Could Not Find User.";
            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();

            userStore.Context.Database.Connection.ConnectionString =
                System.Configuration.ConfigurationManager.
                ConnectionStrings["triggerDBConnectionString"].ConnectionString;

            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

            var user = manager.Find(name, pw);

            if (user != null)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                //Sign in
                authenticationManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = false
                }, userIdentity);

                //Redirect for now
                status = "Sign In Was Successful.";
            }
            else
            {
                status = "Invalid Username or Password.";
            }
            return status;
        }


        // GET api/Users


        // GET api/Users/5
        

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}