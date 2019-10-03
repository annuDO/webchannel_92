using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using Log = Sitecore.Diagnostics.Log;


namespace Trelleborg.Utilities.Auth
{
  //TODO: Implement OAuth
  /*
    public class Address
    {
        public string address_line1 { get; set; }
        public string address_line2 { get; set; }
        public string address_line3 { get; set; }
        public string zip_code { get; set; }
        public string city { get; set; }
        public string country_name { get; set; }
    }

    public class Contact
    {
        public string email { get; set; }
        public string phone { get; set; }
    }

    public class CustomerData
    {
        public string tss_customer_no { get; set; }
        public object no_range { get; set; }
        public string company_name { get; set; }
        public string mc_name { get; set; }
        public string mc_id { get; set; }
        public string client_id { get; set; }
    }

    // user object created from the JSON
    public class usermodel
    {
        public string member_name { get; set; }
        public string first_name { get; set; }
        public string surname { get; set; }
        public long? countryId { get; set; }
        public object stateId { get; set; }
        public string memberAreaAlert { get; set; }
        public string newsletterStatus { get; set; }
        public string country_code { get; set; }
        public List<string> roles { get; set; }
        public object newsletterFormat { get; set; }
        public string roleName { get; set; }
        public string redirectTo { get; set; }
        public string serviceLevel { get; set; }
        public string localContact { get; set; }
        public object roleId { get; set; }
        public string serviceLevelId { get; set; }
        public bool hasViewedHelpPage { get; set; }
        public List<object> groups { get; set; }
        public Address address { get; set; }
        public Contact contact { get; set; }
        public CustomerData customer_data { get; set; }
    }





    public class OauthRepository
    {
        private string _requesttoken_url;
        private string _authorize_url;
        private string _accesstoken_url;
        private string _userobject_url;
        private string _logincheck_url;
        private string _logout_url;
        private string _consumer_key;
        private string _consumer_secret;

        public OauthRepository()
        {
            _requesttoken_url = global::Sitecore.Configuration.Settings.GetSetting("oauth_url") + global::Sitecore.Configuration.Settings.GetSetting("request_token");
            _authorize_url = global::Sitecore.Configuration.Settings.GetSetting("oauth_url") + global::Sitecore.Configuration.Settings.GetSetting("authorize");
            _accesstoken_url = global::Sitecore.Configuration.Settings.GetSetting("oauth_url") + global::Sitecore.Configuration.Settings.GetSetting("access_token");
            _userobject_url = global::Sitecore.Configuration.Settings.GetSetting("oauth_url") + global::Sitecore.Configuration.Settings.GetSetting("echo");
            _logincheck_url = global::Sitecore.Configuration.Settings.GetSetting("oauth_url") + global::Sitecore.Configuration.Settings.GetSetting("logincheck");
            _logout_url = global::Sitecore.Configuration.Settings.GetSetting("oauth_url") + global::Sitecore.Configuration.Settings.GetSetting("logoutpage");
            _consumer_key = global::Sitecore.Configuration.Settings.GetSetting("consumer_key");
            _consumer_secret = global::Sitecore.Configuration.Settings.GetSetting("consumer_secret");

        }



        public HttpWebResponse Getusermodel()
        {
            Manager oauth1 = new Manager();

            string autURL = null;

            string reqTok = RequestToken(_requesttoken_url, oauth1);

            if (reqTok != "false")
            {
                autURL = AuthoriseToken(_authorize_url + oauth1["token"] + "&noCallback=true");
            }
            else
            {
                return null;
            }

            if (autURL == "success")
            {
                try
                {
                    string accessTok = AccessToken(_accesstoken_url, oauth1);
                    var requestUsermodel = (HttpWebRequest)WebRequest.Create(_userobject_url);
                    requestUsermodel.Method = "POST";
                    requestUsermodel.PreAuthenticate = true;
                    requestUsermodel.AllowWriteStreamBuffering = true;
                    requestUsermodel.Headers.Add("oauth_token_secret", accessTok);
                    requestUsermodel.Headers.Add("Cookie", "JSESSIONID=" + HttpUtility.UrlEncode(HttpContext.Current.Request.Cookies["JSESSIONID"].Value, System.Text.Encoding.UTF8));
               
                    return (HttpWebResponse)requestUsermodel.GetResponse();
                }
                catch
                {
                    return null;
                }
                
            }
            else
            {
                return null;
            }

        }

        public bool SCSessionCreation()
        {
            if (HttpContext.Current.Request.Cookies.AllKeys.Contains("JSESSIONID"))
            {
                if (HttpContext.Current.Session["userdetails"] == null)
                {
                    var oAuthrepo = new OauthRepository();
                    HttpWebResponse usermodel = oAuthrepo.Getusermodel();
                    usermodel userdetails = oAuthrepo.GetusermodelSerialized(usermodel);
                    if (userdetails != null)
                    {
                        HttpContext.Current.Session["userdetails"] = userdetails;
                        HttpCookie SCCookies = new HttpCookie("SITECORESESSIONID");
                        SCCookies.Value = HttpContext.Current.Request.Cookies["JSESSIONID"].Value;
                        HttpContext.Current.Response.Cookies.Add(SCCookies);

                        // Create virtual user
                        Sitecore.Security.Accounts.User virtualUser = Sitecore.Security.Authentication.AuthenticationManager.BuildVirtualUser(userdetails.contact.email, true);
                        if (virtualUser != null)
                        {
                            // You can even work with the profile if you wish
                            virtualUser.Profile.Email = userdetails.contact.email;
                            virtualUser.Profile.Name = userdetails.member_name;
                            virtualUser.Profile.FullName = userdetails.first_name + " " + userdetails.surname;
                            virtualUser.Profile.Save();

                            // Login the virtual user
                            Sitecore.Security.Authentication.AuthenticationManager.LoginVirtualUser(virtualUser);
                            Log.Info("OAuth TSS: Virtual user created for sitecore - " + virtualUser.Profile.Name, this);

                            //logout Session
                            //Sitecore.Security.Authentication.AuthenticationManager.Logout();

                        }
                    }
                }
                else
                {
                    if (CheckUser(_logincheck_url) == "false")
                    {
                        HttpContext.Current.Session["userdetails"] = null;
                        HttpContext.Current.Session.Abandon();
                    }
                }
            }
            else
            {
                // destroy the session if JSESSIONID is not found.
                HttpContext.Current.Session["userdetails"] = null;
                HttpContext.Current.Session.Abandon();
                
            }
            return true;
        }

        public usermodel GetusermodelSerialized(HttpWebResponse responseUsermodel)
        {
            if (responseUsermodel != null)
            {
                Stream responseStream = responseUsermodel.GetResponseStream();
                StreamReader responseStreamReader = new StreamReader(responseStream);
                JavaScriptSerializer responseDeserialize = new JavaScriptSerializer();
                var usermodelobjText = responseStreamReader.ReadToEnd();
                usermodel usermodelojb = (usermodel)responseDeserialize.Deserialize(usermodelobjText, typeof(usermodel));
                return usermodelojb;
            }
            else
            {
                return null;
            }

        }


        private string RequestToken(string Requesturi, Manager oauth)
        {
            try
            {
                oauth["consumer_key"] = _consumer_key;
                oauth["consumer_secret"] = _consumer_secret;
                var oAuth1Response = oauth.AcquireRequestToken(Requesturi, "POST");
                Log.Info("OAuth TSS: Request Token - " + oauth["token"], this);
                Log.Info("OAuth TSS: Request Token Successful" , this);
                return (oauth["token"]);
            }
            catch( Exception e)
            {
                Log.Error("OAuth TSS: Request Token Error", e, this);
                return ("false");
            }

        }

        private string AuthoriseToken(string Authoriseuri)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(Authoriseuri);
                request.Method = "POST";
                request.PreAuthenticate = true;
                request.AllowWriteStreamBuffering = true;
                request.ContentLength = 0;
                request.Headers.Add("Cookie", "JSESSIONID=" + HttpUtility.UrlEncode(HttpContext.Current.Request.Cookies["JSESSIONID"].Value, System.Text.Encoding.UTF8));

                var response = (HttpWebResponse)request.GetResponse();
                Log.Info("OAuth TSS: Authorize Token Successful", this);
                return ("success");
            }
            catch (Exception e)
            {
                Log.Error("OAuth TSS: Authorize Token Error", e, this);
                return ("false");
            }

        }

        private string AccessToken(string Accessuri, Manager oauth)
        {
            try
            {
                var responseToken = oauth.AcquireAccessToken(Accessuri, "POST", oauth["token"]);
                Log.Info("OAuth TSS: Access Token Successful", this);
                return responseToken.AllText.Substring(responseToken.AllText.IndexOf("oauth_token_secret=") + 19);
            }
            catch (Exception e)
            {
                Log.Error("OAuth TSS: Access Token Error", e, this);
                return ("false");
            }
        }

        public string CheckUser(string Requesturi)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(Requesturi);
                request.Method = "GET";
                request.PreAuthenticate = true;
                request.AllowWriteStreamBuffering = true;
                request.Headers.Add("Cookie", "JSESSIONID=" + HttpUtility.UrlEncode(HttpContext.Current.Request.Cookies["JSESSIONID"].Value, System.Text.Encoding.UTF8));
                var response = (HttpWebResponse)request.GetResponse();
                Log.Info("OAuth TSS: Check User Successful", this);
                return ("success");

            }

            catch (Exception e)
            {
                Log.Error("OAuth TSS: Check User Error", e, this);
                return ("false");
            }
        }

        // Call the logout url of webapi and clear the sitecore session
        public void OauthLogout()
        {
            try
            {
                if (HttpContext.Current.Request.Cookies.AllKeys.Contains("JSESSIONID"))
                {
                    var request = (HttpWebRequest)WebRequest.Create(_logout_url);
                    request.Method = "POST";
                    request.PreAuthenticate = true;
                    request.AllowWriteStreamBuffering = true;
                    request.Headers.Add("Cookie", "JSESSIONID=" + HttpUtility.UrlEncode(HttpContext.Current.Request.Cookies["JSESSIONID"].Value, System.Text.Encoding.UTF8));
                    var response = (HttpWebResponse)request.GetResponse();
                }
                HttpContext.Current.Session.Abandon();
            }
            catch(Exception e)
            {
                Log.Error("OAuth TSS: Tried logging out a user, but something went wrong", e, this);
            }
        }

    }
    */
}