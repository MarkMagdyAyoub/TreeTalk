namespace TreeTalk.Model.Services;

using Microsoft.AspNetCore.Mvc.ModelBinding;

public static class ModelStateExtensions
{
  public static IEnumerable<string> GetModelErrorMessages(this ModelStateDictionary modelState)
  {
    foreach (var item in modelState.Values)
    {
      foreach (var error in item.Errors)
      {
        yield return error.ErrorMessage;
      }
    }
  }
}