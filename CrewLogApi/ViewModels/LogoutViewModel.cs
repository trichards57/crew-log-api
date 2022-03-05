using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CrewLogApi.ViewModels
{
    public class LogoutViewModel
    {
        [BindNever]
        public string RequestId { get; set; } = string.Empty;
    }
}
