using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMatrixCore.Extensions
{
    public static class ExceptionExtension
    {
        public static string OutputMessage(this Exception ex)
        {
            string msg = string.Empty;
            if (ex != null)
            {
                msg += ex.Message;
                if (ex.InnerException != null)
                {
                    msg = " " + ex.InnerException.Message;
                    if (ex.InnerException.InnerException != null)
                        msg = " " + ex.InnerException.InnerException.Message;
                }
            }

            return msg;
        }
    }
}
