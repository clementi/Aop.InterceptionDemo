using System;

namespace Aop.InterceptionDemo
{
    public class ImpossibleVelocityException : Exception
    {
        public ImpossibleVelocityException() : base("You can't go to warp 10 or beyond!")
        {
        }
    }
}