using System.Web.Security;
//using Glass.Mapper;
//using Trelleborg.Domain.Helpers;

namespace DLBi.Sitecore.Helpers
{
  //TODO: Integrate Eloqua
  //using System;
  //  using System.Collections.Generic;
  //  using System.Collections.Specialized;
  //  using System.IO;
  //  using System.Linq;
  //  using System.Net;
  //  using System.Reflection;
  //  using System.Runtime.CompilerServices;
  //  using System.Text;
  //  using System.Web;

  //  using DLBi.Sitecore.WFFM.SaveActions;

  //  using Eloqua.Api.Rest.ClientLibrary.Models;
  //  using Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;
  //  using Eloqua.Api.Rest.ClientLibrary.Models.Data.Form;

  //  using global::Glass.Mapper.Sc;

  //  using global::Sitecore;
  //  using global::Sitecore.Common;
  //  using global::Sitecore.Data;
  //  using global::Sitecore.Data.Items;
  //  using global::Sitecore.Diagnostics;
  //  using global::Sitecore.Forms.Core.Data;
  //  using global::Sitecore.Links;
  //  using global::Sitecore.Security.Accounts;
  //  using global::Sitecore.SecurityModel;

  //  using Trelleborg.Domain;

  //  public static class EloquaHelper
  //  {

  //      public static String UtmCampaign = "utm_campaign";
  //      public static String UtmSource = "utm_source";
  //      public static String UtmMedium = "utm_medium";
  //      public static String EloquaEmail = "EloquaEmail";
  //      public static String VisitorLink = "VisitorLink";
  //      public static String CustomerGuid = "elqCustomerGUID";


  //      public static Boolean IsEloquaEnabled()
  //      {
  //          return (EloquaSetting != null);
  //      }

  //      public static string GetEloquaCookieGuid()
  //      {
  //          if (HttpContext.Current.Request.Cookies[CustomerGuid] != null)
  //          {

  //              var value = HttpContext.Current.Request.Cookies[CustomerGuid].Value;
  //              if (!string.IsNullOrEmpty(value))
  //              {
  //                  return value;
  //              }
  //          }
  //          return string.Empty;
  //      }

  //      public static string GetLoginUrl()
  //      {
  //          return IsEloquaEnabled() ? EloquaSetting.EloquaLoginPage!=null ?  EloquaSetting.EloquaLoginPage.Url : null : null;
  //      }

  //      public static string GetCreateUserUrl()
  //      {
  //          return IsEloquaEnabled() ? EloquaSetting.EloquaCreateUserPage!=null?EloquaSetting.EloquaCreateUserPage.Url :null: null;
  //      }

  //      public static string GetEloquaEndpoint()
  //      {
  //          return IsEloquaEnabled() ? EloquaSetting.EloquaApiEndpoint : null;
  //      }


  //      public static string GetEloquaCompany()
  //      {
  //          return IsEloquaEnabled() ? EloquaSetting.EloquaApiCompany : null;
  //      }

  //      public static string GetEloquaVisitorLinkForm()
  //      {
  //          return IsEloquaEnabled() ? EloquaSetting.EloquaVisitorLinkFormName : null;
  //      }

  //      public static String GetEloquaVisitorLinkEmailField()
  //      {
  //          return IsEloquaEnabled() ? EloquaSetting.EloquaVisitorLinkEmailField : null;
  //      }

  //      public static string GetEloquaBlindForm()
  //      {
  //          return IsEloquaEnabled() ? EloquaSetting.EloquaBlindFormName : null;
  //      }

  //      public static string GetEloquaSiteId()
  //      {
  //          return IsEloquaEnabled() ? EloquaSetting.EloquaSiteId : null;
  //      }

  //      public static string GetEloquaPostEndpoint()
  //      {
  //          return IsEloquaEnabled() ? EloquaSetting.EloquaPostEndpoint : null;
  //      }
  //      public static string GetEloquaUsername()
  //      {
  //          return IsEloquaEnabled() ? EloquaSetting.EloquaApiUser : null;
  //      }


  //      public static string GetEloquaContactEndpoint()
  //      {
  //          return IsEloquaEnabled() ? EloquaSetting.EloquaApiContactEndpoint : null;
  //      }
  //      public static string GetEloquaPassword()
  //      {
  //          return IsEloquaEnabled() ? EloquaSetting.EloquaApiPassword : null;
  //      }
  //      public static EloquaClient GetEloquaClient(bool isContactRequest = false)
  //      {
  //          var endpoint = isContactRequest ? GetEloquaContactEndpoint() : GetEloquaEndpoint();
  //          var company = GetEloquaCompany();
  //          var username = GetEloquaUsername();
  //          var password = GetEloquaPassword();

  //          if (string.IsNullOrEmpty(endpoint) ||
  //              string.IsNullOrEmpty(company) ||
  //              string.IsNullOrEmpty(username) ||
  //              string.IsNullOrEmpty(password)
  //              )
  //          {
  //              global::Sitecore.Diagnostics.Log.Error("Eloqua settings object is not valid", new object());
  //              return null;
  //          }

  //          return new EloquaClient(endpoint, company, username, password);
  //      }



  //      /// <summary>
  //      /// Checks if there is security access denied from reading by Anonymous user and allowed by Eloqua User 
  //      /// </summary>
  //      /// <param name="id"></param>
  //      /// <returns></returns>
  //      public static bool IsRoleProtected(Guid id)
  //      {
  //          if (!IsEloquaEnabled() || EloquaSetting.EloquaSitecoreRole.IsNullOrWhiteSpace())
  //              return false;
  //          Database database = global::Sitecore.Context.Database;
  //          Item item;
  //          using (new SecurityDisabler())
  //          {
  //              item = database.GetItem(new ID(id));
  //          }
  //          if (item != null)
  //          {
  //              User anonymous = global::Sitecore.Security.Accounts.User.FromName(@"extranet\Anonymous", false);
  //              if (!item.Security.CanRead(anonymous) && item.Security.CanRead(global::Sitecore.Security.Accounts.Role.FromName(EloquaSetting.EloquaSitecoreRole)))
  //                  return true;
  //              return false;
  //          }

  //          else
  //              return false;
  //      }

  //      /// <summary>
  //      /// Check if current user is member of EloquaRole
  //      /// </summary>
  //      /// <returns></returns>
  //      public static bool IsEloquaUser()
  //      {
  //          return User.Current != null && EloquaSetting.EloquaSitecoreRole.HasValue() && User.Current.IsInRole(EloquaSetting.EloquaSitecoreRole); //extranet\Eloqua User
  //      }

  //      public static string GetEloquaEmail()
  //      {
  //          string email = string.Empty;

  //          try
  //          {
  //              if (IsEloquaUser() && global::Sitecore.Security.Accounts.User.Current.Profile.GetCustomProperty("emailAddress") != null)
  //              {
  //                  email = global::Sitecore.Security.Accounts.User.Current.Profile.GetCustomProperty("emailAddress");
  //              }
  //          }
  //          catch (Exception ex)
  //          {
  //              global::Sitecore.Diagnostics.Log.Error("GetEloquaEmail Exception", ex, typeof(EloquaHelper));
  //          }

  //          if (string.IsNullOrEmpty(email))
  //          {
  //              var cookie = HttpContext.Current.Request.Cookies.Get("EloquaEmail");
  //              if (cookie != null && !string.IsNullOrWhiteSpace(cookie.Value))
  //              {
  //                  email = cookie.Value;
  //              }
  //          }

  //          return email;
  //      }

  //      /// <summary>
  //      /// Create a virtual user to enable Eloqua user validation
  //      /// </summary>
  //      /// <param name="email">Email address provided for Eloqua login/registration</param>
  //      /// <returns></returns>
  //      public static bool CreateEloquaVirtualUser(Contact contact)
  //      {
  //          //Log the user out if the user is already logged in.
  //          //if (global::Sitecore.Context.User.IsAuthenticated) global::Sitecore.Security.Authentication.AuthenticationManager.Logout();

  //          //global::Sitecore.Security.Accounts.User _user = global::Sitecore.Security.Authentication.AuthenticationManager.BuildVirtualUser("EloquaUser", true);
  //          global::Sitecore.Security.Accounts.User _user;
  //          var userEmail = contact.emailAddress;
  //          if (User.Exists(userEmail))
  //          {
  //              // Get the user if he exists
  //              global::Sitecore.Diagnostics.Log.Info("EloquaHelper: Auto logging in user: " + userEmail, "EloquaHelper");
  //              _user = User.FromName(userEmail,false);
  //          }
  //          else
  //          {
  //              // Create a new user with a random password
  //              global::Sitecore.Diagnostics.Log.Info("EloquaHelper: Creating new account for user: " + userEmail, "EloquaHelper");
  //              _user = User.Create(userEmail, Membership.GeneratePassword(20, 4));
  //              // set the user's email to the one provided, to be used as a default value in the login form
  //              _user.Profile.Email = contact.emailAddress;

  //              if (string.IsNullOrWhiteSpace(_user.Profile.FullName))
  //                  _user.Profile.FullName = contact.name;

  //              Type type = contact.GetType();
  //              PropertyInfo[] properties = type.GetProperties();

  //              foreach (PropertyInfo property in properties)
  //              {
  //                  string val = property.GetValue(contact, null) != null ? property.GetValue(contact, null).ToString() : string.Empty;

  //                  _user.Profile.SetCustomProperty(property.Name, val);
  //              }
                
  //              if (global::Sitecore.Security.Accounts.Role.Exists(EloquaSetting.EloquaSitecoreRole))
  //              {
  //                  _user.Roles.Add(global::Sitecore.Security.Accounts.Role.FromName(EloquaSetting.EloquaSitecoreRole));
  //              }
  //              _user.Profile.Save();
  //          }

  //          if (!global::Sitecore.Security.Authentication.AuthenticationManager.Login(userEmail))
  //          {
  //              global::Sitecore.Diagnostics.Log.Error("EloquaHelper: User could not be logged in: " + userEmail, "EloquaHelper");
  //              return false;
  //          }


  //          if (_user != null)
  //          {
  //              HttpCookie myCookie = new HttpCookie(EloquaEmail);
  //              myCookie.Value = contact.emailAddress;
  //              myCookie.Expires = DateTime.Now.AddDays(365);
  //              HttpContext.Current.Response.Cookies.Add(myCookie);


  //              // Set the utm cookies
  //              var campaign = HttpContext.Current.Request.Cookies.Get(EloquaHelper.UtmCampaign);
  //              var source = HttpContext.Current.Request.Cookies.Get(EloquaHelper.UtmSource);
  //              var medium = HttpContext.Current.Request.Cookies.Get(EloquaHelper.UtmMedium);
  //              if (campaign != null && campaign.Value.HasValue())
  //                  _user.Profile.SetCustomProperty(EloquaHelper.UtmCampaign, campaign.Value);
  //              if (source != null && source.Value.HasValue())
  //                  _user.Profile.SetCustomProperty(EloquaHelper.UtmSource, source.Value);
  //              if (medium != null && medium.Value.HasValue())
  //                  _user.Profile.SetCustomProperty(EloquaHelper.UtmMedium, medium.Value);
                    
                
  //              // Set a cookie that we should visitorlink in frontend
  //              HttpContext.Current.Response.SetCookie(new HttpCookie(VisitorLink, "1"));

  //              return global::Sitecore.Security.Authentication.AuthenticationManager.Login(_user);
  //          }
  //          return false;
  //      }


  //      public static long ConvertToUnixEpoch(DateTime date)
  //      {
  //          DateTime _unixEpochTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
  //          return (long)new TimeSpan(date.Ticks - _unixEpochTime.Ticks).TotalSeconds;
  //      }

  //      /// <summary>
  //      /// Get the settings object
  //      /// </summary>
  //      private static IEloquaSetting EloquaSetting
  //      {
  //          get
  //          {
  //              if (SystemItems.WebsiteItem != null && SystemItems.WebsiteItem.Global != null &&
  //                  SystemItems.WebsiteItem.Global.Settings != null)
  //                  return SystemItems.WebsiteItem.Global.Settings.EloquaSiteConfiguration;
  //              return null;
  //          }
  //      }

  //      public static void BlindFormSubmit(string assetName, string source = "", string medium = "", string campaign = "")
  //      {
  //          try
  //          {
  //              if (Context.User.IsAuthenticated)
  //              {

  //                  NameValueCollection data = new NameValueCollection();
  //                  data["elqFormName"] = EloquaHelper.GetEloquaBlindForm();
  //                  data["elqSiteID"] = GetEloquaSiteId(); // "1391710099";
  //                  data["elqCustomerGUID"] = EloquaHelper.GetEloquaCookieGuid();
  //                  data["elqCookieWrite"] = "0";
                    
  //                  // Set required values
  //                  data[EloquaSetting.EloquaBlindFormEmailField] = EloquaHelper.GetEloquaEmail();
  //                  data[EloquaSetting.EloquaBlindFormUrlField] = assetName;

  //                  // Set optional values
  //                  if (EloquaSetting.EloquaBlindFormUtmSourceField.HasValue() && source.HasValue())
  //                  {
  //                      data[EloquaSetting.EloquaBlindFormUtmSourceField] = source;
  //                  }
  //                  if (EloquaSetting.EloquaBlindFormUtmMediumField.HasValue() && medium.HasValue())
  //                  {
  //                      data[EloquaSetting.EloquaBlindFormUtmMediumField] = medium;
  //                  }
  //                  if (EloquaSetting.EloquaBlindFormUtmCampaignField.HasValue() && campaign.HasValue())
  //                  {
  //                      data[EloquaSetting.EloquaBlindFormUtmCampaignField] = campaign;
  //                  }

  //                  WebClient webClient = new WebClient();
  //                  // "https://s1391710099.t.eloqua.com/e/f2"
  //                  byte[] responseBytes = webClient.UploadValues(GetEloquaPostEndpoint(), "POST", data);
  //                  string response = Encoding.UTF8.GetString(responseBytes);

  //              }
  //          }
  //          catch (Exception ex)
  //          {
  //              global::Sitecore.Diagnostics.Log.Error("Blind Form Submit Exception : " + ex.Message, ex, new object());
  //          }

  //      }

        

  //      public static string GetCookieValue(string name)
  //      {
  //          if (HttpContext.Current.Request.Cookies[name] != null)
  //          {
  //              return HttpContext.Current.Request.Cookies[name].Value;
  //          }

  //          return string.Empty;
  //      }



  //      //public static string SendRequest(string endpoint, string data)
  //      //{
  //      //    var httpWebRequest = (HttpWebRequest)WebRequest.Create(endpoint);

  //      //    httpWebRequest.Method = "POST";
  //      //    httpWebRequest.ContentType = "text/json";
  //      //    var result = "";
  //      //    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
  //      //    {

  //      //        streamWriter.Write(data);
  //      //        streamWriter.Flush();
  //      //        streamWriter.Close();

  //      //        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
  //      //        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
  //      //        {
  //      //            result = streamReader.ReadToEnd();
  //      //        }
  //      //    }

  //      //    return result;
  //      //}

  //      public static int GetEloquaUserId()
  //      {
  //          int id;
  //          if (IsEloquaUser() && User.Current.Profile.GetCustomProperty("id") != null)
  //          {
  //              if (int.TryParse(global::Sitecore.Context.User.Profile.GetCustomProperty("id"), out id))
  //              {
  //                  return id;
  //              }
  //          }
  //          return -1;
  //      }


        
  //  }
}
