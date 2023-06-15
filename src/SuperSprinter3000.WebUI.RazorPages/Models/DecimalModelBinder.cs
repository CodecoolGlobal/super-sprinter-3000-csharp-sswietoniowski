using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace SuperSprinter3000.WebUI.RazorPages.Models;

public class DecimalModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        var modelName = bindingContext.ModelName;

        // Try to fetch the value of the argument by name
        var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }

        var valueAsString = valueProviderResult.FirstValue;

        // Replace comma with dot for locales that use comma as decimal separator
        valueAsString = valueAsString?.Replace(',', '.');

        decimal valueAsDecimal;

        if (!decimal.TryParse(valueAsString, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out valueAsDecimal))
        {
            // Error parsing
            bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, "Could not parse decimal number.");
            return Task.CompletedTask;
        }

        bindingContext.Result = ModelBindingResult.Success(valueAsDecimal);
        return Task.CompletedTask;
    }
}