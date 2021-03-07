using System;

namespace Alakazam.Framework
{
    public class Guard
    {
        public static void That(bool condition, Exception error) 
        {
            if (condition)
                throw error;
        }
    }
}