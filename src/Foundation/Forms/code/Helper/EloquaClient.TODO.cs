using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trelleborg.Foundation.Forms
{
  //TODO: Integrate Eloqua
  //using Eloqua.Api.Rest.ClientLibrary;
  //using Eloqua.Api.Rest.ClientLibrary.Models;
  //using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Contacts.Views;
  //using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Forms;
  //using Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;
  //using Eloqua.Api.Rest.ClientLibrary.Models.Data.ExternalActivities;

  //using global::Sitecore.Diagnostics;

  //public class EloquaClient
  //{
  //    private Client _client;

  //    public EloquaClient(string eloquaEndpoint, string eloquaCompany, string eloquaUsername, string eloquaPassword)
  //    {
  //        this._client = new Client(eloquaCompany, eloquaUsername, eloquaPassword, eloquaEndpoint);
  //    }

  //    public Contact CreateEloquaContact(Contact contact)
  //    {
  //        try
  //        {
  //            return this._client.Data.Contact.Post(contact);
  //        }
  //        catch (Exception ex)
  //        {
  //            Log.Error("Eloqua exception: " + ex.Message, new object());
  //            return null; // this.GetDummyContact;
  //        }

  //    }
  //    public Contact GetEloquaContact(string email)
  //    {
  //        try
  //        {
  //            var result = this._client.Data.Contact.Get(email, 1, 1);
  //            return result.elements.FirstOrDefault();
  //        }
  //        catch (Exception ex)
  //        {
  //            Log.Error("Eloqua exception: " + ex.Message, new object());
  //            return null;
  //        }
  //    }

  //    public bool CreateFormEntry(Eloqua.Api.Rest.ClientLibrary.Models.Data.Form.Form form)
  //    {
  //        try
  //        {
  //            var result = this._client.Data.Form.Post(form.id, form);
  //            return true;

  //        }
  //        catch (Exception ex)
  //        {
  //            Log.Error("Eloqua exception: " + ex.Message, new object());
  //            return false;

  //        }
  //    }

  //    public bool ContactIsValid(Contact contact)
  //    {
  //        return (contact != null && !string.IsNullOrEmpty(contact.emailAddress));
  //    }

  //    public bool ContactExist(string emailAddress)
  //    {
  //        var contact = this.GetEloquaContact(emailAddress);
  //        return contact != null && contact.id != -1;
  //    }


  //    public bool IsConnectionValid()
  //    {
  //        try
  //        {
  //            var result = this._client.Data.Contact.Get("*", 1, 1);
  //            return true;
  //        }
  //        catch
  //        {
  //            Log.Error("EloquaClient could not get a connection to Eloqua", this);
  //            return false;
  //        }
  //    }


  //    public SearchResponse<ContactField> GetEloquaContactFields()
  //    {
  //        try
  //        {
  //            return this._client.Assets.ContactFields.Get("*", 1, 1000);
  //        }
  //        catch (Exception ex)
  //        {
  //            Log.Error("Eloqua exception: " + ex.Message, new object());
  //            return null;
  //        }
  //    }

  //    private Contact GetDummyContact
  //    {
  //        get
  //        {
  //            Contact tempContact = new Contact();
  //            tempContact.emailAddress = "unknown@unknown.damn";
  //            tempContact.id = -1;
  //            tempContact.firstName = "Unknown";
  //            tempContact.lastName = "Unknown";
  //            return tempContact;
  //        }
  //    }


  //    //public void CreateEloquaActivity(int id, string activityType, string assetName, string assetType)
  //    //{
  //    //    try
  //    //    {
  //    //        ExternalActivities externalActivities = new ExternalActivities();

  //    //        externalActivities.activityDate = ConvertToUnixEpoch(DateTime.Now).ToString();
  //    //        externalActivities.activityType = activityType;
  //    //        externalActivities.depth = "complete";
  //    //        externalActivities.id = "35";
  //    //        externalActivities.name = "";
  //    //        externalActivities.assetName = assetName;
  //    //        externalActivities.assetType = assetType;
  //    //        externalActivities.contactId = id;
  //    //        externalActivities.campaignId = "1";
  //    //        externalActivities.type = "ExternalActivities";

  //    //        this._client.Data.ExternalActivity.Post(externalActivities);
  //    //    }
  //    //    catch (Exception ex)
  //    //    {
  //    //        Log.Error(ex.Message, this);
  //    //    }

  //    //}

  //    private static long ConvertToUnixEpoch(DateTime date)
  //    {
  //        return (long)new TimeSpan(date.Ticks - _unixEpochTime.Ticks).TotalSeconds;
  //    }
  //    private static DateTime _unixEpochTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

  //    public SearchResponse<Form> GetEloquaForms()
  //    {
  //        try
  //        {
  //            return _client.Assets.Form.Get("*", 1, 1000, Depth.complete);
  //        }
  //        catch (Exception ex)
  //        {
  //            Log.Error(ex.Message, this);
  //            return new SearchResponse<Form>();
  //        }

  //    }


  //    public Form GetEloquaForm(int formId)
  //    {
  //        try
  //        {
  //            return _client.Assets.Form.Get(formId, Depth.complete);
  //        }
  //        catch (Exception ex)
  //        {
  //            Log.Error(ex.Message, this);
  //            return null;
  //        }

  //    }
  //}
}
