using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace EVALUATION.WEB.Results
{
    public class WrappedHttpActionResult : IHttpActionResult
    {
        private IHttpActionResult _innerResult;
        private string _responsePhrase;
        private Action<HttpResponseMessage> _responseAction;

        public WrappedHttpActionResult(IHttpActionResult inner, Action<HttpResponseMessage> responseAction)
            : this(inner, null, responseAction)
        {
        }

        public WrappedHttpActionResult(IHttpActionResult inner, string responsePhrase, Action<HttpResponseMessage> responseAction = null)
        {
            _innerResult = inner;
            _responsePhrase = responsePhrase;
            _responseAction = responseAction;
        }

        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = await _innerResult.ExecuteAsync(cancellationToken);
            if (!string.IsNullOrWhiteSpace(_responsePhrase))
            {
                response.ReasonPhrase = _responsePhrase;
            }
            if (_responseAction != null)
            {
                _responseAction(response);
            }
            return response;
        }
    }

    public static class IHttpActionResultExtensions
    {
        public static IHttpActionResult With(this IHttpActionResult inner, string responsePhrase = null, Action<HttpResponseMessage> responseAction = null)
        {
            return new WrappedHttpActionResult(inner, responsePhrase, responseAction);
        }

        public static IHttpActionResult With(this IHttpActionResult inner, Action<HttpResponseMessage> responseAction)
        {
            return new WrappedHttpActionResult(inner, responseAction);
        }
    }
}
