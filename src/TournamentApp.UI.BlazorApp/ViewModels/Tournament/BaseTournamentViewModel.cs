using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace TournamentApp.UI.BlazorApp.ViewModels.Tournament
{
    public class BaseTournamentViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "het is verplicht om een de wedstrijdnaam in te vullen")]
        [MinLength(3)]
        public string TournamentName { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
