using Microsoft.Extensions.DependencyInjection;
using Sitecore.Abstractions;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.DependencyInjection;
using Sitecore.Resources.Media;
using Sitecore.Web.UI.WebControls;
using Sitecore.XA.Foundation.RenderingVariants.Pipelines.RenderVariantField;
using Sitecore.XA.Foundation.Variants.Abstractions.Models;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.RenderVariantField;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Trelleborg.Foundation.SitecoreExtensions
{
  public class RenderCustomResponsiveImage : RenderRenderingVariantFieldProcessor
  {
    public override Type SupportedType => typeof(VariantCustomResponsiveImage);

    public override RendererMode RendererMode => RendererMode.Html;

    public override void RenderField(RenderVariantFieldArgs args)
    {
      VariantCustomResponsiveImage variantField = args?.VariantField as VariantCustomResponsiveImage;
      if (args.Item.Paths.IsMediaItem)
      {

        //args.ResultControl=CreateResponsiveImage(args.Item, variantField, args.Item.Fields[Templates.Image.Fields.Alt]?.Value);
        //args.Result=RenderControl(args.ResultControl);
      }
      else
      {
        if (string.IsNullOrWhiteSpace(variantField?.DesktopImageField))
          return;
        if (this.PageMode.IsExperienceEditorEditing)
        {
          RenderVariantFieldArgs variantFieldArgs = args;
          FieldRenderer fieldRenderer = new FieldRenderer();
          fieldRenderer.Item=args.Item;
          fieldRenderer.FieldName=variantField.DesktopImageField;
          fieldRenderer.DisableWebEditing=!args.IsControlEditable;
          variantFieldArgs.ResultControl=fieldRenderer;
          args.Result=RenderControl(args.ResultControl);
        }
        else
        {
          ImageField desktopImageField = args.Item.Fields[variantField.DesktopImageField];
          ImageField mobileImageField = args.Item.Fields[variantField.MobileImageField];
          if (desktopImageField == null )
            return;
          if (desktopImageField?.MediaItem== null)
            return;

          string altText = string.IsNullOrWhiteSpace(desktopImageField.Alt) ? mobileImageField.Alt : desktopImageField.Alt;
          args.ResultControl=((Control)this.CreateResponsiveImage(desktopImageField.MediaItem, mobileImageField.MediaItem, variantField, altText));
          args.Result=(this.RenderControl(args.ResultControl));
        }
      }
    }

    protected virtual HtmlImage CreateResponsiveImage(
      Item desktopMediaItem, Item mobileMediaItem,
      VariantCustomResponsiveImage variantResponsiveImage,
      string altText)
    {
      
      string str = ServiceLocator.ServiceProvider.GetService<BaseMediaManager>().GetMediaUrl(desktopMediaItem);
      string mobileLink = ServiceLocator.ServiceProvider.GetService<BaseMediaManager>().GetMediaUrl(mobileMediaItem);
      string sourceSet = this.GetSourceSet(variantResponsiveImage?.Widths, str, mobileLink);
      if (!string.IsNullOrWhiteSpace(variantResponsiveImage?.DefaultSize))
        str = this.AddWidthParam(str, variantResponsiveImage?.DefaultSize);
      HtmlImage htmlImage = new HtmlImage();
      htmlImage.Attributes.Add("src", str);
      if (!string.IsNullOrWhiteSpace(altText))
        htmlImage.Attributes.Add("alt", altText);
      if (!string.IsNullOrWhiteSpace(variantResponsiveImage?.Sizes))
        htmlImage.Attributes.Add("sizes", variantResponsiveImage.Sizes);
      if (!string.IsNullOrWhiteSpace(sourceSet))
        htmlImage.Attributes.Add("srcset", sourceSet);
      return htmlImage;
    }

    protected virtual string GetSourceSet(string widthsValue, string desktopLink, string mobileLink)
    {
      string str1 = string.Empty;
      int maxSize = 415;
      if (string.IsNullOrWhiteSpace(desktopLink))
        return str1;
      string str2 = widthsValue;
      char[] separator = new char[1] { ',' };
      foreach (string str3 in str2.Split(separator, StringSplitOptions.RemoveEmptyEntries))
      {
        int result;
        if (int.TryParse(str3, out result))
        {
          if (!string.IsNullOrWhiteSpace(str1) && !str1.EndsWith(",", StringComparison.OrdinalIgnoreCase))
            str1 += ",";
          str1 = str1 + this.AddWidthParam(result > maxSize? desktopLink: mobileLink, str3) + " " + str3 + "w";
        }
      }
      return str1;
    }

    protected virtual string AddWidthParam(string mediaLink, string defaultSize)
    {
      if (!string.IsNullOrWhiteSpace(defaultSize) && !string.IsNullOrEmpty(mediaLink))
      {
        int length = mediaLink.IndexOf("?", StringComparison.OrdinalIgnoreCase);
        NameValueCollection nameValueCollection = length != -1 ? HttpUtility.ParseQueryString(mediaLink.Substring(length + 1)) : HttpUtility.ParseQueryString(string.Empty);
        if (((IEnumerable<string>)nameValueCollection.AllKeys).Contains<string>("w"))
          nameValueCollection["w"] = defaultSize;
        else
          nameValueCollection.Add("w", defaultSize);
        mediaLink = length == -1 ? mediaLink + "?" + (object)nameValueCollection : mediaLink.Substring(0, length) + "?" + (object)nameValueCollection;
      }
      return this.ProtectAssetLink(mediaLink);
    }

    protected virtual string ProtectAssetLink(string link)
    {
      return HashingUtils.ProtectAssetUrl(link);
    }
  }
}
