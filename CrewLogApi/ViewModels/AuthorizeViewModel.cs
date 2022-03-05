using System.ComponentModel.DataAnnotations;

namespace CrewLogApi.ViewModels
{
    public class AuthorizeViewModel
    {
        [Display(Name = "Application")]
        public string ApplicationName { get; set; } = String.Empty;

        [Display(Name = "Scope")]
        public string Scope { get; set; } = String.Empty;
    }
}
