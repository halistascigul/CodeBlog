using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.CORE.Extensions
{
    public static class CommonExtensions
    {
        // Recursive method
        public static Exception ToInnestException(this Exception ex)
        {
            if (ex.InnerException!=null)
            {
                return ex.InnerException.ToInnestException();
            }
            return ex;
        }

        public static int Fakt(this int num)
        {
            if (num!=1)
            {
                return (num) * Fakt(num - 1);
            }
            return num;
        }


        // 5
        // return 5 * 4 * 3 * 2 * 1

        // return Topla(15,5)+Carp(15,5)+Bol(15,5)

        // ex.ex.ex
        // ex.ToInnestException()
        // ex.ex.ToInnestException()
        // ex.ex.ex.ToInnestException()
    }
}
