using System;

namespace TournamentApp.Services.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string key) : base($"Invalid key found: {key}")
        {
            
        }
    }
}