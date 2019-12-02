

using Sitecore.Data;
using System.Runtime.InteropServices;

namespace Trelleborg.Foundation.SitecoreExtensions
{
  public static class Templates
  {
    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct _LinkAttributes
    {
      public static readonly ID ID = ID.Parse("{6CACB1F5-9F58-4C9B-A1C2-F50E82691869}");

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Fields
      {
        public static ID LinkAttributes { get; } = new ID("{34400B24-5666-4295-BBC2-B87C2020AA6D}");
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct _DataAttributes
    {
      public static readonly ID ID = ID.Parse("{74E42A46-5955-4990-BDA5-695F42A8A94D}");

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Fields
      {
        public static ID DataAttributes { get; } = new ID("{C35B2285-B4A8-406F-A91C-24A60391DC12}");
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct _RenderingVariantsBase
    {
      public static readonly ID ID = ID.Parse("{EB94D770-9923-4A66-9C54-420566368FB2}");
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct _VariantPaging
    {
      public static readonly ID ID = ID.Parse("{308A13CD-1BA2-4377-80E4-CE4BA4663AD5}");

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Fields
      {
        public static ID MaxNumberOfResults { get; } = new ID("{3028C974-C209-4E52-881C-8B8456FAC1AA}");

        public static ID NumberOfResultsToSkip { get; } = new ID("{AE6DB294-8D8B-45BE-919C-1143867BC03D}");
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct VariantDate
    {
      public static readonly ID ID = ID.Parse("{DC4EBC23-A470-4B5D-8DF8-4A55FA823BB4}");

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Fields
      {
        public static ID DateFormat { get; } = new ID("{00AA3E05-DD03-47A9-AA1B-03A4DFBB3156}");

        public static ID Tag { get; } = new ID("{DB805BDC-8EEC-4238-B174-2427B6F1F077}");

        public static ID FieldName { get; } = new ID("{4753764C-C05A-4623-841B-97F85135241C}");

        public static ID Prefix { get; } = new ID("{FD5230D8-E68D-4E17-9D85-EA676F27AC3A}");

        public static ID Suffix { get; } = new ID("{15867CB6-E128-4D78-9D4F-739E5963DFC4}");

        public static ID IsLink { get; } = new ID("{DCB05E5E-7151-4226-A3B0-108C5E2F05B5}");

        public static ID IsPrefixLink { get; } = new ID("{CD6F5D0B-D11E-4FD3-A5D8-A75E6CA07A0C}");

        public static ID IsSuffixLink { get; } = new ID("{8BE1F2E3-5E71-48DF-9CC0-9BB4BCA4784D}");

        public static ID IsDownloadLink { get; } = new ID("{D2BEE344-6827-411A-8195-1E6D02312BCD}");

        public static ID CssClass { get; } = new ID("{7495124D-09B5-4CB3-B4A6-FE77A95827DA}");

        public static ID UseFieldRenderer { get; } = new ID("{7310794A-15C4-4B69-BEBE-29E084AFF571}");

        public static ID RenderIfEmpty { get; } = new ID("{FE56EAE5-D6A1-4703-92F7-4862DA6DEAC8}");
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct VariantField
    {
      public static readonly ID ID = ID.Parse("{FCD285DA-9AB2-4C8D-B185-5A7487A9BA1B}");

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Fields
      {
        public static ID Tag { get; } = new ID("{DB805BDC-8EEC-4238-B174-2427B6F1F077}");

        public static ID FieldName { get; } = new ID("{4753764C-C05A-4623-841B-97F85135241C}");

        public static ID Prefix { get; } = new ID("{FD5230D8-E68D-4E17-9D85-EA676F27AC3A}");

        public static ID Suffix { get; } = new ID("{15867CB6-E128-4D78-9D4F-739E5963DFC4}");

        public static ID IsLink { get; } = new ID("{DCB05E5E-7151-4226-A3B0-108C5E2F05B5}");

        public static ID IsPrefixLink { get; } = new ID("{CD6F5D0B-D11E-4FD3-A5D8-A75E6CA07A0C}");

        public static ID IsSuffixLink { get; } = new ID("{8BE1F2E3-5E71-48DF-9CC0-9BB4BCA4784D}");

        public static ID IsDownloadLink { get; } = new ID("{D2BEE344-6827-411A-8195-1E6D02312BCD}");

        public static ID CssClass { get; } = new ID("{7495124D-09B5-4CB3-B4A6-FE77A95827DA}");

        public static ID UseFieldRenderer { get; } = new ID("{7310794A-15C4-4B69-BEBE-29E084AFF571}");

        public static ID RenderIfEmpty { get; } = new ID("{FE56EAE5-D6A1-4703-92F7-4862DA6DEAC8}");
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct VariantPlaceholder
    {
      public static readonly ID ID = ID.Parse("{F4218805-86DD-4A01-A94D-7342FC392BCC}");

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Fields
      {
        public static ID CssClass { get; } = new ID("{E9D58E74-648F-4A20-A8EE-F95C171601B3}");

        public static ID PlaceholderKey { get; } = new ID("{E33B1E31-C30F-4F60-BB26-76BE8F12B1CB}");

        public static ID SwitchContext { get; } = new ID("{34A05F2C-F66E-4574-87DF-D2F77F823523}");
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct VariantReference
    {
      public static readonly ID ID = ID.Parse("{6354D18E-54E9-45AD-9EC7-510769DB4809}");

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Fields
      {
        public static ID PassThroughField { get; } = new ID("{6A018521-3D58-4CDD-98FC-88BE689650D5}");
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct VariantResponsiveImage
    {
      public static readonly ID ID = ID.Parse("{070A64FA-5F1B-40CC-83CB-3CE05D1895FC}");

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Fields
      {
        public static ID FieldName { get; } = new ID("{DF178DC4-B83D-46EC-8D4F-9DE85E2C996C}");

        public static ID Sizes { get; } = new ID("{42A44CE6-94CC-432B-BC69-39867351207C}");

        public static ID Widths { get; } = new ID("{64C4A943-EE2A-43AE-BF6A-E249B52CD8B5}");

        public static ID DefaultSize { get; } = new ID("{E4C798FC-30E5-46ED-990E-BCDDBF3444A1}");
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct VariantSection
    {
      public static readonly ID ID = ID.Parse("{ACA5C9A3-CDA0-49B6-893F-1D4A7CB595B0}");

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Fields
      {
        public static ID Tag { get; } = new ID("{A4D004E6-2A4B-4C53-A4F3-9C481DF71CDC}");

        public static ID CssClass { get; } = new ID("{BEA2740E-90D1-4B16-BD1D-7A7CC8605D2D}");

        public static ID IsLink { get; } = new ID("{4A997FFD-136B-409E-8DC9-FDE53AC545A3}");
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct VariantHtmlTag
    {
      public static readonly ID ID = ID.Parse("{73A99860-05A0-4DC1-82F1-10D31267E43F}");

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Fields
      {
        public static ID Tag { get; } = new ID("{71DF8BF2-CAEF-40FB-8C71-E416EB3EF75B}");

        public static ID CssClass { get; } = new ID("{20BDAD55-EAA3-4860-A28E-DD875C6FCEDC}");

        public static ID IsLink { get; } = new ID("{376D4960-BE91-45B3-911F-A0BAFB2A97D6}");
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct VariantEditFrame
    {
      public static readonly ID ID = ID.Parse("{98E1C490-65E2-4F23-A4FD-D2D496CB387B}");

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Fields
      {
        public static ID Buttons { get; } = new ID("{0A98D4BE-ED1C-4388-B156-5B586C0BA10A}");
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct VariantText
    {
      public static readonly ID ID = ID.Parse("{7C02E9F5-54B5-4EF4-BD10-F4C5D448A48C}");

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Fields
      {
        public static ID Tag { get; } = new ID("{1AA68C0B-EB67-4575-9CA8-1689C2AFF091}");

        public static ID Text { get; } = new ID("{07211F80-7FFC-4DF4-A4DE-C8956F391850}");

        public static ID IsLink { get; } = new ID("{F9926E84-399E-4070-B2ED-A31F6F542BDD}");

        public static ID CssClass { get; } = new ID("{8414031E-7B85-426C-8516-84D6223A1208}");
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct VariantModel
    {
      public static readonly ID ID = ID.Parse("{56B86FA3-4906-437F-9036-78F570B077F9}");

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Fields
      {
        public static ID Tag { get; } = new ID("{E33AE5C3-E5AC-4331-89B1-1C92B4A88595}");

        public static ID Property { get; } = new ID("{E4E43D78-4B7F-4281-8742-EBEDDCB6E737}");

        public static ID IsLink { get; } = new ID("{A18DF009-1CD6-46FB-AC03-CD786346DA32}");

        public static ID CssClass { get; } = new ID("{C3770564-392C-4FB2-B668-64CE0560EA15}");
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct VariantModelReference
    {
      public static readonly ID ID = ID.Parse("{A4E60E05-2ABD-4582-A1C2-5E39B8572CB0}");

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Fields
      {
        public static ID PassThroughModel { get; } = new ID("{1E89F254-8FED-49BF-B0AB-5B63F1F2B3FE}");
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct VariantToken
    {
      public static readonly ID ID = ID.Parse("{6ECA12E9-F4D5-4F6E-9C3C-6DF716BC593B}");

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Fields
      {
        public static ID Tag { get; } = new ID("{F8CD9E83-9A1F-4DEF-9178-710926E161D8}");

        public static ID Token { get; } = new ID("{3A4DD4DF-8D32-405F-831A-39F87A550085}");

        public static ID Prefix { get; } = new ID("{B6038067-9832-418F-B04F-C7EA5731DD5B}");

        public static ID Suffix { get; } = new ID("{D362349B-906A-4A6A-BF7F-D81FC60C3BAF}");

        public static ID IsLink { get; } = new ID("{A9AC9FBA-2873-4395-B016-FF8717D67784}");

        public static ID IsPrefixLink { get; } = new ID("{B8ECBC35-0444-41EC-8383-5C680CFCE414}");

        public static ID IsSuffixLink { get; } = new ID("{62069914-2B65-44D6-87DE-6DEE0E8878F2}");

        public static ID IsDownloadLink { get; } = new ID("{EA232DE3-EEAD-4B3D-8528-E7DE92A1B2B6}");

        public static ID CssClass { get; } = new ID("{E36EC18E-5A30-4F2E-8AE4-24AC2DBC6202}");
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct VariantTemplate
    {
      public static readonly ID ID = ID.Parse("{C645DD63-2462-470C-A48D-8B55757A2DB3}");

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Fields
      {
        public static ID Tag { get; } = new ID("{EB8432B6-DABF-48EA-B7FD-A70CF40BD300}");

        public static ID Template { get; } = new ID("{D90F5D1A-19E1-48CC-B673-47D6B5D9B3ED}");

        public static ID CssClass { get; } = new ID("{A0300A99-8D01-476C-A4CA-3FF253E6A48F}");
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct VariantQuery
    {
      public static readonly ID ID = ID.Parse("{98B41352-5A4B-4067-B924-18A4B50F0A53}");

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Fields
      {
        public static ID Query { get; } = new ID("{A48604E6-B95E-41C4-B71D-AF74365EC289}");
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct VariantDefinition
    {
      public static readonly ID ID = ID.Parse("{FB3E3034-33F8-4CE8-BE98-DD05010F4C22}");

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Fields
      {
        public static ID CssClass { get; } = new ID("{E1D5ADBA-8348-4127-9BB6-455936653839}");

        public static ID ItemCssClassField { get; } = new ID("{6E87DB8E-58A6-4613-823B-E99E244F07A0}");
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct Image
    {
      public static readonly ID ID = ID.Parse("{F1828A2C-7E5D-4BBD-98CA-320474871548}");

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Fields
      {
        public static ID Alt { get; } = new ID("{65885C44-8FCD-4A7F-94F1-EE63703FE193}");

        public static ID Width { get; } = new ID("{22EAC599-F13B-4607-A89D-C091763A467D}");

        public static ID Height { get; } = new ID("{DE2CA9E4-C117-4C8A-A139-1FF4B199D15A}");
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct File
    {
      public static readonly ID ID = ID.Parse("{962B53C4-F93B-4DF9-9821-415C867B8903}");

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Fields
      {
        public static ID MimeType { get; } = new ID("{6F47A0A5-9C94-4B48-ABEB-42D38DEF6054}");
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct Query
    {
      public static readonly ID ID = ID.Parse("{E379CA4E-EC5D-4001-9489-C0A7CECA4C94}");

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Fields
      {
        public static ID Query { get; } = new ID("{E9657877-584C-4CCF-8300-DC9246C8C80B}");

        public static ID Rules { get; } = new ID("{C187AD3C-ADC4-4813-806B-81FC305EC22C}");
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct ComponentField
    {
      public static readonly ID ID = ID.Parse("{1151B2A9-08AF-4F4D-A892-C2CC9A92EA6A}");

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Fields
      {
        public static ID RenderingItem { get; } = new ID("{06882697-DC92-477D-A99A-5D79BD2CCB8D}");

        public static ID RenderingParameters { get; } = new ID("{AF48C671-DD3E-41ED-95B3-534560BEF882}");
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct StandardRenderingParameters
    {
      public static readonly ID ID = ID.Parse("{8CA06D6A-B353-44E8-BC31-B528C7306971}");
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct ControllerRendering
    {
      public static readonly ID ID = ID.Parse("{2A3E91A0-7987-44B5-AB34-35C2D9DE83B9}");

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Fields
      {
        public static ID Controller { get; } = new ID("{E64AD073-DFCC-4D20-8C0B-FE5AA6226CD7}");

        public static ID ControllerAction { get; } = new ID("{DED9E431-3604-4921-A4B3-A6EC7636A5B6}");
      }
    }
  }
}
