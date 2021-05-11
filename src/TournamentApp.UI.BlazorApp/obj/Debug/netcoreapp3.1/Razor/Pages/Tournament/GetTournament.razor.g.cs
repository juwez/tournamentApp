#pragma checksum "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\Pages\Tournament\GetTournament.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c2ba0df49d6fcb06c24bb7326bcd83f50f1f0f9"
// <auto-generated/>
#pragma warning disable 1591
namespace TournamentApp.UI.BlazorApp.Pages.Tournament
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\_Imports.razor"
using TournamentApp.UI.BlazorApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\_Imports.razor"
using TournamentApp.UI.BlazorApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\_Imports.razor"
using TournamentApp.UI.BlazorApp.Pages.Code;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\_Imports.razor"
using TournamentApp.UI.BlazorApp.Pages.Code.TournamentService;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\_Imports.razor"
using TournamentApp.UI.BlazorApp.Pages.Code.RoundService;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\_Imports.razor"
using TournamentApp.UI.BlazorApp.Pages.Code.PlayersService;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\_Imports.razor"
using TournamentApp.UI.BlazorApp.ViewModels.Tournament;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\_Imports.razor"
using TournamentApp.UI.BlazorApp.Pages.Code.MatchService;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/tournaments/{key}")]
    public partial class GetTournament : GetTournamentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 5 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\Pages\Tournament\GetTournament.razor"
 if (TournamentViewModel == null && Rounds == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<div class=\"spinner\"></div>");
#nullable restore
#line 8 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\Pages\Tournament\GetTournament.razor"

}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "container");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "row");
            __builder.AddMarkupContent(5, "<div class=\"col-xs-2\"></div>\n            ");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "col-xs-8");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "row");
            __builder.OpenElement(10, "h1");
            __builder.AddAttribute(11, "class", "mr-5");
            __builder.AddContent(12, "Ziehier alle hoofdroundes voor ");
            __builder.AddContent(13, 
#nullable restore
#line 19 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\Pages\Tournament\GetTournament.razor"
                                                                     TournamentViewModel.TournamentName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\n                ");
            __builder.OpenElement(15, "div");
            __builder.AddAttribute(16, "class", "row");
#nullable restore
#line 22 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\Pages\Tournament\GetTournament.razor"
                     foreach (var item in Rounds)
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(17, "div");
            __builder.AddAttribute(18, "class", "card mt-3 mr-3");
            __builder.AddAttribute(19, "style", "width: 18rem;");
            __builder.OpenElement(20, "div");
            __builder.AddAttribute(21, "class", "card-body");
            __builder.OpenElement(22, "h5");
            __builder.AddAttribute(23, "class", "card-title");
            __builder.AddContent(24, 
#nullable restore
#line 26 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\Pages\Tournament\GetTournament.razor"
                                                        item.RoundName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\n                                ");
            __builder.OpenElement(26, "h6");
            __builder.AddAttribute(27, "class", "card-subtitle mb-2 text-muted");
            __builder.AddContent(28, 
#nullable restore
#line 27 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\Pages\Tournament\GetTournament.razor"
                                                                           item.Key

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "\n                                ");
            __builder.AddMarkupContent(30, @"<p class=""card-text"">
                                I => Details van de ronde,<br>
                                    Trash => Verwijderen van de ronde <br>
                                    Subroundes => De subroundes <br></p>
                                ");
            __builder.OpenElement(31, "a");
            __builder.AddAttribute(32, "href", "/tournaments/" + (
#nullable restore
#line 33 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\Pages\Tournament\GetTournament.razor"
                                                       item.TournamentKey

#line default
#line hidden
#nullable disable
            ) + "/rounds/" + (
#nullable restore
#line 33 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\Pages\Tournament\GetTournament.razor"
                                                                                  item.Key

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(33, "class", "btn btn-info");
            __builder.AddMarkupContent(34, "<i class=\"fas fa-info-circle fa-2x\"></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 36 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\Pages\Tournament\GetTournament.razor"
                    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 41 "C:\Users\joey\Downloads\TournamentApp\src\TournamentApp.UI.BlazorApp\Pages\Tournament\GetTournament.razor"

}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
