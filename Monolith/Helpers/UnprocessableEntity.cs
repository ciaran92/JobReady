using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Monolith.Helpers
{
    public class UnprocessableEntity : ObjectResult
    {
        public UnprocessableEntity(ModelStateDictionary modelState) : base(new SerializableError(modelState))
        {
            if (modelState == null)
            {
                throw new ArgumentNullException(nameof(modelState));
            }
            StatusCode = 422;
        }
    }
}