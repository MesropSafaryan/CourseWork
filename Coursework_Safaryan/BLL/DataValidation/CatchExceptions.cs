using System;

namespace BLL.DataValidation
{
    public class CatchExceptions : Exception
    {
        public CatchExceptions(string message) : base(message) { }
    }
}
