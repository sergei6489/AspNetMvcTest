using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Helpers
{
    public static class ExtantionMethods
    {
        public static IEnumerable<IEnumerable<T>> GetSomeElements<T>( this IEnumerable<T> list, int pageSize )
        {
            while( list.Count() > 0 )
            {
                yield return list.Take( pageSize );
                list = list.Skip( pageSize );
            }

        }
    }
}