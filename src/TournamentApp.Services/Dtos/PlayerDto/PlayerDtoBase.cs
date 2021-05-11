using System.ComponentModel.DataAnnotations;

namespace TournamentApp.Services.Dtos.PlayerDto
{
    public class PlayerDtoBase : DtoBase
    {
        [Required(ErrorMessage = "het is verplicht om een naam in te vullen")]
        [MinLength(3)]
        [MaxLength(30)]  
        public string Name { get; set; }
    }
}