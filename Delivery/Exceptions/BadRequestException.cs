﻿namespace Delivery.Exceptions
{
    public class BadRequestException :ApplicationException
    {
        public BadRequestException (string message) : base(message)
        {

        }
    }
}
