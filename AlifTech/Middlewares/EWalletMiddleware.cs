using AlifTech.Service.Exceptions;

namespace AlifTech.Api.Middlewares
{
    public sealed class EWalletMiddleware
    {
        private readonly RequestDelegate next;

        public EWalletMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (EWalletException ex)
            {
                await HandleExceptionAsync(context, ex.Code, ex.Message);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, 500, ex.Message);
            }
        }
        public async Task HandleExceptionAsync(HttpContext context, int code, string message)
        {
            context.Response.StatusCode = code;
            await context.Response.WriteAsJsonAsync(new
            {
                Code = code,
                Message = message
            });
        }
    }
}
