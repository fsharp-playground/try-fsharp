using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs
{
    public class PrimitiveSpec
    {
        [Test]
        public void ShouldPrintMaxValue()
        {
            var max = Int32.MaxValue;
            var min = Int32.MinValue;

            Assert.AreEqual(max, 63);
            Assert.AreEqual(min, -63);
        }
    }
}
