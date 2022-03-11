namespace CrewLogApi
{
    //public static class AddSpaYarpExtension
    //{
    //    public static void AddSpaYarp(this IServiceCollection services)
    //    {
    //        var spaProxyConfigFile = Path.Combine(AppContext.BaseDirectory, "spa.proxy.json");
    //        if (File.Exists(spaProxyConfigFile))
    //        {
    //            var configuration = new ConfigurationBuilder()
    //                .AddJsonFile(spaProxyConfigFile)
    //                .Build();

    //            services.AddHttpForwarder();
    //            services.AddSingleton<SpaProxyLaunchManager>();
    //            services.Configure<SpaDevelopmentServerOptions>(configuration.GetSection("SpaProxyServer"));
    //        }
    //    }

    //    public static WebApplication UseSpaYarp(this WebApplication app)
    //    {
    //        var spaProxyLaunchManager = app.Services.GetService<SpaProxyLaunchManager>();

    //        if (spaProxyLaunchManager == null)
    //            return app;

    //        app.UseMiddleware<SpaProxyMiddleware>();

    //        var forwarder = app.Services.GetRequiredService<IHttpForwarder>();

    //        var spaOptions = app.Services.GetRequiredService<IOptions<SpaDevelopmentServerOptions>>().Value;

    //        // Configure our own HttpMessageInvoker for outbound calls for proxy operations
    //        var httpClient = new HttpMessageInvoker(new SocketsHttpHandler()
    //        {
    //            UseProxy = false,
    //            AllowAutoRedirect = false,
    //            AutomaticDecompression = DecompressionMethods.None,
    //            UseCookies = false
    //        });

    //        var transformer = new CustomTransformer();
    //        var requestOptions = new ForwarderRequestConfig { ActivityTimeout = TimeSpan.FromSeconds(100) };

    //        app.Map("/{**catch-all}", async httpContext =>
    //        {
    //            var error = await forwarder.SendAsync(httpContext, spaOptions.ClientUrl, httpClient, requestOptions, transformer);
    //            // Check if the proxy operation was successful
    //            if (error != ForwarderError.None)
    //            {
    //                var errorFeature = httpContext.Features.Get<IForwarderErrorFeature>();
    //                var exception = errorFeature?.Exception;
    //            }
    //        });

    //        return app;
    //    }
    //}
}
