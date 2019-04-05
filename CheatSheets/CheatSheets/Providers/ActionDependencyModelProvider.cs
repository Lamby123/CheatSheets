

/// <summary>
/// This is not actually necessary but it is nice to be able to inject dependencies everywhere for consistency.
/// This is a provider to ensure services are initialized and bound before the api controllers are initialized. 
/// Without this - dependencies cannot be injected into controllers as controllers attempt to bind to their services at initialization order -900. 
/// </summary>
namespace CheatSheets.Providers
{
    using Microsoft.AspNetCore.Mvc.ApplicationModels;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    /// <summary>Register services before api controller</summary>
    public class ActionDependencyModelProvider : IApplicationModelProvider
    {

        /// <summary>
        /// Set provider order to -901 because the provider responsible for ApiControllerAttribute runs at 900
        /// We would like this provider to run first to remove the need for [FromServices] annotation in our controller methods.
        /// </summary>
        public int Order => -901;

        /// <summary>Empty stub. No action required here.</summary>
        /// <param name="context">This is not used</param>
        public void OnProvidersExecuted(ApplicationModelProviderContext context)
        {
        }

        /// <summary>Inject the services to be used in Api Controller annotated controllers without [FromServices]</summary>
        /// <param name="context">App Model provider context used within all Api Controllers.</param>
        public void OnProvidersExecuting(ApplicationModelProviderContext context)
        {
            foreach (var controllerModel in context.Result.Controllers)
            {
                foreach (var actionModel in controllerModel.Actions)
                {
                    foreach (var parameterModel in actionModel.Parameters)
                    {
                        if (parameterModel.ParameterType.IsInterface)
                        {
                            parameterModel.BindingInfo = new BindingInfo()
                            {
                                BindingSource = BindingSource.Services
                            };
                        }
                    }
                }
            }
        }
    }
}
