﻿using System.Collections.Generic;
using System.Linq;

namespace TournamentApp.Repository
{
    public static class ObjectExtensionMethods
    {
        public static IQueryable<T> ToQueryable<T>(this T instance)
        {
            return new List<T> { instance }.AsQueryable();
        }
    }
}