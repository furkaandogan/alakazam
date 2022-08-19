using System;
using Xunit;

namespace Alakazam.Basket.Domain.Test
{
    public abstract class BaseTest
    {
        protected FakeDataGenerator FakeDataGenerator { get; set; }
        public BaseTest()
        {
            FakeDataGenerator = new FakeDataGenerator();
        }
    }
}
