using Sitecore;
using Sitecore.Data.Validators;
using System.Runtime.Serialization;

namespace Trelleborg.Foundation.SitecoreExtensions.ValidationRules
{
  public class RichTextMaxLengthValidation : StandardValidator
  {

    /// <summary>
    /// Gets the name.
    /// </summary>
    /// <value>The validator name.</value>
    public override string Name
    {
      get
      {
        return "Max Length";
      }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:SitecoreRichTextMaxLengthValidation.RichTextMaxLengthValidation" /> class. 
    /// </summary>
    public RichTextMaxLengthValidation()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:SitecoreRichTextMaxLengthValidation.RichTextMaxLengthValidation" /> class. 
    /// </summary>
    /// <param name="info">
    /// The serialization info.
    /// </param>
    /// <param name="context">
    /// The context.
    /// </param>
    public RichTextMaxLengthValidation(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    /// <summary>
    /// When overridden in a derived class, this method contains the code to determine whether the value in the input control is valid.
    /// </summary>
    /// <returns>
    /// The result of the evaluation.
    /// </returns>
    protected override ValidatorResult Evaluate()
    {
      int num = MainUtil.GetInt(base.Parameters["maxlength"], 0);
      if (num <= 0)
      {
        return ValidatorResult.Valid;
      }
      string controlValidationValue = GetControlValidationValue();
      if (string.IsNullOrEmpty(controlValidationValue))
      {
        return ValidatorResult.Valid;
      }
      if (controlValidationValue.Length <= num)
      {
        return ValidatorResult.Valid;
      }
      string[] fieldDisplayName = new string[] { base.GetFieldDisplayName(), num.ToString() };
      base.Text = base.GetText("The maximum length of the field \"{0}\" is {1} characters.", fieldDisplayName);
      return base.GetFailedResult(ValidatorResult.FatalError);
    }

    /// <summary>
    /// Gets the max validator result.
    /// </summary>
    /// <remarks>
    /// This is used when saving and the validator uses a thread. If the Max Validator Result
    /// is Error or below, the validator does not have to be evaluated before saving.
    /// If the Max Validator Result is CriticalError or FatalError, the validator must have
    /// been evaluated before saving.
    /// </remarks>
    /// <returns>
    /// The max validator result.
    /// </returns>
    protected override ValidatorResult GetMaxValidatorResult()
    {
      return base.GetFailedResult(ValidatorResult.FatalError);
    }

    protected override string GetControlValidationValue()
    {
      return Sitecore.StringUtil.RemoveTags(base.GetControlValidationValue());
    }
  }
}