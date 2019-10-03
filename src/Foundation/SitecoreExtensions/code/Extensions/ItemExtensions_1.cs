
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DLBi.Sitecore.Extensions;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data.Items;
using Sitecore.Data;
using Sitecore.Forms.Core.Data;
using Sitecore.Globalization;
using Sitecore.Links;
using Sitecore.Sites;
using Sitecore.Web;
using Trelleborg.Domain;
using Trelleborg.Domain.Extensions;
using Trelleborg.Utilities.Helpers;
using Settings = Sitecore.Configuration.Settings;
using Trelleborg.Domain.ViewModels;

namespace Trelleborg.Utilities.Extensions
{
    public static class ItemExtensions
    {
        public static Boolean HasSubNavigationItems(this PageViewModel pageBase)
        {
            return pageBase.GetSubNavigationItems().Any(x => x.ShowInMenu);
        }

        public static IEnumerable<PageViewModel> GetSubNavigationItems(this PageViewModel pageBase)
        {
            return pageBase.ChildrenNew.OfType<PageViewModel>().Where(x => x.ShowInMenu)
                                                        .OrderBy(x => pageBase.SortSubNav ? x.MenuTitle : "");
        } 

        /// <summary>
        /// True if item is parent of child
        /// </summary>
        /// <param name="parent">The "would be" parent item</param>
        /// <param name="child">The child item</param>
        /// <returns></returns>
        public static Boolean IsParentOrSelf(this Item parent, Item child)
        {
            if (parent == null || child == null)
                return false;
            return parent.ID == child.ID || parent.Axes.IsAncestorOf(child);
        }

        public static Boolean ShouldRenderLevel3(this PageViewModel pageBase)
        {
            var magicNumber = Trelleborg.Utilities.Helpers.SystemItems.SettingsItem.MegaMenuMagicNumber;
            if (magicNumber > 0)
                return pageBase.GetSubNavigationItems().Count(x => x.ShowInMenu) <= magicNumber;
            else
                return pageBase.GetSubNavigationItems().Count(x => x.ShowInMenu) < 9;
        }
         

        public static KeyValuePair<string, string> GetMenuIcon(this IPageBase pageBase)
        {
            if (pageBase.TemplateId.ToString().ToUpper().Equals(IIndustryPageConstants.TemplateIdString.ToUpper()))
            {
                var page = pageBase.GetSitecoreItem();
                if (page == null || page.Fields[IIndustryPageConstants.IndustryFieldName] == null
                    || string.IsNullOrWhiteSpace(page.Fields[IIndustryPageConstants.IndustryFieldName].Value))
                    return new KeyValuePair<string, string>(string.Empty, string.Empty);

                var item = new SitecoreContext().GetItem<IndustryItem>(page.Fields[IIndustryPageConstants.IndustryFieldName].Value);
                return new KeyValuePair<string, string>(item.Icon.Alt, item.Icon.Src + "?w=50");
            }
            return new KeyValuePair<string, string>(string.Empty, string.Empty);
        }



        public static IEnumerable<IGlassBase> GetReferrers(this IGlassBase glassBase, Database database = null,
            Sitecore.Globalization.Language language = null)
        {
            //var context = new SitecoreContext();
            if (database == null) database = Sitecore.Context.Database;
            if (language == null) language = Sitecore.Context.Language;

            var linkItems = database.GetItem(new ID(glassBase.Id)).GetReferrers(database, language);

            var sitecoreService = new SitecoreService(database);
            return linkItems.Select(x => sitecoreService.CreateType<IGlassBase>(x, inferType: true));
        }

        public static String GetPageTitle(this IPageBase pageBase)
        {
            return (string.IsNullOrWhiteSpace(pageBase.PageTitle) ? pageBase.DisplayName : pageBase.PageTitle);
        }

        public static String GetMenuTitle(this IPageBase pageBase)
        {
            return (string.IsNullOrWhiteSpace(pageBase.MenuTitle) ? pageBase.DisplayName : pageBase.MenuTitle);
        }

        public static string GetItemUrl(this IGlassBase item)
        {
            return GetItemUrl(item.GetSitecoreItem());
        }

        public static string GetExteranlLink(this IGlassBase item)
        {
            var redirectItem = new SitecoreContext().GetItem<IRedirectionPage>(item.GetSitecoreItem().ID.ToString());

            if (redirectItem != null && !string.IsNullOrEmpty(redirectItem.RedirectToExteranlLink))
                return redirectItem.RedirectToExteranlLink;

            // return GetItemUrl(item.GetSitecoreItem());
            return item.Url;

        }

        /// <summary>
        /// Get absolute url for item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string GetItemUrl(this Item item)
        {
            var site = SiteContext.Current;
            UrlOptions defaultOptions = UrlOptions.DefaultOptions;
            defaultOptions.SiteResolving = Settings.Rendering.SiteResolving;
            defaultOptions.Site = SiteContext.Current;//.GetSite(site.Name);
            defaultOptions.LanguageEmbedding = LanguageEmbedding.Always;
            defaultOptions.AlwaysIncludeServerUrl = false;
            string itemUrl = LinkManager.GetItemUrl(item, defaultOptions);
            string str = site.TargetHostName;
            if (str.Contains("http://"))
                str = str.Substring("http://".Length);
            var stringBuilder = new StringBuilder();
            if (!string.IsNullOrEmpty(str))
            {
                if (itemUrl.Contains("://") && !itemUrl.Contains("http"))
                {
                    stringBuilder.Append("http://");
                    stringBuilder.Append(str);
                    if (itemUrl.IndexOf("/", 3) > 0)
                        stringBuilder.Append(itemUrl.Substring(itemUrl.IndexOf("/", 3)));
                }
                else
                {
                    stringBuilder.Append("http://");
                    stringBuilder.Append(str);
                    stringBuilder.Append(itemUrl);
                }
            }
            else if (!string.IsNullOrEmpty(site.Properties["hostname"]))
            {
                stringBuilder.Append("http://");
                stringBuilder.Append(site.Properties["hostname"]);
                stringBuilder.Append(itemUrl);
            }
            else if (itemUrl.Contains("://") && !itemUrl.Contains("http"))
            {
                stringBuilder.Append("http://");
                stringBuilder.Append(itemUrl);
            }
            else
                stringBuilder.Append(WebUtil.GetFullUrl(itemUrl));
            return stringBuilder.ToString();
        }
    }
}
