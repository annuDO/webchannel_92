using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml;
using System.Xml.Serialization;

namespace Trelleborg.Foundation.SitecoreExtensions
{
  //TODO:Enable if required
  //public static class ObjectExtensions
  //  {
  //      public static T GetPropertyValue<T>(this object obj, string propertyName, T defaultValue)
  //      {
  //          PropertyInfo property = obj.GetType().GetProperty(propertyName);
  //          if (IsNull(property))
  //              return defaultValue;
  //          object obj1 = property.GetValue(obj, null);
  //          if (!(obj1 is T))
  //              return defaultValue;
  //          else
  //              return (T)obj1;
  //      }

  //      public static void SetPropertyValue(this object obj, string propertyName, object value)
  //      {
  //          PropertyInfo property = obj.GetType().GetProperty(propertyName);
  //          if (IsNull(property))
  //              return;
  //          property.SetValue(obj, value, null);
  //      }

  //      public static bool IsNull<T>(this T @object)
  //      {
  //          return Equals(@object, null);
  //      }

  //      public static byte[] ToBinary<T>(this T o) where T : class, new()
  //      {
  //          using (MemoryStream memoryStream = new MemoryStream())
  //          {
  //              new DataContractSerializer(typeof(T)).WriteObject(memoryStream, o);
  //              return memoryStream.ToArray();
  //          }
  //      }

  //      public static T FromBinary<T>(this byte[] byteArray) where T : class, new()
  //      {
  //          DataContractSerializer contractSerializer = new DataContractSerializer(typeof(T));
  //          using (MemoryStream memoryStream = new MemoryStream())
  //          {
  //              memoryStream.Write(byteArray, 0, byteArray.Length);
  //              memoryStream.Seek(0L, SeekOrigin.Begin);
  //              return contractSerializer.ReadObject(memoryStream) as T;
  //          }
  //      }

          
  //      public static String DataContractToJson<T>(this Object obj) where T : class, new()
  //      {
  //          String jsonString = "";
  //          DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));

  //          using (MemoryStream memoryStream = new MemoryStream())
  //          {
  //              serializer.WriteObject(memoryStream, obj);
  //              memoryStream.Position = 0;
  //              StreamReader sr = new StreamReader(memoryStream);
  //            jsonString=  sr.ReadToEnd();

  //          }
  //          return jsonString;
  //      }

  //      public static String DataContractToJson(this Object obj)
  //      {
  //          String jsonString = "";
  //          DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());

  //          using (MemoryStream memoryStream = new MemoryStream())
  //          {
  //              serializer.WriteObject(memoryStream, obj);
  //              memoryStream.Position = 0;
  //              StreamReader sr = new StreamReader(memoryStream);
  //              jsonString = sr.ReadToEnd();

  //          }


   
  //          return jsonString;



  //      }


  //      public static string SerializeAsXml(this object obj)
  //      {
  //          XmlDocument xmlDocument = new XmlDocument();
  //          XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
  //          MemoryStream memoryStream = new MemoryStream();
  //          try
  //          {
  //              xmlSerializer.Serialize(memoryStream, obj);
  //              memoryStream.Position = 0L;
  //              xmlDocument.Load(memoryStream);
  //              return xmlDocument.InnerXml;
  //          }
  //          catch
  //          {
  //              throw;
  //          }
  //          finally
  //          {
  //              memoryStream.Close();
  //              memoryStream.Dispose();
  //          }
  //      }

  //      public static TAttribute GetAttribute<TAttribute>(this object value)
  //      {
  //          return Enumerable.FirstOrDefault(GetAttributes<TAttribute>(value));
  //      }

  //      public static TAttribute[] GetAttributes<TAttribute>(this object value)
  //      {
  //          return value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(TAttribute), false) as TAttribute[];
  //      }

  //      public static TAttribute GetPropertyAttribute<TAttribute>(this object classInstance, object propertyInstance)
  //      {
  //          return GetPropertyAttributes<TAttribute>(classInstance, propertyInstance.GetType().Name).FirstOrDefault();
  //      }

  //      public static TAttribute GetPropertyAttribute<TAttribute>(this object classInstance, string propertyName)
  //      {
  //          foreach (TAttribute attribute in GetPropertyAttributes<TAttribute>(classInstance, propertyName))
  //              return attribute;
  //          return default(TAttribute);
  //      }

  //      public static TAttribute[] GetPropertyAttributes<TAttribute>(this object classInstance, string propertyName)
  //      {
  //          if (classInstance == null)
  //              throw new ArgumentNullException("classInstance");
  //          else
  //              return classInstance.GetType().GetProperty(propertyName).GetCustomAttributes(typeof(TAttribute), false) as TAttribute[];
  //      }

  //      public static void Property<TProp>(Expression<Func<TProp>> expression)
  //      {
  //          var body = expression.Body as MemberExpression;

  //          if (body == null)
  //          {
  //              throw new ArgumentException("'expression' should be a member expression");
  //          }

  //          var propertyInfo = (PropertyInfo)body.Member;

  //          var propertyType = propertyInfo.PropertyType;
  //          var propertyName = propertyInfo.Name;
  //      }



  //      public static string GetPropertyName<T, P>(this object thisclass, Expression<Func<T, P>> action) where T : class
  //      {
  //          var expression = (MemberExpression)action.Body;
  //          string name = expression.Member.Name;
  //          return name;
  //          // return GetInfo(html, name);
  //      }
  //  }
}
