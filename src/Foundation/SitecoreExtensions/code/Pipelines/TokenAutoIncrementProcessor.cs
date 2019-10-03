using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Pipelines.ExpandInitialFieldValue;

namespace Trelleborg.Utilities.Pipelines.AutoIncrementProcessor
{
    class TokenAutoIncrementProcessor : ExpandInitialFieldValueProcessor
    {
        public override void Process(ExpandInitialFieldValueArgs args)
        {
            if (args.SourceField.Value.Contains("$next"))
            {
                if (args.TargetItem != null && args.TargetItem.Parent != null && args.TargetItem.Children != null)
                {
                    args.Result = args.Result.Replace("$next", args.TargetItem.Parent.Children.Count.ToString(CultureInfo.InvariantCulture));
                }
                else
                {
                    args.Result = args.Result.Replace("$next", "0");
                }
            }
        }
    }
}
