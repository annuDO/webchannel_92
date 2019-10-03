namespace DLBi.Sitecore.Extensions
{
    using System.Collections.Specialized;
    using System.IO;
    using System.Text;
    using System.Web;

  

    /// <summary>
    /// Extensions for Links
    /// </summary>
    public static class LinkExtensions
    {
        // http://www.seanholmesby.com/sitecore-glass-mapper-data-handler-for-a-link-list-field/
        // Render a Glass Link property on it's own. (Mainly used on individual Links 
        // in the LinkList field type).
        /// <summary>
        /// Render a LinkList list using Glass Mapper
        /// </summary>
        /// <param name="link"></param>
        /// <param name="attributes"></param>
        /// <param name="contents"></param>
        /// <returns></returns>
        public static HtmlString RenderLink(this Link link, NameValueCollection attributes = null, string contents = null)
        {
            var sb = new StringBuilder();
            using (TextWriter writer = new StringWriter(sb))
            {
                var result = GlassHtml.BeginRenderLink(link, attributes != null ? attributes.ToSafeDictionary() : null, contents, writer);
                result.Dispose();
            }
            return new HtmlString(sb.ToString());
        }

        /// <summary>
        /// Get the file extension of a Media link. Returns String.Empty if not media link.
        /// </summary>
        /// <param name="link">The Link item to get extension from</param>
        /// <returns>Part of text after last '.'</returns>
        public static string GetMediaLinkExtension(this Link link)
        {
            if (link.Type != LinkType.Media) return string.Empty;

            var index = link.Url.LastIndexOf('.');

            if (index <= 0) return string.Empty;
            // get the position where query string begins
            var position = link.Url.LastIndexOf('?');
            var ext = "";
            // avoid query strings in the file extension
            if (position <= 0)
            {
                ext = link.Url.Substring(index + 1);
            }
            else
            {
                ext = link.Url.Substring(index + 1, position - (index + 1));
            }
            

            return ext;
        }

        /// <summary>
        /// Check if link is from Media Library
        /// </summary>
        /// <param name="link">The link item to check for media path</param>
        /// <returns></returns>
        public static bool IsMediaLink(this Link link)
        {
            return link.Type == LinkType.Media;
        }
    }
}
