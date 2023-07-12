using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Drawing;

namespace Tiny.Toolkits.Tests
{
    [TestClass()]
    public class ExtensionsTests
    {
        [TestMethod()]
        public void ToTest()
        {
            Assert.IsTrue("123".To<long>() == 123);
        }



        [TestMethod()]
        public void ToTest2()
        {
            Assert.IsTrue("123,456".To<Point>() == new Point(123, 456));
        }


        [TestMethod()]
        public void ToTest3()
        {
            Assert.IsTrue("123,456".To<string,PointF>(value =>
            {
                string[] values = value.Split(',');
                PointF valuef = new(values[0].To<float>(), values[1].To<float>());
                return valuef;
            }).X == 123);

        }



        [TestMethod()]
        public void ToTest4()
        {
 
            TypeConvertFactory<string, int> typeConvertFactory = new((s) => int.Parse(s), i => i.ToString());

            object value1 = typeConvertFactory.ConvertFrom("123");

            object value = typeConvertFactory.ConvertTo(123, typeof(int));

            Assert.IsTrue(true);
        }
    }
}