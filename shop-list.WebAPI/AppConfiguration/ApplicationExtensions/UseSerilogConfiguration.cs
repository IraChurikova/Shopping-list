using Serilog;

namespace shop_list.WebAPI.AppConfigration.ApplicationExtensions
{
    public static partial class ApplicationExtensions
    {
        /// <summary>
        /// Use serilog configuration
        /// </summary>
        /// <param name="app"></param>
        public static void  UseSerilogConfiguration(this IApplicationBuilder app)
        {
            app.UseSerilogRequestLogging();
        }
    }
}