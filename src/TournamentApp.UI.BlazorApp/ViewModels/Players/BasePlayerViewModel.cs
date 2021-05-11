using System.ComponentModel.DataAnnotations;

namespace TournamentApp.UI.BlazorApp.ViewModels.Players
{
    public class BasePlayerViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "het is verplicht om een naam in te vullen")]
        [MinLength(3)]
        [MaxLength(30)]    
        public string Name { get; set; }
    }
}