using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
//using DLBi.Sitecore.Helpers;
using Sitecore;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Layouts;

namespace Trelleborg.Foundation.Indexing
{
  //TODO: Implement Computed field 
  ///// <summary>
  ///// Computed field that contains all textual content of items that are rendering data sources on the current item's layout details
  ///// </summary>
  //public class SubcontentField : IComputedIndexField
  //  {
  //      public object ComputeFieldValue(IIndexable indexable)
  //      {
  //          var sitecoreIndexable = indexable as SitecoreIndexableItem;

  //          if (sitecoreIndexable == null) return null;

  //          // find renderings with datasources set
  //          var customDataSources = ExtractRenderingDataSourceItems(sitecoreIndexable.Item);

  //          // extract text from data sources
  //          var contentToAdd = customDataSources.SelectMany(GetItemContent).ToList();

  //          if (contentToAdd.Count == 0) return null;

  //          return string.Join(" ", contentToAdd);
  //      }

  //      /// <summary>
  //      /// Finds all renderings on an item's layout details with valid custom data sources set and returns the data source items.
  //      /// </summary>
  //      protected virtual IEnumerable<Item> ExtractRenderingDataSourceItems(Item baseItem)
  //      {
  //          string currentLayoutXml = LayoutField.GetFieldValue(baseItem.Fields[FieldIDs.LayoutField]);
  //          if (string.IsNullOrEmpty(currentLayoutXml)) yield break;

  //          LayoutDefinition layout = LayoutDefinition.Parse(currentLayoutXml);

  //          // loop over devices in the rendering
  //          for (int deviceIndex = layout.Devices.Count - 1; deviceIndex >= 0; deviceIndex--)
  //          {
  //              var device = layout.Devices[deviceIndex] as DeviceDefinition;

  //              if (device == null) continue;

  //              // loop over renderings within the device
  //              for (int renderingIndex = device.Renderings.Count - 1; renderingIndex >= 0; renderingIndex--)
  //              {
  //                  var rendering = device.Renderings[renderingIndex] as RenderingDefinition;

  //                  if (rendering == null) continue;

  //                  // if the rendering has a custom data source, we resolve the data source item and place its text fields into the content to add
  //                  if (!string.IsNullOrWhiteSpace(rendering.Datasource))
  //                  {
  //                      // DataSourceHelper is a component of Blade
  //                      var dataSource = DataSourceHelper.ResolveDataSource(rendering.Datasource, baseItem);

  //                      if (dataSource == null) continue;

  //                      if (dataSource != baseItem)
  //                      {
  //                          yield return dataSource;
  //                      }
  //                  }
  //              }
  //          }

  //      }

  //      /// <summary>
  //      /// Extracts textual content from an item's fields
  //      /// </summary>
  //      protected virtual IEnumerable<string> GetItemContent(Item dataSource)
  //      {
  //          Assert.ArgumentNotNull(dataSource, "DataSource");

  //          if (dataSource.Fields == null) yield return string.Empty;

  //          foreach (Field field in dataSource.Fields)
  //          {
  //              // this check is what Sitecore uses to determine if a field belongs in _content (see LuceneDocumentBuilder.AddField())
  //              if (!IndexOperationsHelper.IsTextField(new SitecoreItemDataField(field))) continue;
                
  //              string fieldValue = string.IsNullOrWhiteSpace(field.Value) ? string.Empty : HttpUtility.HtmlDecode(global::Sitecore.StringUtil.RemoveTags(field.Value));

  //              if (!string.IsNullOrWhiteSpace(fieldValue)) yield return fieldValue;
  //          }
  //      }

  //      public string FieldName { get; set; }
  //      public string ReturnType { get; set; }
  //  }
}

