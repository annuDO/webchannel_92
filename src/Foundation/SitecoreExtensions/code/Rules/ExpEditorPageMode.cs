using Sitecore;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;

namespace Trelleborg.Foundation.SitecoreExtensions.Rules
{
  public class ExpEditorPageMode<T> : StringOperatorCondition<T>
        where T : RuleContext
  {
    protected override bool Execute(T ruleContext)
    {
      return Context.PageMode.IsExperienceEditor;
    }
  }
}