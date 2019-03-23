using System;

namespace IshchenkoKMAPcractice4.Exceptions
{
    class WrongDateTimeException : Exception
    {
        public override string Message => "You not born, or you already die !";
    }
}