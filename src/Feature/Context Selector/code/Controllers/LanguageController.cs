using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trelleborg.Feature.ContextSelector.Models;
using Trelleborg.Feature.ContextSelector.Repositories;

namespace Trelleborg.Feature.ContextSelector.Controllers
{
  public class LanguageController : Controller
  {
    protected ILanguageSelectorRepository LanguageSelectorRepository { get; set; }
    public LanguageController(ILanguageSelectorRepository languageSelectorRepository)
    {
      this.LanguageSelectorRepository = languageSelectorRepository;
    }


    public ActionResult LanguageSelector()
    {
      var model = new LanguageSelectorRenderingModel
      {
        ActiveLanguage = LanguageSelectorRepository.GetActiveLanguageItem(),
        SupportedLanguages = LanguageSelectorRepository.GetSupportedLanguages()?.ToList()
      };
      return this.View(model);
    }
  }
}