using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tiny.Toolkits.Wpf.Converters.Tests
{
    [TestClass()]
    public class ValueConverterTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            IValueConverter<string, int> convertr = null;

            Assert.IsTrue((convertr =  ValueConverter.Create<string, int>((s, type, p, c) =>
            {
                return int.Parse(s) + p;
            })) != null);
        }

        [TestMethod()]
        public void CreateTest2()
        {
            IValueConverter<string, int> convertr =  ValueConverter.Create<string, int>((s, type, p, c) =>
            {
                return int.Parse(s) + p;
            });

            bool result = convertr.Convert("3", 3).ToString() == "6";

            Assert.IsTrue(result);
        }


        [TestMethod()]
        public void CreateTest3()
        {
            IValueConverter<string> convertr =  ValueConverter.Create<string>((s, t, p, c) =>
            {
                return int.Parse(s);
            });

            bool result = convertr.Convert("3").To<int>() == 3;

            Assert.IsTrue(result);
        }
    }
}