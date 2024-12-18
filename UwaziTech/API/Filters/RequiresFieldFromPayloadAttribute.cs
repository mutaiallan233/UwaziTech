using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UwaziTech.API.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RequiresFieldFromPayloadAttribute : Attribute, IActionFilter
    {
        private readonly string _requiredField;

        public RequiresFieldFromPayloadAttribute(string requiredField)
        {
            _requiredField = requiredField;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var payload = context.ActionArguments.Values.FirstOrDefault();// checking if action has a body parameter
            if (payload == null)
            {
                context.Result = new BadRequestObjectResult($"The payload is missing");
                return;
            }

            var field = payload.GetType().GetProperty(_requiredField);// checking if required field exists in the payload
            if (field == null)
            {
                context.Result = new BadRequestObjectResult($"The field '{_requiredField}' does not exist in the payload");
            }

            var value = field.GetValue(payload);
            if (value == null || value is string str && string.IsNullOrWhiteSpace(str))
            {
                context.Result = new BadRequestObjectResult($"The field '{_requiredField}' is required and cannot be null or empty");
            }
        }
    }
}
