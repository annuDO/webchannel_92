
using Sitecore.Data.Items;
using System.Collections.Generic;
using Trelleborg.Feature.ContextSelector.Models;

namespace Trelleborg.Feature.ContextSelector.Repositories
{

  public interface ISiteSelectorRepository
  {


     List<SiteSelectorBU> GetSiteSelectorBUItems(Item sourceItem);
    

    }
}
