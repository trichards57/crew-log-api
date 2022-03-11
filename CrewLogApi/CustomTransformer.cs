using Yarp.ReverseProxy.Forwarder;

namespace CrewLogApi
{
    /// <summary>
    /// Custom request transformation
    /// </summary>
    internal class CustomTransformer : HttpTransformer
    {
        /// <summary>
        /// A callback that is invoked prior to sending the proxied request. All HttpRequestMessage
        /// fields are initialized except RequestUri, which will be initialized after the
        /// callback if no value is provided. The string parameter represents the destination
        /// URI prefix that should be used when constructing the RequestUri. The headers
        /// are copied by the base implementation, excluding some protocol headers like HTTP/2
        /// pseudo headers (":authority").
        /// </summary>
        /// <param name="httpContext">The incoming request.</param>
        /// <param name="proxyRequest">The outgoing proxy request.</param>
        /// <param name="destinationPrefix">The uri prefix for the selected destination server which can be used to create
        /// the RequestUri.</param>
        public override async ValueTask TransformRequestAsync(HttpContext httpContext, HttpRequestMessage proxyRequest, string destinationPrefix)
        {
            // Copy all request headers
            await base.TransformRequestAsync(httpContext, proxyRequest, destinationPrefix);

            // Suppress the original request header, use the one from the destination Uri.
            proxyRequest.Headers.Host = null;
        }
    }
}
