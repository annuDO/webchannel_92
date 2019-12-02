using Sitecore.Diagnostics;
using System;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using Sitecore.Common;
using Sitecore;

namespace Trelleborg.Foundation.SitecoreExtensions.Rules
{
  public class DateFieldPassedCondition<T> : WhenCondition<T> where T : RuleContext
  {
    public string FieldName { get; set; }

    protected override bool Execute(T ruleContext)
    {
      Assert.ArgumentNotNull((object)ruleContext, nameof(ruleContext));
      var item = ruleContext.Item;
      if (item == null || string.IsNullOrEmpty(this.FieldName)) return false;

      var fieldValue = item[this.FieldName];
      var endOfToday = DateTimeProvider.GetUtcNow().Date.AddHours(23).AddMinutes(59).AddSeconds(59);
      var fieldTime = DateUtil.ParseDateTime(fieldValue, DateTime.MaxValue,System.Globalization.CultureInfo.InvariantCulture).Date.AddHours(23).AddMinutes(59).AddSeconds(59);

      if (fieldTime.Kind != DateTimeKind.Utc)
      {
        Log.Warn(fieldValue, (object)this);
      }

      return endOfToday > fieldTime;
    }
  }
}