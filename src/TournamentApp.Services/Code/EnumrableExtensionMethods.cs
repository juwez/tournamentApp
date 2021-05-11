using System;
using System.Collections.Generic;
using System.Linq;
using TournamentApp.Model;

namespace TournamentApp.Services.Code
{
    public static class EnumrableExtensionMethods
    {
        
        
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> coll, int numberOfLastElements)
        {
            return coll.Reverse().Take(numberOfLastElements);
        }
        
        
        


    }
}