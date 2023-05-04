

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Data;

namespace Tiny.Toolkits
{
    /// <summary>
    ///  dependency property attach
    /// </summary>
    public static class PropertyAttache
    {
        /// <summary>
        /// dependency property Property0 Property
        /// </summary>
        public static DependencyProperty Property0Property = DependencyProperty.RegisterAttached("Property0", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property0 value
        /// </summary>
        public static void SetProperty0(DependencyObject element, object value)
        {
            element.SetValue(Property0Property, value);
        }

        /// <summary>
        /// get Property0 value
        /// </summary>
        public static object GetProperty0(DependencyObject element)
        {
            return element.GetValue(Property0Property);
        }

        /// <summary>
        /// dependency property Property1 Property
        /// </summary>
        public static DependencyProperty Property1Property = DependencyProperty.RegisterAttached("Property1", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property1 value
        /// </summary>
        public static void SetProperty1(DependencyObject element, object value)
        {
            element.SetValue(Property1Property, value);
        }

        /// <summary>
        /// get Property1 value
        /// </summary>
        public static object GetProperty1(DependencyObject element)
        {
            return element.GetValue(Property1Property);
        }

        /// <summary>
        /// dependency property Property2 Property
        /// </summary>
        public static DependencyProperty Property2Property = DependencyProperty.RegisterAttached("Property2", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property2 value
        /// </summary>
        public static void SetProperty2(DependencyObject element, object value)
        {
            element.SetValue(Property2Property, value);
        }

        /// <summary>
        /// get Property2 value
        /// </summary>
        public static object GetProperty2(DependencyObject element)
        {
            return element.GetValue(Property2Property);
        }

        /// <summary>
        /// dependency property Property3 Property
        /// </summary>
        public static DependencyProperty Property3Property = DependencyProperty.RegisterAttached("Property3", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property3 value
        /// </summary>
        public static void SetProperty3(DependencyObject element, object value)
        {
            element.SetValue(Property3Property, value);
        }

        /// <summary>
        /// get Property3 value
        /// </summary>
        public static object GetProperty3(DependencyObject element)
        {
            return element.GetValue(Property3Property);
        }

        /// <summary>
        /// dependency property Property4 Property
        /// </summary>
        public static DependencyProperty Property4Property = DependencyProperty.RegisterAttached("Property4", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property4 value
        /// </summary>
        public static void SetProperty4(DependencyObject element, object value)
        {
            element.SetValue(Property4Property, value);
        }

        /// <summary>
        /// get Property4 value
        /// </summary>
        public static object GetProperty4(DependencyObject element)
        {
            return element.GetValue(Property4Property);
        }

        /// <summary>
        /// dependency property Property5 Property
        /// </summary>
        public static DependencyProperty Property5Property = DependencyProperty.RegisterAttached("Property5", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property5 value
        /// </summary>
        public static void SetProperty5(DependencyObject element, object value)
        {
            element.SetValue(Property5Property, value);
        }

        /// <summary>
        /// get Property5 value
        /// </summary>
        public static object GetProperty5(DependencyObject element)
        {
            return element.GetValue(Property5Property);
        }

        /// <summary>
        /// dependency property Property6 Property
        /// </summary>
        public static DependencyProperty Property6Property = DependencyProperty.RegisterAttached("Property6", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property6 value
        /// </summary>
        public static void SetProperty6(DependencyObject element, object value)
        {
            element.SetValue(Property6Property, value);
        }

        /// <summary>
        /// get Property6 value
        /// </summary>
        public static object GetProperty6(DependencyObject element)
        {
            return element.GetValue(Property6Property);
        }

        /// <summary>
        /// dependency property Property7 Property
        /// </summary>
        public static DependencyProperty Property7Property = DependencyProperty.RegisterAttached("Property7", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property7 value
        /// </summary>
        public static void SetProperty7(DependencyObject element, object value)
        {
            element.SetValue(Property7Property, value);
        }

        /// <summary>
        /// get Property7 value
        /// </summary>
        public static object GetProperty7(DependencyObject element)
        {
            return element.GetValue(Property7Property);
        }

        /// <summary>
        /// dependency property Property8 Property
        /// </summary>
        public static DependencyProperty Property8Property = DependencyProperty.RegisterAttached("Property8", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property8 value
        /// </summary>
        public static void SetProperty8(DependencyObject element, object value)
        {
            element.SetValue(Property8Property, value);
        }

        /// <summary>
        /// get Property8 value
        /// </summary>
        public static object GetProperty8(DependencyObject element)
        {
            return element.GetValue(Property8Property);
        }

        /// <summary>
        /// dependency property Property9 Property
        /// </summary>
        public static DependencyProperty Property9Property = DependencyProperty.RegisterAttached("Property9", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property9 value
        /// </summary>
        public static void SetProperty9(DependencyObject element, object value)
        {
            element.SetValue(Property9Property, value);
        }

        /// <summary>
        /// get Property9 value
        /// </summary>
        public static object GetProperty9(DependencyObject element)
        {
            return element.GetValue(Property9Property);
        }

        /// <summary>
        /// dependency property Property10 Property
        /// </summary>
        public static DependencyProperty Property10Property = DependencyProperty.RegisterAttached("Property10", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property10 value
        /// </summary>
        public static void SetProperty10(DependencyObject element, object value)
        {
            element.SetValue(Property10Property, value);
        }

        /// <summary>
        /// get Property10 value
        /// </summary>
        public static object GetProperty10(DependencyObject element)
        {
            return element.GetValue(Property10Property);
        }

        /// <summary>
        /// dependency property Property11 Property
        /// </summary>
        public static DependencyProperty Property11Property = DependencyProperty.RegisterAttached("Property11", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property11 value
        /// </summary>
        public static void SetProperty11(DependencyObject element, object value)
        {
            element.SetValue(Property11Property, value);
        }

        /// <summary>
        /// get Property11 value
        /// </summary>
        public static object GetProperty11(DependencyObject element)
        {
            return element.GetValue(Property11Property);
        }

        /// <summary>
        /// dependency property Property12 Property
        /// </summary>
        public static DependencyProperty Property12Property = DependencyProperty.RegisterAttached("Property12", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property12 value
        /// </summary>
        public static void SetProperty12(DependencyObject element, object value)
        {
            element.SetValue(Property12Property, value);
        }

        /// <summary>
        /// get Property12 value
        /// </summary>
        public static object GetProperty12(DependencyObject element)
        {
            return element.GetValue(Property12Property);
        }

        /// <summary>
        /// dependency property Property13 Property
        /// </summary>
        public static DependencyProperty Property13Property = DependencyProperty.RegisterAttached("Property13", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property13 value
        /// </summary>
        public static void SetProperty13(DependencyObject element, object value)
        {
            element.SetValue(Property13Property, value);
        }

        /// <summary>
        /// get Property13 value
        /// </summary>
        public static object GetProperty13(DependencyObject element)
        {
            return element.GetValue(Property13Property);
        }

        /// <summary>
        /// dependency property Property14 Property
        /// </summary>
        public static DependencyProperty Property14Property = DependencyProperty.RegisterAttached("Property14", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property14 value
        /// </summary>
        public static void SetProperty14(DependencyObject element, object value)
        {
            element.SetValue(Property14Property, value);
        }

        /// <summary>
        /// get Property14 value
        /// </summary>
        public static object GetProperty14(DependencyObject element)
        {
            return element.GetValue(Property14Property);
        }

        /// <summary>
        /// dependency property Property15 Property
        /// </summary>
        public static DependencyProperty Property15Property = DependencyProperty.RegisterAttached("Property15", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property15 value
        /// </summary>
        public static void SetProperty15(DependencyObject element, object value)
        {
            element.SetValue(Property15Property, value);
        }

        /// <summary>
        /// get Property15 value
        /// </summary>
        public static object GetProperty15(DependencyObject element)
        {
            return element.GetValue(Property15Property);
        }

        /// <summary>
        /// dependency property Property16 Property
        /// </summary>
        public static DependencyProperty Property16Property = DependencyProperty.RegisterAttached("Property16", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property16 value
        /// </summary>
        public static void SetProperty16(DependencyObject element, object value)
        {
            element.SetValue(Property16Property, value);
        }

        /// <summary>
        /// get Property16 value
        /// </summary>
        public static object GetProperty16(DependencyObject element)
        {
            return element.GetValue(Property16Property);
        }

        /// <summary>
        /// dependency property Property17 Property
        /// </summary>
        public static DependencyProperty Property17Property = DependencyProperty.RegisterAttached("Property17", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property17 value
        /// </summary>
        public static void SetProperty17(DependencyObject element, object value)
        {
            element.SetValue(Property17Property, value);
        }

        /// <summary>
        /// get Property17 value
        /// </summary>
        public static object GetProperty17(DependencyObject element)
        {
            return element.GetValue(Property17Property);
        }

        /// <summary>
        /// dependency property Property18 Property
        /// </summary>
        public static DependencyProperty Property18Property = DependencyProperty.RegisterAttached("Property18", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property18 value
        /// </summary>
        public static void SetProperty18(DependencyObject element, object value)
        {
            element.SetValue(Property18Property, value);
        }

        /// <summary>
        /// get Property18 value
        /// </summary>
        public static object GetProperty18(DependencyObject element)
        {
            return element.GetValue(Property18Property);
        }

        /// <summary>
        /// dependency property Property19 Property
        /// </summary>
        public static DependencyProperty Property19Property = DependencyProperty.RegisterAttached("Property19", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property19 value
        /// </summary>
        public static void SetProperty19(DependencyObject element, object value)
        {
            element.SetValue(Property19Property, value);
        }

        /// <summary>
        /// get Property19 value
        /// </summary>
        public static object GetProperty19(DependencyObject element)
        {
            return element.GetValue(Property19Property);
        }

        /// <summary>
        /// dependency property Property20 Property
        /// </summary>
        public static DependencyProperty Property20Property = DependencyProperty.RegisterAttached("Property20", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property20 value
        /// </summary>
        public static void SetProperty20(DependencyObject element, object value)
        {
            element.SetValue(Property20Property, value);
        }

        /// <summary>
        /// get Property20 value
        /// </summary>
        public static object GetProperty20(DependencyObject element)
        {
            return element.GetValue(Property20Property);
        }

        /// <summary>
        /// dependency property Property21 Property
        /// </summary>
        public static DependencyProperty Property21Property = DependencyProperty.RegisterAttached("Property21", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property21 value
        /// </summary>
        public static void SetProperty21(DependencyObject element, object value)
        {
            element.SetValue(Property21Property, value);
        }

        /// <summary>
        /// get Property21 value
        /// </summary>
        public static object GetProperty21(DependencyObject element)
        {
            return element.GetValue(Property21Property);
        }

        /// <summary>
        /// dependency property Property22 Property
        /// </summary>
        public static DependencyProperty Property22Property = DependencyProperty.RegisterAttached("Property22", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property22 value
        /// </summary>
        public static void SetProperty22(DependencyObject element, object value)
        {
            element.SetValue(Property22Property, value);
        }

        /// <summary>
        /// get Property22 value
        /// </summary>
        public static object GetProperty22(DependencyObject element)
        {
            return element.GetValue(Property22Property);
        }

        /// <summary>
        /// dependency property Property23 Property
        /// </summary>
        public static DependencyProperty Property23Property = DependencyProperty.RegisterAttached("Property23", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property23 value
        /// </summary>
        public static void SetProperty23(DependencyObject element, object value)
        {
            element.SetValue(Property23Property, value);
        }

        /// <summary>
        /// get Property23 value
        /// </summary>
        public static object GetProperty23(DependencyObject element)
        {
            return element.GetValue(Property23Property);
        }

        /// <summary>
        /// dependency property Property24 Property
        /// </summary>
        public static DependencyProperty Property24Property = DependencyProperty.RegisterAttached("Property24", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property24 value
        /// </summary>
        public static void SetProperty24(DependencyObject element, object value)
        {
            element.SetValue(Property24Property, value);
        }

        /// <summary>
        /// get Property24 value
        /// </summary>
        public static object GetProperty24(DependencyObject element)
        {
            return element.GetValue(Property24Property);
        }

        /// <summary>
        /// dependency property Property25 Property
        /// </summary>
        public static DependencyProperty Property25Property = DependencyProperty.RegisterAttached("Property25", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property25 value
        /// </summary>
        public static void SetProperty25(DependencyObject element, object value)
        {
            element.SetValue(Property25Property, value);
        }

        /// <summary>
        /// get Property25 value
        /// </summary>
        public static object GetProperty25(DependencyObject element)
        {
            return element.GetValue(Property25Property);
        }

        /// <summary>
        /// dependency property Property26 Property
        /// </summary>
        public static DependencyProperty Property26Property = DependencyProperty.RegisterAttached("Property26", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property26 value
        /// </summary>
        public static void SetProperty26(DependencyObject element, object value)
        {
            element.SetValue(Property26Property, value);
        }

        /// <summary>
        /// get Property26 value
        /// </summary>
        public static object GetProperty26(DependencyObject element)
        {
            return element.GetValue(Property26Property);
        }

        /// <summary>
        /// dependency property Property27 Property
        /// </summary>
        public static DependencyProperty Property27Property = DependencyProperty.RegisterAttached("Property27", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property27 value
        /// </summary>
        public static void SetProperty27(DependencyObject element, object value)
        {
            element.SetValue(Property27Property, value);
        }

        /// <summary>
        /// get Property27 value
        /// </summary>
        public static object GetProperty27(DependencyObject element)
        {
            return element.GetValue(Property27Property);
        }

        /// <summary>
        /// dependency property Property28 Property
        /// </summary>
        public static DependencyProperty Property28Property = DependencyProperty.RegisterAttached("Property28", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property28 value
        /// </summary>
        public static void SetProperty28(DependencyObject element, object value)
        {
            element.SetValue(Property28Property, value);
        }

        /// <summary>
        /// get Property28 value
        /// </summary>
        public static object GetProperty28(DependencyObject element)
        {
            return element.GetValue(Property28Property);
        }

        /// <summary>
        /// dependency property Property29 Property
        /// </summary>
        public static DependencyProperty Property29Property = DependencyProperty.RegisterAttached("Property29", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property29 value
        /// </summary>
        public static void SetProperty29(DependencyObject element, object value)
        {
            element.SetValue(Property29Property, value);
        }

        /// <summary>
        /// get Property29 value
        /// </summary>
        public static object GetProperty29(DependencyObject element)
        {
            return element.GetValue(Property29Property);
        }

        /// <summary>
        /// dependency property Property30 Property
        /// </summary>
        public static DependencyProperty Property30Property = DependencyProperty.RegisterAttached("Property30", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property30 value
        /// </summary>
        public static void SetProperty30(DependencyObject element, object value)
        {
            element.SetValue(Property30Property, value);
        }

        /// <summary>
        /// get Property30 value
        /// </summary>
        public static object GetProperty30(DependencyObject element)
        {
            return element.GetValue(Property30Property);
        }

        /// <summary>
        /// dependency property Property31 Property
        /// </summary>
        public static DependencyProperty Property31Property = DependencyProperty.RegisterAttached("Property31", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property31 value
        /// </summary>
        public static void SetProperty31(DependencyObject element, object value)
        {
            element.SetValue(Property31Property, value);
        }

        /// <summary>
        /// get Property31 value
        /// </summary>
        public static object GetProperty31(DependencyObject element)
        {
            return element.GetValue(Property31Property);
        }

        /// <summary>
        /// dependency property Property32 Property
        /// </summary>
        public static DependencyProperty Property32Property = DependencyProperty.RegisterAttached("Property32", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property32 value
        /// </summary>
        public static void SetProperty32(DependencyObject element, object value)
        {
            element.SetValue(Property32Property, value);
        }

        /// <summary>
        /// get Property32 value
        /// </summary>
        public static object GetProperty32(DependencyObject element)
        {
            return element.GetValue(Property32Property);
        }

        /// <summary>
        /// dependency property Property33 Property
        /// </summary>
        public static DependencyProperty Property33Property = DependencyProperty.RegisterAttached("Property33", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property33 value
        /// </summary>
        public static void SetProperty33(DependencyObject element, object value)
        {
            element.SetValue(Property33Property, value);
        }

        /// <summary>
        /// get Property33 value
        /// </summary>
        public static object GetProperty33(DependencyObject element)
        {
            return element.GetValue(Property33Property);
        }

        /// <summary>
        /// dependency property Property34 Property
        /// </summary>
        public static DependencyProperty Property34Property = DependencyProperty.RegisterAttached("Property34", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property34 value
        /// </summary>
        public static void SetProperty34(DependencyObject element, object value)
        {
            element.SetValue(Property34Property, value);
        }

        /// <summary>
        /// get Property34 value
        /// </summary>
        public static object GetProperty34(DependencyObject element)
        {
            return element.GetValue(Property34Property);
        }

        /// <summary>
        /// dependency property Property35 Property
        /// </summary>
        public static DependencyProperty Property35Property = DependencyProperty.RegisterAttached("Property35", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property35 value
        /// </summary>
        public static void SetProperty35(DependencyObject element, object value)
        {
            element.SetValue(Property35Property, value);
        }

        /// <summary>
        /// get Property35 value
        /// </summary>
        public static object GetProperty35(DependencyObject element)
        {
            return element.GetValue(Property35Property);
        }

        /// <summary>
        /// dependency property Property36 Property
        /// </summary>
        public static DependencyProperty Property36Property = DependencyProperty.RegisterAttached("Property36", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property36 value
        /// </summary>
        public static void SetProperty36(DependencyObject element, object value)
        {
            element.SetValue(Property36Property, value);
        }

        /// <summary>
        /// get Property36 value
        /// </summary>
        public static object GetProperty36(DependencyObject element)
        {
            return element.GetValue(Property36Property);
        }

        /// <summary>
        /// dependency property Property37 Property
        /// </summary>
        public static DependencyProperty Property37Property = DependencyProperty.RegisterAttached("Property37", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property37 value
        /// </summary>
        public static void SetProperty37(DependencyObject element, object value)
        {
            element.SetValue(Property37Property, value);
        }

        /// <summary>
        /// get Property37 value
        /// </summary>
        public static object GetProperty37(DependencyObject element)
        {
            return element.GetValue(Property37Property);
        }

        /// <summary>
        /// dependency property Property38 Property
        /// </summary>
        public static DependencyProperty Property38Property = DependencyProperty.RegisterAttached("Property38", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property38 value
        /// </summary>
        public static void SetProperty38(DependencyObject element, object value)
        {
            element.SetValue(Property38Property, value);
        }

        /// <summary>
        /// get Property38 value
        /// </summary>
        public static object GetProperty38(DependencyObject element)
        {
            return element.GetValue(Property38Property);
        }

        /// <summary>
        /// dependency property Property39 Property
        /// </summary>
        public static DependencyProperty Property39Property = DependencyProperty.RegisterAttached("Property39", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property39 value
        /// </summary>
        public static void SetProperty39(DependencyObject element, object value)
        {
            element.SetValue(Property39Property, value);
        }

        /// <summary>
        /// get Property39 value
        /// </summary>
        public static object GetProperty39(DependencyObject element)
        {
            return element.GetValue(Property39Property);
        }

        /// <summary>
        /// dependency property Property40 Property
        /// </summary>
        public static DependencyProperty Property40Property = DependencyProperty.RegisterAttached("Property40", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property40 value
        /// </summary>
        public static void SetProperty40(DependencyObject element, object value)
        {
            element.SetValue(Property40Property, value);
        }

        /// <summary>
        /// get Property40 value
        /// </summary>
        public static object GetProperty40(DependencyObject element)
        {
            return element.GetValue(Property40Property);
        }

        /// <summary>
        /// dependency property Property41 Property
        /// </summary>
        public static DependencyProperty Property41Property = DependencyProperty.RegisterAttached("Property41", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property41 value
        /// </summary>
        public static void SetProperty41(DependencyObject element, object value)
        {
            element.SetValue(Property41Property, value);
        }

        /// <summary>
        /// get Property41 value
        /// </summary>
        public static object GetProperty41(DependencyObject element)
        {
            return element.GetValue(Property41Property);
        }

        /// <summary>
        /// dependency property Property42 Property
        /// </summary>
        public static DependencyProperty Property42Property = DependencyProperty.RegisterAttached("Property42", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property42 value
        /// </summary>
        public static void SetProperty42(DependencyObject element, object value)
        {
            element.SetValue(Property42Property, value);
        }

        /// <summary>
        /// get Property42 value
        /// </summary>
        public static object GetProperty42(DependencyObject element)
        {
            return element.GetValue(Property42Property);
        }

        /// <summary>
        /// dependency property Property43 Property
        /// </summary>
        public static DependencyProperty Property43Property = DependencyProperty.RegisterAttached("Property43", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property43 value
        /// </summary>
        public static void SetProperty43(DependencyObject element, object value)
        {
            element.SetValue(Property43Property, value);
        }

        /// <summary>
        /// get Property43 value
        /// </summary>
        public static object GetProperty43(DependencyObject element)
        {
            return element.GetValue(Property43Property);
        }

        /// <summary>
        /// dependency property Property44 Property
        /// </summary>
        public static DependencyProperty Property44Property = DependencyProperty.RegisterAttached("Property44", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property44 value
        /// </summary>
        public static void SetProperty44(DependencyObject element, object value)
        {
            element.SetValue(Property44Property, value);
        }

        /// <summary>
        /// get Property44 value
        /// </summary>
        public static object GetProperty44(DependencyObject element)
        {
            return element.GetValue(Property44Property);
        }

        /// <summary>
        /// dependency property Property45 Property
        /// </summary>
        public static DependencyProperty Property45Property = DependencyProperty.RegisterAttached("Property45", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property45 value
        /// </summary>
        public static void SetProperty45(DependencyObject element, object value)
        {
            element.SetValue(Property45Property, value);
        }

        /// <summary>
        /// get Property45 value
        /// </summary>
        public static object GetProperty45(DependencyObject element)
        {
            return element.GetValue(Property45Property);
        }

        /// <summary>
        /// dependency property Property46 Property
        /// </summary>
        public static DependencyProperty Property46Property = DependencyProperty.RegisterAttached("Property46", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property46 value
        /// </summary>
        public static void SetProperty46(DependencyObject element, object value)
        {
            element.SetValue(Property46Property, value);
        }

        /// <summary>
        /// get Property46 value
        /// </summary>
        public static object GetProperty46(DependencyObject element)
        {
            return element.GetValue(Property46Property);
        }

        /// <summary>
        /// dependency property Property47 Property
        /// </summary>
        public static DependencyProperty Property47Property = DependencyProperty.RegisterAttached("Property47", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property47 value
        /// </summary>
        public static void SetProperty47(DependencyObject element, object value)
        {
            element.SetValue(Property47Property, value);
        }

        /// <summary>
        /// get Property47 value
        /// </summary>
        public static object GetProperty47(DependencyObject element)
        {
            return element.GetValue(Property47Property);
        }

        /// <summary>
        /// dependency property Property48 Property
        /// </summary>
        public static DependencyProperty Property48Property = DependencyProperty.RegisterAttached("Property48", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property48 value
        /// </summary>
        public static void SetProperty48(DependencyObject element, object value)
        {
            element.SetValue(Property48Property, value);
        }

        /// <summary>
        /// get Property48 value
        /// </summary>
        public static object GetProperty48(DependencyObject element)
        {
            return element.GetValue(Property48Property);
        }

        /// <summary>
        /// dependency property Property49 Property
        /// </summary>
        public static DependencyProperty Property49Property = DependencyProperty.RegisterAttached("Property49", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property49 value
        /// </summary>
        public static void SetProperty49(DependencyObject element, object value)
        {
            element.SetValue(Property49Property, value);
        }

        /// <summary>
        /// get Property49 value
        /// </summary>
        public static object GetProperty49(DependencyObject element)
        {
            return element.GetValue(Property49Property);
        }

        /// <summary>
        /// dependency property Property50 Property
        /// </summary>
        public static DependencyProperty Property50Property = DependencyProperty.RegisterAttached("Property50", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property50 value
        /// </summary>
        public static void SetProperty50(DependencyObject element, object value)
        {
            element.SetValue(Property50Property, value);
        }

        /// <summary>
        /// get Property50 value
        /// </summary>
        public static object GetProperty50(DependencyObject element)
        {
            return element.GetValue(Property50Property);
        }

        /// <summary>
        /// dependency property Property51 Property
        /// </summary>
        public static DependencyProperty Property51Property = DependencyProperty.RegisterAttached("Property51", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property51 value
        /// </summary>
        public static void SetProperty51(DependencyObject element, object value)
        {
            element.SetValue(Property51Property, value);
        }

        /// <summary>
        /// get Property51 value
        /// </summary>
        public static object GetProperty51(DependencyObject element)
        {
            return element.GetValue(Property51Property);
        }

        /// <summary>
        /// dependency property Property52 Property
        /// </summary>
        public static DependencyProperty Property52Property = DependencyProperty.RegisterAttached("Property52", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property52 value
        /// </summary>
        public static void SetProperty52(DependencyObject element, object value)
        {
            element.SetValue(Property52Property, value);
        }

        /// <summary>
        /// get Property52 value
        /// </summary>
        public static object GetProperty52(DependencyObject element)
        {
            return element.GetValue(Property52Property);
        }

        /// <summary>
        /// dependency property Property53 Property
        /// </summary>
        public static DependencyProperty Property53Property = DependencyProperty.RegisterAttached("Property53", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property53 value
        /// </summary>
        public static void SetProperty53(DependencyObject element, object value)
        {
            element.SetValue(Property53Property, value);
        }

        /// <summary>
        /// get Property53 value
        /// </summary>
        public static object GetProperty53(DependencyObject element)
        {
            return element.GetValue(Property53Property);
        }

        /// <summary>
        /// dependency property Property54 Property
        /// </summary>
        public static DependencyProperty Property54Property = DependencyProperty.RegisterAttached("Property54", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property54 value
        /// </summary>
        public static void SetProperty54(DependencyObject element, object value)
        {
            element.SetValue(Property54Property, value);
        }

        /// <summary>
        /// get Property54 value
        /// </summary>
        public static object GetProperty54(DependencyObject element)
        {
            return element.GetValue(Property54Property);
        }

        /// <summary>
        /// dependency property Property55 Property
        /// </summary>
        public static DependencyProperty Property55Property = DependencyProperty.RegisterAttached("Property55", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property55 value
        /// </summary>
        public static void SetProperty55(DependencyObject element, object value)
        {
            element.SetValue(Property55Property, value);
        }

        /// <summary>
        /// get Property55 value
        /// </summary>
        public static object GetProperty55(DependencyObject element)
        {
            return element.GetValue(Property55Property);
        }

        /// <summary>
        /// dependency property Property56 Property
        /// </summary>
        public static DependencyProperty Property56Property = DependencyProperty.RegisterAttached("Property56", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property56 value
        /// </summary>
        public static void SetProperty56(DependencyObject element, object value)
        {
            element.SetValue(Property56Property, value);
        }

        /// <summary>
        /// get Property56 value
        /// </summary>
        public static object GetProperty56(DependencyObject element)
        {
            return element.GetValue(Property56Property);
        }

        /// <summary>
        /// dependency property Property57 Property
        /// </summary>
        public static DependencyProperty Property57Property = DependencyProperty.RegisterAttached("Property57", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property57 value
        /// </summary>
        public static void SetProperty57(DependencyObject element, object value)
        {
            element.SetValue(Property57Property, value);
        }

        /// <summary>
        /// get Property57 value
        /// </summary>
        public static object GetProperty57(DependencyObject element)
        {
            return element.GetValue(Property57Property);
        }

        /// <summary>
        /// dependency property Property58 Property
        /// </summary>
        public static DependencyProperty Property58Property = DependencyProperty.RegisterAttached("Property58", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property58 value
        /// </summary>
        public static void SetProperty58(DependencyObject element, object value)
        {
            element.SetValue(Property58Property, value);
        }

        /// <summary>
        /// get Property58 value
        /// </summary>
        public static object GetProperty58(DependencyObject element)
        {
            return element.GetValue(Property58Property);
        }

        /// <summary>
        /// dependency property Property59 Property
        /// </summary>
        public static DependencyProperty Property59Property = DependencyProperty.RegisterAttached("Property59", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property59 value
        /// </summary>
        public static void SetProperty59(DependencyObject element, object value)
        {
            element.SetValue(Property59Property, value);
        }

        /// <summary>
        /// get Property59 value
        /// </summary>
        public static object GetProperty59(DependencyObject element)
        {
            return element.GetValue(Property59Property);
        }

        /// <summary>
        /// dependency property Property60 Property
        /// </summary>
        public static DependencyProperty Property60Property = DependencyProperty.RegisterAttached("Property60", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property60 value
        /// </summary>
        public static void SetProperty60(DependencyObject element, object value)
        {
            element.SetValue(Property60Property, value);
        }

        /// <summary>
        /// get Property60 value
        /// </summary>
        public static object GetProperty60(DependencyObject element)
        {
            return element.GetValue(Property60Property);
        }

        /// <summary>
        /// dependency property Property61 Property
        /// </summary>
        public static DependencyProperty Property61Property = DependencyProperty.RegisterAttached("Property61", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property61 value
        /// </summary>
        public static void SetProperty61(DependencyObject element, object value)
        {
            element.SetValue(Property61Property, value);
        }

        /// <summary>
        /// get Property61 value
        /// </summary>
        public static object GetProperty61(DependencyObject element)
        {
            return element.GetValue(Property61Property);
        }

        /// <summary>
        /// dependency property Property62 Property
        /// </summary>
        public static DependencyProperty Property62Property = DependencyProperty.RegisterAttached("Property62", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property62 value
        /// </summary>
        public static void SetProperty62(DependencyObject element, object value)
        {
            element.SetValue(Property62Property, value);
        }

        /// <summary>
        /// get Property62 value
        /// </summary>
        public static object GetProperty62(DependencyObject element)
        {
            return element.GetValue(Property62Property);
        }

        /// <summary>
        /// dependency property Property63 Property
        /// </summary>
        public static DependencyProperty Property63Property = DependencyProperty.RegisterAttached("Property63", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property63 value
        /// </summary>
        public static void SetProperty63(DependencyObject element, object value)
        {
            element.SetValue(Property63Property, value);
        }

        /// <summary>
        /// get Property63 value
        /// </summary>
        public static object GetProperty63(DependencyObject element)
        {
            return element.GetValue(Property63Property);
        }

        /// <summary>
        /// dependency property Property64 Property
        /// </summary>
        public static DependencyProperty Property64Property = DependencyProperty.RegisterAttached("Property64", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property64 value
        /// </summary>
        public static void SetProperty64(DependencyObject element, object value)
        {
            element.SetValue(Property64Property, value);
        }

        /// <summary>
        /// get Property64 value
        /// </summary>
        public static object GetProperty64(DependencyObject element)
        {
            return element.GetValue(Property64Property);
        }

        /// <summary>
        /// dependency property Property65 Property
        /// </summary>
        public static DependencyProperty Property65Property = DependencyProperty.RegisterAttached("Property65", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property65 value
        /// </summary>
        public static void SetProperty65(DependencyObject element, object value)
        {
            element.SetValue(Property65Property, value);
        }

        /// <summary>
        /// get Property65 value
        /// </summary>
        public static object GetProperty65(DependencyObject element)
        {
            return element.GetValue(Property65Property);
        }

        /// <summary>
        /// dependency property Property66 Property
        /// </summary>
        public static DependencyProperty Property66Property = DependencyProperty.RegisterAttached("Property66", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property66 value
        /// </summary>
        public static void SetProperty66(DependencyObject element, object value)
        {
            element.SetValue(Property66Property, value);
        }

        /// <summary>
        /// get Property66 value
        /// </summary>
        public static object GetProperty66(DependencyObject element)
        {
            return element.GetValue(Property66Property);
        }

        /// <summary>
        /// dependency property Property67 Property
        /// </summary>
        public static DependencyProperty Property67Property = DependencyProperty.RegisterAttached("Property67", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property67 value
        /// </summary>
        public static void SetProperty67(DependencyObject element, object value)
        {
            element.SetValue(Property67Property, value);
        }

        /// <summary>
        /// get Property67 value
        /// </summary>
        public static object GetProperty67(DependencyObject element)
        {
            return element.GetValue(Property67Property);
        }

        /// <summary>
        /// dependency property Property68 Property
        /// </summary>
        public static DependencyProperty Property68Property = DependencyProperty.RegisterAttached("Property68", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property68 value
        /// </summary>
        public static void SetProperty68(DependencyObject element, object value)
        {
            element.SetValue(Property68Property, value);
        }

        /// <summary>
        /// get Property68 value
        /// </summary>
        public static object GetProperty68(DependencyObject element)
        {
            return element.GetValue(Property68Property);
        }

        /// <summary>
        /// dependency property Property69 Property
        /// </summary>
        public static DependencyProperty Property69Property = DependencyProperty.RegisterAttached("Property69", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property69 value
        /// </summary>
        public static void SetProperty69(DependencyObject element, object value)
        {
            element.SetValue(Property69Property, value);
        }

        /// <summary>
        /// get Property69 value
        /// </summary>
        public static object GetProperty69(DependencyObject element)
        {
            return element.GetValue(Property69Property);
        }

        /// <summary>
        /// dependency property Property70 Property
        /// </summary>
        public static DependencyProperty Property70Property = DependencyProperty.RegisterAttached("Property70", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property70 value
        /// </summary>
        public static void SetProperty70(DependencyObject element, object value)
        {
            element.SetValue(Property70Property, value);
        }

        /// <summary>
        /// get Property70 value
        /// </summary>
        public static object GetProperty70(DependencyObject element)
        {
            return element.GetValue(Property70Property);
        }

        /// <summary>
        /// dependency property Property71 Property
        /// </summary>
        public static DependencyProperty Property71Property = DependencyProperty.RegisterAttached("Property71", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property71 value
        /// </summary>
        public static void SetProperty71(DependencyObject element, object value)
        {
            element.SetValue(Property71Property, value);
        }

        /// <summary>
        /// get Property71 value
        /// </summary>
        public static object GetProperty71(DependencyObject element)
        {
            return element.GetValue(Property71Property);
        }

        /// <summary>
        /// dependency property Property72 Property
        /// </summary>
        public static DependencyProperty Property72Property = DependencyProperty.RegisterAttached("Property72", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property72 value
        /// </summary>
        public static void SetProperty72(DependencyObject element, object value)
        {
            element.SetValue(Property72Property, value);
        }

        /// <summary>
        /// get Property72 value
        /// </summary>
        public static object GetProperty72(DependencyObject element)
        {
            return element.GetValue(Property72Property);
        }

        /// <summary>
        /// dependency property Property73 Property
        /// </summary>
        public static DependencyProperty Property73Property = DependencyProperty.RegisterAttached("Property73", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property73 value
        /// </summary>
        public static void SetProperty73(DependencyObject element, object value)
        {
            element.SetValue(Property73Property, value);
        }

        /// <summary>
        /// get Property73 value
        /// </summary>
        public static object GetProperty73(DependencyObject element)
        {
            return element.GetValue(Property73Property);
        }

        /// <summary>
        /// dependency property Property74 Property
        /// </summary>
        public static DependencyProperty Property74Property = DependencyProperty.RegisterAttached("Property74", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property74 value
        /// </summary>
        public static void SetProperty74(DependencyObject element, object value)
        {
            element.SetValue(Property74Property, value);
        }

        /// <summary>
        /// get Property74 value
        /// </summary>
        public static object GetProperty74(DependencyObject element)
        {
            return element.GetValue(Property74Property);
        }

        /// <summary>
        /// dependency property Property75 Property
        /// </summary>
        public static DependencyProperty Property75Property = DependencyProperty.RegisterAttached("Property75", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property75 value
        /// </summary>
        public static void SetProperty75(DependencyObject element, object value)
        {
            element.SetValue(Property75Property, value);
        }

        /// <summary>
        /// get Property75 value
        /// </summary>
        public static object GetProperty75(DependencyObject element)
        {
            return element.GetValue(Property75Property);
        }

        /// <summary>
        /// dependency property Property76 Property
        /// </summary>
        public static DependencyProperty Property76Property = DependencyProperty.RegisterAttached("Property76", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property76 value
        /// </summary>
        public static void SetProperty76(DependencyObject element, object value)
        {
            element.SetValue(Property76Property, value);
        }

        /// <summary>
        /// get Property76 value
        /// </summary>
        public static object GetProperty76(DependencyObject element)
        {
            return element.GetValue(Property76Property);
        }

        /// <summary>
        /// dependency property Property77 Property
        /// </summary>
        public static DependencyProperty Property77Property = DependencyProperty.RegisterAttached("Property77", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property77 value
        /// </summary>
        public static void SetProperty77(DependencyObject element, object value)
        {
            element.SetValue(Property77Property, value);
        }

        /// <summary>
        /// get Property77 value
        /// </summary>
        public static object GetProperty77(DependencyObject element)
        {
            return element.GetValue(Property77Property);
        }

        /// <summary>
        /// dependency property Property78 Property
        /// </summary>
        public static DependencyProperty Property78Property = DependencyProperty.RegisterAttached("Property78", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property78 value
        /// </summary>
        public static void SetProperty78(DependencyObject element, object value)
        {
            element.SetValue(Property78Property, value);
        }

        /// <summary>
        /// get Property78 value
        /// </summary>
        public static object GetProperty78(DependencyObject element)
        {
            return element.GetValue(Property78Property);
        }

        /// <summary>
        /// dependency property Property79 Property
        /// </summary>
        public static DependencyProperty Property79Property = DependencyProperty.RegisterAttached("Property79", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property79 value
        /// </summary>
        public static void SetProperty79(DependencyObject element, object value)
        {
            element.SetValue(Property79Property, value);
        }

        /// <summary>
        /// get Property79 value
        /// </summary>
        public static object GetProperty79(DependencyObject element)
        {
            return element.GetValue(Property79Property);
        }

        /// <summary>
        /// dependency property Property80 Property
        /// </summary>
        public static DependencyProperty Property80Property = DependencyProperty.RegisterAttached("Property80", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property80 value
        /// </summary>
        public static void SetProperty80(DependencyObject element, object value)
        {
            element.SetValue(Property80Property, value);
        }

        /// <summary>
        /// get Property80 value
        /// </summary>
        public static object GetProperty80(DependencyObject element)
        {
            return element.GetValue(Property80Property);
        }

        /// <summary>
        /// dependency property Property81 Property
        /// </summary>
        public static DependencyProperty Property81Property = DependencyProperty.RegisterAttached("Property81", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property81 value
        /// </summary>
        public static void SetProperty81(DependencyObject element, object value)
        {
            element.SetValue(Property81Property, value);
        }

        /// <summary>
        /// get Property81 value
        /// </summary>
        public static object GetProperty81(DependencyObject element)
        {
            return element.GetValue(Property81Property);
        }

        /// <summary>
        /// dependency property Property82 Property
        /// </summary>
        public static DependencyProperty Property82Property = DependencyProperty.RegisterAttached("Property82", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property82 value
        /// </summary>
        public static void SetProperty82(DependencyObject element, object value)
        {
            element.SetValue(Property82Property, value);
        }

        /// <summary>
        /// get Property82 value
        /// </summary>
        public static object GetProperty82(DependencyObject element)
        {
            return element.GetValue(Property82Property);
        }

        /// <summary>
        /// dependency property Property83 Property
        /// </summary>
        public static DependencyProperty Property83Property = DependencyProperty.RegisterAttached("Property83", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property83 value
        /// </summary>
        public static void SetProperty83(DependencyObject element, object value)
        {
            element.SetValue(Property83Property, value);
        }

        /// <summary>
        /// get Property83 value
        /// </summary>
        public static object GetProperty83(DependencyObject element)
        {
            return element.GetValue(Property83Property);
        }

        /// <summary>
        /// dependency property Property84 Property
        /// </summary>
        public static DependencyProperty Property84Property = DependencyProperty.RegisterAttached("Property84", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property84 value
        /// </summary>
        public static void SetProperty84(DependencyObject element, object value)
        {
            element.SetValue(Property84Property, value);
        }

        /// <summary>
        /// get Property84 value
        /// </summary>
        public static object GetProperty84(DependencyObject element)
        {
            return element.GetValue(Property84Property);
        }

        /// <summary>
        /// dependency property Property85 Property
        /// </summary>
        public static DependencyProperty Property85Property = DependencyProperty.RegisterAttached("Property85", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property85 value
        /// </summary>
        public static void SetProperty85(DependencyObject element, object value)
        {
            element.SetValue(Property85Property, value);
        }

        /// <summary>
        /// get Property85 value
        /// </summary>
        public static object GetProperty85(DependencyObject element)
        {
            return element.GetValue(Property85Property);
        }

        /// <summary>
        /// dependency property Property86 Property
        /// </summary>
        public static DependencyProperty Property86Property = DependencyProperty.RegisterAttached("Property86", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property86 value
        /// </summary>
        public static void SetProperty86(DependencyObject element, object value)
        {
            element.SetValue(Property86Property, value);
        }

        /// <summary>
        /// get Property86 value
        /// </summary>
        public static object GetProperty86(DependencyObject element)
        {
            return element.GetValue(Property86Property);
        }

        /// <summary>
        /// dependency property Property87 Property
        /// </summary>
        public static DependencyProperty Property87Property = DependencyProperty.RegisterAttached("Property87", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property87 value
        /// </summary>
        public static void SetProperty87(DependencyObject element, object value)
        {
            element.SetValue(Property87Property, value);
        }

        /// <summary>
        /// get Property87 value
        /// </summary>
        public static object GetProperty87(DependencyObject element)
        {
            return element.GetValue(Property87Property);
        }

        /// <summary>
        /// dependency property Property88 Property
        /// </summary>
        public static DependencyProperty Property88Property = DependencyProperty.RegisterAttached("Property88", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property88 value
        /// </summary>
        public static void SetProperty88(DependencyObject element, object value)
        {
            element.SetValue(Property88Property, value);
        }

        /// <summary>
        /// get Property88 value
        /// </summary>
        public static object GetProperty88(DependencyObject element)
        {
            return element.GetValue(Property88Property);
        }

        /// <summary>
        /// dependency property Property89 Property
        /// </summary>
        public static DependencyProperty Property89Property = DependencyProperty.RegisterAttached("Property89", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property89 value
        /// </summary>
        public static void SetProperty89(DependencyObject element, object value)
        {
            element.SetValue(Property89Property, value);
        }

        /// <summary>
        /// get Property89 value
        /// </summary>
        public static object GetProperty89(DependencyObject element)
        {
            return element.GetValue(Property89Property);
        }

        /// <summary>
        /// dependency property Property90 Property
        /// </summary>
        public static DependencyProperty Property90Property = DependencyProperty.RegisterAttached("Property90", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property90 value
        /// </summary>
        public static void SetProperty90(DependencyObject element, object value)
        {
            element.SetValue(Property90Property, value);
        }

        /// <summary>
        /// get Property90 value
        /// </summary>
        public static object GetProperty90(DependencyObject element)
        {
            return element.GetValue(Property90Property);
        }

        /// <summary>
        /// dependency property Property91 Property
        /// </summary>
        public static DependencyProperty Property91Property = DependencyProperty.RegisterAttached("Property91", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property91 value
        /// </summary>
        public static void SetProperty91(DependencyObject element, object value)
        {
            element.SetValue(Property91Property, value);
        }

        /// <summary>
        /// get Property91 value
        /// </summary>
        public static object GetProperty91(DependencyObject element)
        {
            return element.GetValue(Property91Property);
        }

        /// <summary>
        /// dependency property Property92 Property
        /// </summary>
        public static DependencyProperty Property92Property = DependencyProperty.RegisterAttached("Property92", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property92 value
        /// </summary>
        public static void SetProperty92(DependencyObject element, object value)
        {
            element.SetValue(Property92Property, value);
        }

        /// <summary>
        /// get Property92 value
        /// </summary>
        public static object GetProperty92(DependencyObject element)
        {
            return element.GetValue(Property92Property);
        }

        /// <summary>
        /// dependency property Property93 Property
        /// </summary>
        public static DependencyProperty Property93Property = DependencyProperty.RegisterAttached("Property93", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property93 value
        /// </summary>
        public static void SetProperty93(DependencyObject element, object value)
        {
            element.SetValue(Property93Property, value);
        }

        /// <summary>
        /// get Property93 value
        /// </summary>
        public static object GetProperty93(DependencyObject element)
        {
            return element.GetValue(Property93Property);
        }

        /// <summary>
        /// dependency property Property94 Property
        /// </summary>
        public static DependencyProperty Property94Property = DependencyProperty.RegisterAttached("Property94", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property94 value
        /// </summary>
        public static void SetProperty94(DependencyObject element, object value)
        {
            element.SetValue(Property94Property, value);
        }

        /// <summary>
        /// get Property94 value
        /// </summary>
        public static object GetProperty94(DependencyObject element)
        {
            return element.GetValue(Property94Property);
        }

        /// <summary>
        /// dependency property Property95 Property
        /// </summary>
        public static DependencyProperty Property95Property = DependencyProperty.RegisterAttached("Property95", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property95 value
        /// </summary>
        public static void SetProperty95(DependencyObject element, object value)
        {
            element.SetValue(Property95Property, value);
        }

        /// <summary>
        /// get Property95 value
        /// </summary>
        public static object GetProperty95(DependencyObject element)
        {
            return element.GetValue(Property95Property);
        }

        /// <summary>
        /// dependency property Property96 Property
        /// </summary>
        public static DependencyProperty Property96Property = DependencyProperty.RegisterAttached("Property96", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property96 value
        /// </summary>
        public static void SetProperty96(DependencyObject element, object value)
        {
            element.SetValue(Property96Property, value);
        }

        /// <summary>
        /// get Property96 value
        /// </summary>
        public static object GetProperty96(DependencyObject element)
        {
            return element.GetValue(Property96Property);
        }

        /// <summary>
        /// dependency property Property97 Property
        /// </summary>
        public static DependencyProperty Property97Property = DependencyProperty.RegisterAttached("Property97", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property97 value
        /// </summary>
        public static void SetProperty97(DependencyObject element, object value)
        {
            element.SetValue(Property97Property, value);
        }

        /// <summary>
        /// get Property97 value
        /// </summary>
        public static object GetProperty97(DependencyObject element)
        {
            return element.GetValue(Property97Property);
        }

        /// <summary>
        /// dependency property Property98 Property
        /// </summary>
        public static DependencyProperty Property98Property = DependencyProperty.RegisterAttached("Property98", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property98 value
        /// </summary>
        public static void SetProperty98(DependencyObject element, object value)
        {
            element.SetValue(Property98Property, value);
        }

        /// <summary>
        /// get Property98 value
        /// </summary>
        public static object GetProperty98(DependencyObject element)
        {
            return element.GetValue(Property98Property);
        }

        /// <summary>
        /// dependency property Property99 Property
        /// </summary>
        public static DependencyProperty Property99Property = DependencyProperty.RegisterAttached("Property99", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property99 value
        /// </summary>
        public static void SetProperty99(DependencyObject element, object value)
        {
            element.SetValue(Property99Property, value);
        }

        /// <summary>
        /// get Property99 value
        /// </summary>
        public static object GetProperty99(DependencyObject element)
        {
            return element.GetValue(Property99Property);
        }

        /// <summary>
        /// dependency property Property100 Property
        /// </summary>
        public static DependencyProperty Property100Property = DependencyProperty.RegisterAttached("Property100", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property100 value
        /// </summary>
        public static void SetProperty100(DependencyObject element, object value)
        {
            element.SetValue(Property100Property, value);
        }

        /// <summary>
        /// get Property100 value
        /// </summary>
        public static object GetProperty100(DependencyObject element)
        {
            return element.GetValue(Property100Property);
        }

        /// <summary>
        /// dependency property Property101 Property
        /// </summary>
        public static DependencyProperty Property101Property = DependencyProperty.RegisterAttached("Property101", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property101 value
        /// </summary>
        public static void SetProperty101(DependencyObject element, object value)
        {
            element.SetValue(Property101Property, value);
        }

        /// <summary>
        /// get Property101 value
        /// </summary>
        public static object GetProperty101(DependencyObject element)
        {
            return element.GetValue(Property101Property);
        }

        /// <summary>
        /// dependency property Property102 Property
        /// </summary>
        public static DependencyProperty Property102Property = DependencyProperty.RegisterAttached("Property102", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property102 value
        /// </summary>
        public static void SetProperty102(DependencyObject element, object value)
        {
            element.SetValue(Property102Property, value);
        }

        /// <summary>
        /// get Property102 value
        /// </summary>
        public static object GetProperty102(DependencyObject element)
        {
            return element.GetValue(Property102Property);
        }

        /// <summary>
        /// dependency property Property103 Property
        /// </summary>
        public static DependencyProperty Property103Property = DependencyProperty.RegisterAttached("Property103", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property103 value
        /// </summary>
        public static void SetProperty103(DependencyObject element, object value)
        {
            element.SetValue(Property103Property, value);
        }

        /// <summary>
        /// get Property103 value
        /// </summary>
        public static object GetProperty103(DependencyObject element)
        {
            return element.GetValue(Property103Property);
        }

        /// <summary>
        /// dependency property Property104 Property
        /// </summary>
        public static DependencyProperty Property104Property = DependencyProperty.RegisterAttached("Property104", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property104 value
        /// </summary>
        public static void SetProperty104(DependencyObject element, object value)
        {
            element.SetValue(Property104Property, value);
        }

        /// <summary>
        /// get Property104 value
        /// </summary>
        public static object GetProperty104(DependencyObject element)
        {
            return element.GetValue(Property104Property);
        }

        /// <summary>
        /// dependency property Property105 Property
        /// </summary>
        public static DependencyProperty Property105Property = DependencyProperty.RegisterAttached("Property105", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property105 value
        /// </summary>
        public static void SetProperty105(DependencyObject element, object value)
        {
            element.SetValue(Property105Property, value);
        }

        /// <summary>
        /// get Property105 value
        /// </summary>
        public static object GetProperty105(DependencyObject element)
        {
            return element.GetValue(Property105Property);
        }

        /// <summary>
        /// dependency property Property106 Property
        /// </summary>
        public static DependencyProperty Property106Property = DependencyProperty.RegisterAttached("Property106", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property106 value
        /// </summary>
        public static void SetProperty106(DependencyObject element, object value)
        {
            element.SetValue(Property106Property, value);
        }

        /// <summary>
        /// get Property106 value
        /// </summary>
        public static object GetProperty106(DependencyObject element)
        {
            return element.GetValue(Property106Property);
        }

        /// <summary>
        /// dependency property Property107 Property
        /// </summary>
        public static DependencyProperty Property107Property = DependencyProperty.RegisterAttached("Property107", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property107 value
        /// </summary>
        public static void SetProperty107(DependencyObject element, object value)
        {
            element.SetValue(Property107Property, value);
        }

        /// <summary>
        /// get Property107 value
        /// </summary>
        public static object GetProperty107(DependencyObject element)
        {
            return element.GetValue(Property107Property);
        }

        /// <summary>
        /// dependency property Property108 Property
        /// </summary>
        public static DependencyProperty Property108Property = DependencyProperty.RegisterAttached("Property108", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property108 value
        /// </summary>
        public static void SetProperty108(DependencyObject element, object value)
        {
            element.SetValue(Property108Property, value);
        }

        /// <summary>
        /// get Property108 value
        /// </summary>
        public static object GetProperty108(DependencyObject element)
        {
            return element.GetValue(Property108Property);
        }

        /// <summary>
        /// dependency property Property109 Property
        /// </summary>
        public static DependencyProperty Property109Property = DependencyProperty.RegisterAttached("Property109", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property109 value
        /// </summary>
        public static void SetProperty109(DependencyObject element, object value)
        {
            element.SetValue(Property109Property, value);
        }

        /// <summary>
        /// get Property109 value
        /// </summary>
        public static object GetProperty109(DependencyObject element)
        {
            return element.GetValue(Property109Property);
        }

        /// <summary>
        /// dependency property Property110 Property
        /// </summary>
        public static DependencyProperty Property110Property = DependencyProperty.RegisterAttached("Property110", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property110 value
        /// </summary>
        public static void SetProperty110(DependencyObject element, object value)
        {
            element.SetValue(Property110Property, value);
        }

        /// <summary>
        /// get Property110 value
        /// </summary>
        public static object GetProperty110(DependencyObject element)
        {
            return element.GetValue(Property110Property);
        }

        /// <summary>
        /// dependency property Property111 Property
        /// </summary>
        public static DependencyProperty Property111Property = DependencyProperty.RegisterAttached("Property111", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property111 value
        /// </summary>
        public static void SetProperty111(DependencyObject element, object value)
        {
            element.SetValue(Property111Property, value);
        }

        /// <summary>
        /// get Property111 value
        /// </summary>
        public static object GetProperty111(DependencyObject element)
        {
            return element.GetValue(Property111Property);
        }

        /// <summary>
        /// dependency property Property112 Property
        /// </summary>
        public static DependencyProperty Property112Property = DependencyProperty.RegisterAttached("Property112", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property112 value
        /// </summary>
        public static void SetProperty112(DependencyObject element, object value)
        {
            element.SetValue(Property112Property, value);
        }

        /// <summary>
        /// get Property112 value
        /// </summary>
        public static object GetProperty112(DependencyObject element)
        {
            return element.GetValue(Property112Property);
        }

        /// <summary>
        /// dependency property Property113 Property
        /// </summary>
        public static DependencyProperty Property113Property = DependencyProperty.RegisterAttached("Property113", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property113 value
        /// </summary>
        public static void SetProperty113(DependencyObject element, object value)
        {
            element.SetValue(Property113Property, value);
        }

        /// <summary>
        /// get Property113 value
        /// </summary>
        public static object GetProperty113(DependencyObject element)
        {
            return element.GetValue(Property113Property);
        }

        /// <summary>
        /// dependency property Property114 Property
        /// </summary>
        public static DependencyProperty Property114Property = DependencyProperty.RegisterAttached("Property114", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property114 value
        /// </summary>
        public static void SetProperty114(DependencyObject element, object value)
        {
            element.SetValue(Property114Property, value);
        }

        /// <summary>
        /// get Property114 value
        /// </summary>
        public static object GetProperty114(DependencyObject element)
        {
            return element.GetValue(Property114Property);
        }

        /// <summary>
        /// dependency property Property115 Property
        /// </summary>
        public static DependencyProperty Property115Property = DependencyProperty.RegisterAttached("Property115", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property115 value
        /// </summary>
        public static void SetProperty115(DependencyObject element, object value)
        {
            element.SetValue(Property115Property, value);
        }

        /// <summary>
        /// get Property115 value
        /// </summary>
        public static object GetProperty115(DependencyObject element)
        {
            return element.GetValue(Property115Property);
        }

        /// <summary>
        /// dependency property Property116 Property
        /// </summary>
        public static DependencyProperty Property116Property = DependencyProperty.RegisterAttached("Property116", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property116 value
        /// </summary>
        public static void SetProperty116(DependencyObject element, object value)
        {
            element.SetValue(Property116Property, value);
        }

        /// <summary>
        /// get Property116 value
        /// </summary>
        public static object GetProperty116(DependencyObject element)
        {
            return element.GetValue(Property116Property);
        }

        /// <summary>
        /// dependency property Property117 Property
        /// </summary>
        public static DependencyProperty Property117Property = DependencyProperty.RegisterAttached("Property117", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property117 value
        /// </summary>
        public static void SetProperty117(DependencyObject element, object value)
        {
            element.SetValue(Property117Property, value);
        }

        /// <summary>
        /// get Property117 value
        /// </summary>
        public static object GetProperty117(DependencyObject element)
        {
            return element.GetValue(Property117Property);
        }

        /// <summary>
        /// dependency property Property118 Property
        /// </summary>
        public static DependencyProperty Property118Property = DependencyProperty.RegisterAttached("Property118", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property118 value
        /// </summary>
        public static void SetProperty118(DependencyObject element, object value)
        {
            element.SetValue(Property118Property, value);
        }

        /// <summary>
        /// get Property118 value
        /// </summary>
        public static object GetProperty118(DependencyObject element)
        {
            return element.GetValue(Property118Property);
        }

        /// <summary>
        /// dependency property Property119 Property
        /// </summary>
        public static DependencyProperty Property119Property = DependencyProperty.RegisterAttached("Property119", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property119 value
        /// </summary>
        public static void SetProperty119(DependencyObject element, object value)
        {
            element.SetValue(Property119Property, value);
        }

        /// <summary>
        /// get Property119 value
        /// </summary>
        public static object GetProperty119(DependencyObject element)
        {
            return element.GetValue(Property119Property);
        }

        /// <summary>
        /// dependency property Property120 Property
        /// </summary>
        public static DependencyProperty Property120Property = DependencyProperty.RegisterAttached("Property120", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property120 value
        /// </summary>
        public static void SetProperty120(DependencyObject element, object value)
        {
            element.SetValue(Property120Property, value);
        }

        /// <summary>
        /// get Property120 value
        /// </summary>
        public static object GetProperty120(DependencyObject element)
        {
            return element.GetValue(Property120Property);
        }

        /// <summary>
        /// dependency property Property121 Property
        /// </summary>
        public static DependencyProperty Property121Property = DependencyProperty.RegisterAttached("Property121", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property121 value
        /// </summary>
        public static void SetProperty121(DependencyObject element, object value)
        {
            element.SetValue(Property121Property, value);
        }

        /// <summary>
        /// get Property121 value
        /// </summary>
        public static object GetProperty121(DependencyObject element)
        {
            return element.GetValue(Property121Property);
        }

        /// <summary>
        /// dependency property Property122 Property
        /// </summary>
        public static DependencyProperty Property122Property = DependencyProperty.RegisterAttached("Property122", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property122 value
        /// </summary>
        public static void SetProperty122(DependencyObject element, object value)
        {
            element.SetValue(Property122Property, value);
        }

        /// <summary>
        /// get Property122 value
        /// </summary>
        public static object GetProperty122(DependencyObject element)
        {
            return element.GetValue(Property122Property);
        }

        /// <summary>
        /// dependency property Property123 Property
        /// </summary>
        public static DependencyProperty Property123Property = DependencyProperty.RegisterAttached("Property123", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property123 value
        /// </summary>
        public static void SetProperty123(DependencyObject element, object value)
        {
            element.SetValue(Property123Property, value);
        }

        /// <summary>
        /// get Property123 value
        /// </summary>
        public static object GetProperty123(DependencyObject element)
        {
            return element.GetValue(Property123Property);
        }

        /// <summary>
        /// dependency property Property124 Property
        /// </summary>
        public static DependencyProperty Property124Property = DependencyProperty.RegisterAttached("Property124", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property124 value
        /// </summary>
        public static void SetProperty124(DependencyObject element, object value)
        {
            element.SetValue(Property124Property, value);
        }

        /// <summary>
        /// get Property124 value
        /// </summary>
        public static object GetProperty124(DependencyObject element)
        {
            return element.GetValue(Property124Property);
        }

        /// <summary>
        /// dependency property Property125 Property
        /// </summary>
        public static DependencyProperty Property125Property = DependencyProperty.RegisterAttached("Property125", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property125 value
        /// </summary>
        public static void SetProperty125(DependencyObject element, object value)
        {
            element.SetValue(Property125Property, value);
        }

        /// <summary>
        /// get Property125 value
        /// </summary>
        public static object GetProperty125(DependencyObject element)
        {
            return element.GetValue(Property125Property);
        }

        /// <summary>
        /// dependency property Property126 Property
        /// </summary>
        public static DependencyProperty Property126Property = DependencyProperty.RegisterAttached("Property126", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property126 value
        /// </summary>
        public static void SetProperty126(DependencyObject element, object value)
        {
            element.SetValue(Property126Property, value);
        }

        /// <summary>
        /// get Property126 value
        /// </summary>
        public static object GetProperty126(DependencyObject element)
        {
            return element.GetValue(Property126Property);
        }

        /// <summary>
        /// dependency property Property127 Property
        /// </summary>
        public static DependencyProperty Property127Property = DependencyProperty.RegisterAttached("Property127", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property127 value
        /// </summary>
        public static void SetProperty127(DependencyObject element, object value)
        {
            element.SetValue(Property127Property, value);
        }

        /// <summary>
        /// get Property127 value
        /// </summary>
        public static object GetProperty127(DependencyObject element)
        {
            return element.GetValue(Property127Property);
        }

        /// <summary>
        /// dependency property Property128 Property
        /// </summary>
        public static DependencyProperty Property128Property = DependencyProperty.RegisterAttached("Property128", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property128 value
        /// </summary>
        public static void SetProperty128(DependencyObject element, object value)
        {
            element.SetValue(Property128Property, value);
        }

        /// <summary>
        /// get Property128 value
        /// </summary>
        public static object GetProperty128(DependencyObject element)
        {
            return element.GetValue(Property128Property);
        }

        /// <summary>
        /// dependency property Property129 Property
        /// </summary>
        public static DependencyProperty Property129Property = DependencyProperty.RegisterAttached("Property129", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property129 value
        /// </summary>
        public static void SetProperty129(DependencyObject element, object value)
        {
            element.SetValue(Property129Property, value);
        }

        /// <summary>
        /// get Property129 value
        /// </summary>
        public static object GetProperty129(DependencyObject element)
        {
            return element.GetValue(Property129Property);
        }

        /// <summary>
        /// dependency property Property130 Property
        /// </summary>
        public static DependencyProperty Property130Property = DependencyProperty.RegisterAttached("Property130", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property130 value
        /// </summary>
        public static void SetProperty130(DependencyObject element, object value)
        {
            element.SetValue(Property130Property, value);
        }

        /// <summary>
        /// get Property130 value
        /// </summary>
        public static object GetProperty130(DependencyObject element)
        {
            return element.GetValue(Property130Property);
        }

        /// <summary>
        /// dependency property Property131 Property
        /// </summary>
        public static DependencyProperty Property131Property = DependencyProperty.RegisterAttached("Property131", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property131 value
        /// </summary>
        public static void SetProperty131(DependencyObject element, object value)
        {
            element.SetValue(Property131Property, value);
        }

        /// <summary>
        /// get Property131 value
        /// </summary>
        public static object GetProperty131(DependencyObject element)
        {
            return element.GetValue(Property131Property);
        }

        /// <summary>
        /// dependency property Property132 Property
        /// </summary>
        public static DependencyProperty Property132Property = DependencyProperty.RegisterAttached("Property132", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property132 value
        /// </summary>
        public static void SetProperty132(DependencyObject element, object value)
        {
            element.SetValue(Property132Property, value);
        }

        /// <summary>
        /// get Property132 value
        /// </summary>
        public static object GetProperty132(DependencyObject element)
        {
            return element.GetValue(Property132Property);
        }

        /// <summary>
        /// dependency property Property133 Property
        /// </summary>
        public static DependencyProperty Property133Property = DependencyProperty.RegisterAttached("Property133", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property133 value
        /// </summary>
        public static void SetProperty133(DependencyObject element, object value)
        {
            element.SetValue(Property133Property, value);
        }

        /// <summary>
        /// get Property133 value
        /// </summary>
        public static object GetProperty133(DependencyObject element)
        {
            return element.GetValue(Property133Property);
        }

        /// <summary>
        /// dependency property Property134 Property
        /// </summary>
        public static DependencyProperty Property134Property = DependencyProperty.RegisterAttached("Property134", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property134 value
        /// </summary>
        public static void SetProperty134(DependencyObject element, object value)
        {
            element.SetValue(Property134Property, value);
        }

        /// <summary>
        /// get Property134 value
        /// </summary>
        public static object GetProperty134(DependencyObject element)
        {
            return element.GetValue(Property134Property);
        }

        /// <summary>
        /// dependency property Property135 Property
        /// </summary>
        public static DependencyProperty Property135Property = DependencyProperty.RegisterAttached("Property135", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property135 value
        /// </summary>
        public static void SetProperty135(DependencyObject element, object value)
        {
            element.SetValue(Property135Property, value);
        }

        /// <summary>
        /// get Property135 value
        /// </summary>
        public static object GetProperty135(DependencyObject element)
        {
            return element.GetValue(Property135Property);
        }

        /// <summary>
        /// dependency property Property136 Property
        /// </summary>
        public static DependencyProperty Property136Property = DependencyProperty.RegisterAttached("Property136", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property136 value
        /// </summary>
        public static void SetProperty136(DependencyObject element, object value)
        {
            element.SetValue(Property136Property, value);
        }

        /// <summary>
        /// get Property136 value
        /// </summary>
        public static object GetProperty136(DependencyObject element)
        {
            return element.GetValue(Property136Property);
        }

        /// <summary>
        /// dependency property Property137 Property
        /// </summary>
        public static DependencyProperty Property137Property = DependencyProperty.RegisterAttached("Property137", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property137 value
        /// </summary>
        public static void SetProperty137(DependencyObject element, object value)
        {
            element.SetValue(Property137Property, value);
        }

        /// <summary>
        /// get Property137 value
        /// </summary>
        public static object GetProperty137(DependencyObject element)
        {
            return element.GetValue(Property137Property);
        }

        /// <summary>
        /// dependency property Property138 Property
        /// </summary>
        public static DependencyProperty Property138Property = DependencyProperty.RegisterAttached("Property138", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property138 value
        /// </summary>
        public static void SetProperty138(DependencyObject element, object value)
        {
            element.SetValue(Property138Property, value);
        }

        /// <summary>
        /// get Property138 value
        /// </summary>
        public static object GetProperty138(DependencyObject element)
        {
            return element.GetValue(Property138Property);
        }

        /// <summary>
        /// dependency property Property139 Property
        /// </summary>
        public static DependencyProperty Property139Property = DependencyProperty.RegisterAttached("Property139", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property139 value
        /// </summary>
        public static void SetProperty139(DependencyObject element, object value)
        {
            element.SetValue(Property139Property, value);
        }

        /// <summary>
        /// get Property139 value
        /// </summary>
        public static object GetProperty139(DependencyObject element)
        {
            return element.GetValue(Property139Property);
        }

        /// <summary>
        /// dependency property Property140 Property
        /// </summary>
        public static DependencyProperty Property140Property = DependencyProperty.RegisterAttached("Property140", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property140 value
        /// </summary>
        public static void SetProperty140(DependencyObject element, object value)
        {
            element.SetValue(Property140Property, value);
        }

        /// <summary>
        /// get Property140 value
        /// </summary>
        public static object GetProperty140(DependencyObject element)
        {
            return element.GetValue(Property140Property);
        }

        /// <summary>
        /// dependency property Property141 Property
        /// </summary>
        public static DependencyProperty Property141Property = DependencyProperty.RegisterAttached("Property141", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property141 value
        /// </summary>
        public static void SetProperty141(DependencyObject element, object value)
        {
            element.SetValue(Property141Property, value);
        }

        /// <summary>
        /// get Property141 value
        /// </summary>
        public static object GetProperty141(DependencyObject element)
        {
            return element.GetValue(Property141Property);
        }

        /// <summary>
        /// dependency property Property142 Property
        /// </summary>
        public static DependencyProperty Property142Property = DependencyProperty.RegisterAttached("Property142", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property142 value
        /// </summary>
        public static void SetProperty142(DependencyObject element, object value)
        {
            element.SetValue(Property142Property, value);
        }

        /// <summary>
        /// get Property142 value
        /// </summary>
        public static object GetProperty142(DependencyObject element)
        {
            return element.GetValue(Property142Property);
        }

        /// <summary>
        /// dependency property Property143 Property
        /// </summary>
        public static DependencyProperty Property143Property = DependencyProperty.RegisterAttached("Property143", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property143 value
        /// </summary>
        public static void SetProperty143(DependencyObject element, object value)
        {
            element.SetValue(Property143Property, value);
        }

        /// <summary>
        /// get Property143 value
        /// </summary>
        public static object GetProperty143(DependencyObject element)
        {
            return element.GetValue(Property143Property);
        }

        /// <summary>
        /// dependency property Property144 Property
        /// </summary>
        public static DependencyProperty Property144Property = DependencyProperty.RegisterAttached("Property144", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property144 value
        /// </summary>
        public static void SetProperty144(DependencyObject element, object value)
        {
            element.SetValue(Property144Property, value);
        }

        /// <summary>
        /// get Property144 value
        /// </summary>
        public static object GetProperty144(DependencyObject element)
        {
            return element.GetValue(Property144Property);
        }

        /// <summary>
        /// dependency property Property145 Property
        /// </summary>
        public static DependencyProperty Property145Property = DependencyProperty.RegisterAttached("Property145", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property145 value
        /// </summary>
        public static void SetProperty145(DependencyObject element, object value)
        {
            element.SetValue(Property145Property, value);
        }

        /// <summary>
        /// get Property145 value
        /// </summary>
        public static object GetProperty145(DependencyObject element)
        {
            return element.GetValue(Property145Property);
        }

        /// <summary>
        /// dependency property Property146 Property
        /// </summary>
        public static DependencyProperty Property146Property = DependencyProperty.RegisterAttached("Property146", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property146 value
        /// </summary>
        public static void SetProperty146(DependencyObject element, object value)
        {
            element.SetValue(Property146Property, value);
        }

        /// <summary>
        /// get Property146 value
        /// </summary>
        public static object GetProperty146(DependencyObject element)
        {
            return element.GetValue(Property146Property);
        }

        /// <summary>
        /// dependency property Property147 Property
        /// </summary>
        public static DependencyProperty Property147Property = DependencyProperty.RegisterAttached("Property147", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property147 value
        /// </summary>
        public static void SetProperty147(DependencyObject element, object value)
        {
            element.SetValue(Property147Property, value);
        }

        /// <summary>
        /// get Property147 value
        /// </summary>
        public static object GetProperty147(DependencyObject element)
        {
            return element.GetValue(Property147Property);
        }

        /// <summary>
        /// dependency property Property148 Property
        /// </summary>
        public static DependencyProperty Property148Property = DependencyProperty.RegisterAttached("Property148", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property148 value
        /// </summary>
        public static void SetProperty148(DependencyObject element, object value)
        {
            element.SetValue(Property148Property, value);
        }

        /// <summary>
        /// get Property148 value
        /// </summary>
        public static object GetProperty148(DependencyObject element)
        {
            return element.GetValue(Property148Property);
        }

        /// <summary>
        /// dependency property Property149 Property
        /// </summary>
        public static DependencyProperty Property149Property = DependencyProperty.RegisterAttached("Property149", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property149 value
        /// </summary>
        public static void SetProperty149(DependencyObject element, object value)
        {
            element.SetValue(Property149Property, value);
        }

        /// <summary>
        /// get Property149 value
        /// </summary>
        public static object GetProperty149(DependencyObject element)
        {
            return element.GetValue(Property149Property);
        }

        /// <summary>
        /// dependency property Property150 Property
        /// </summary>
        public static DependencyProperty Property150Property = DependencyProperty.RegisterAttached("Property150", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property150 value
        /// </summary>
        public static void SetProperty150(DependencyObject element, object value)
        {
            element.SetValue(Property150Property, value);
        }

        /// <summary>
        /// get Property150 value
        /// </summary>
        public static object GetProperty150(DependencyObject element)
        {
            return element.GetValue(Property150Property);
        }

        /// <summary>
        /// dependency property Property151 Property
        /// </summary>
        public static DependencyProperty Property151Property = DependencyProperty.RegisterAttached("Property151", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property151 value
        /// </summary>
        public static void SetProperty151(DependencyObject element, object value)
        {
            element.SetValue(Property151Property, value);
        }

        /// <summary>
        /// get Property151 value
        /// </summary>
        public static object GetProperty151(DependencyObject element)
        {
            return element.GetValue(Property151Property);
        }

        /// <summary>
        /// dependency property Property152 Property
        /// </summary>
        public static DependencyProperty Property152Property = DependencyProperty.RegisterAttached("Property152", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property152 value
        /// </summary>
        public static void SetProperty152(DependencyObject element, object value)
        {
            element.SetValue(Property152Property, value);
        }

        /// <summary>
        /// get Property152 value
        /// </summary>
        public static object GetProperty152(DependencyObject element)
        {
            return element.GetValue(Property152Property);
        }

        /// <summary>
        /// dependency property Property153 Property
        /// </summary>
        public static DependencyProperty Property153Property = DependencyProperty.RegisterAttached("Property153", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property153 value
        /// </summary>
        public static void SetProperty153(DependencyObject element, object value)
        {
            element.SetValue(Property153Property, value);
        }

        /// <summary>
        /// get Property153 value
        /// </summary>
        public static object GetProperty153(DependencyObject element)
        {
            return element.GetValue(Property153Property);
        }

        /// <summary>
        /// dependency property Property154 Property
        /// </summary>
        public static DependencyProperty Property154Property = DependencyProperty.RegisterAttached("Property154", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property154 value
        /// </summary>
        public static void SetProperty154(DependencyObject element, object value)
        {
            element.SetValue(Property154Property, value);
        }

        /// <summary>
        /// get Property154 value
        /// </summary>
        public static object GetProperty154(DependencyObject element)
        {
            return element.GetValue(Property154Property);
        }

        /// <summary>
        /// dependency property Property155 Property
        /// </summary>
        public static DependencyProperty Property155Property = DependencyProperty.RegisterAttached("Property155", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property155 value
        /// </summary>
        public static void SetProperty155(DependencyObject element, object value)
        {
            element.SetValue(Property155Property, value);
        }

        /// <summary>
        /// get Property155 value
        /// </summary>
        public static object GetProperty155(DependencyObject element)
        {
            return element.GetValue(Property155Property);
        }

        /// <summary>
        /// dependency property Property156 Property
        /// </summary>
        public static DependencyProperty Property156Property = DependencyProperty.RegisterAttached("Property156", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property156 value
        /// </summary>
        public static void SetProperty156(DependencyObject element, object value)
        {
            element.SetValue(Property156Property, value);
        }

        /// <summary>
        /// get Property156 value
        /// </summary>
        public static object GetProperty156(DependencyObject element)
        {
            return element.GetValue(Property156Property);
        }

        /// <summary>
        /// dependency property Property157 Property
        /// </summary>
        public static DependencyProperty Property157Property = DependencyProperty.RegisterAttached("Property157", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property157 value
        /// </summary>
        public static void SetProperty157(DependencyObject element, object value)
        {
            element.SetValue(Property157Property, value);
        }

        /// <summary>
        /// get Property157 value
        /// </summary>
        public static object GetProperty157(DependencyObject element)
        {
            return element.GetValue(Property157Property);
        }

        /// <summary>
        /// dependency property Property158 Property
        /// </summary>
        public static DependencyProperty Property158Property = DependencyProperty.RegisterAttached("Property158", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property158 value
        /// </summary>
        public static void SetProperty158(DependencyObject element, object value)
        {
            element.SetValue(Property158Property, value);
        }

        /// <summary>
        /// get Property158 value
        /// </summary>
        public static object GetProperty158(DependencyObject element)
        {
            return element.GetValue(Property158Property);
        }

        /// <summary>
        /// dependency property Property159 Property
        /// </summary>
        public static DependencyProperty Property159Property = DependencyProperty.RegisterAttached("Property159", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property159 value
        /// </summary>
        public static void SetProperty159(DependencyObject element, object value)
        {
            element.SetValue(Property159Property, value);
        }

        /// <summary>
        /// get Property159 value
        /// </summary>
        public static object GetProperty159(DependencyObject element)
        {
            return element.GetValue(Property159Property);
        }

        /// <summary>
        /// dependency property Property160 Property
        /// </summary>
        public static DependencyProperty Property160Property = DependencyProperty.RegisterAttached("Property160", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property160 value
        /// </summary>
        public static void SetProperty160(DependencyObject element, object value)
        {
            element.SetValue(Property160Property, value);
        }

        /// <summary>
        /// get Property160 value
        /// </summary>
        public static object GetProperty160(DependencyObject element)
        {
            return element.GetValue(Property160Property);
        }

        /// <summary>
        /// dependency property Property161 Property
        /// </summary>
        public static DependencyProperty Property161Property = DependencyProperty.RegisterAttached("Property161", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property161 value
        /// </summary>
        public static void SetProperty161(DependencyObject element, object value)
        {
            element.SetValue(Property161Property, value);
        }

        /// <summary>
        /// get Property161 value
        /// </summary>
        public static object GetProperty161(DependencyObject element)
        {
            return element.GetValue(Property161Property);
        }

        /// <summary>
        /// dependency property Property162 Property
        /// </summary>
        public static DependencyProperty Property162Property = DependencyProperty.RegisterAttached("Property162", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property162 value
        /// </summary>
        public static void SetProperty162(DependencyObject element, object value)
        {
            element.SetValue(Property162Property, value);
        }

        /// <summary>
        /// get Property162 value
        /// </summary>
        public static object GetProperty162(DependencyObject element)
        {
            return element.GetValue(Property162Property);
        }

        /// <summary>
        /// dependency property Property163 Property
        /// </summary>
        public static DependencyProperty Property163Property = DependencyProperty.RegisterAttached("Property163", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property163 value
        /// </summary>
        public static void SetProperty163(DependencyObject element, object value)
        {
            element.SetValue(Property163Property, value);
        }

        /// <summary>
        /// get Property163 value
        /// </summary>
        public static object GetProperty163(DependencyObject element)
        {
            return element.GetValue(Property163Property);
        }

        /// <summary>
        /// dependency property Property164 Property
        /// </summary>
        public static DependencyProperty Property164Property = DependencyProperty.RegisterAttached("Property164", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property164 value
        /// </summary>
        public static void SetProperty164(DependencyObject element, object value)
        {
            element.SetValue(Property164Property, value);
        }

        /// <summary>
        /// get Property164 value
        /// </summary>
        public static object GetProperty164(DependencyObject element)
        {
            return element.GetValue(Property164Property);
        }

        /// <summary>
        /// dependency property Property165 Property
        /// </summary>
        public static DependencyProperty Property165Property = DependencyProperty.RegisterAttached("Property165", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property165 value
        /// </summary>
        public static void SetProperty165(DependencyObject element, object value)
        {
            element.SetValue(Property165Property, value);
        }

        /// <summary>
        /// get Property165 value
        /// </summary>
        public static object GetProperty165(DependencyObject element)
        {
            return element.GetValue(Property165Property);
        }

        /// <summary>
        /// dependency property Property166 Property
        /// </summary>
        public static DependencyProperty Property166Property = DependencyProperty.RegisterAttached("Property166", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property166 value
        /// </summary>
        public static void SetProperty166(DependencyObject element, object value)
        {
            element.SetValue(Property166Property, value);
        }

        /// <summary>
        /// get Property166 value
        /// </summary>
        public static object GetProperty166(DependencyObject element)
        {
            return element.GetValue(Property166Property);
        }

        /// <summary>
        /// dependency property Property167 Property
        /// </summary>
        public static DependencyProperty Property167Property = DependencyProperty.RegisterAttached("Property167", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property167 value
        /// </summary>
        public static void SetProperty167(DependencyObject element, object value)
        {
            element.SetValue(Property167Property, value);
        }

        /// <summary>
        /// get Property167 value
        /// </summary>
        public static object GetProperty167(DependencyObject element)
        {
            return element.GetValue(Property167Property);
        }

        /// <summary>
        /// dependency property Property168 Property
        /// </summary>
        public static DependencyProperty Property168Property = DependencyProperty.RegisterAttached("Property168", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property168 value
        /// </summary>
        public static void SetProperty168(DependencyObject element, object value)
        {
            element.SetValue(Property168Property, value);
        }

        /// <summary>
        /// get Property168 value
        /// </summary>
        public static object GetProperty168(DependencyObject element)
        {
            return element.GetValue(Property168Property);
        }

        /// <summary>
        /// dependency property Property169 Property
        /// </summary>
        public static DependencyProperty Property169Property = DependencyProperty.RegisterAttached("Property169", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property169 value
        /// </summary>
        public static void SetProperty169(DependencyObject element, object value)
        {
            element.SetValue(Property169Property, value);
        }

        /// <summary>
        /// get Property169 value
        /// </summary>
        public static object GetProperty169(DependencyObject element)
        {
            return element.GetValue(Property169Property);
        }

        /// <summary>
        /// dependency property Property170 Property
        /// </summary>
        public static DependencyProperty Property170Property = DependencyProperty.RegisterAttached("Property170", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property170 value
        /// </summary>
        public static void SetProperty170(DependencyObject element, object value)
        {
            element.SetValue(Property170Property, value);
        }

        /// <summary>
        /// get Property170 value
        /// </summary>
        public static object GetProperty170(DependencyObject element)
        {
            return element.GetValue(Property170Property);
        }

        /// <summary>
        /// dependency property Property171 Property
        /// </summary>
        public static DependencyProperty Property171Property = DependencyProperty.RegisterAttached("Property171", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property171 value
        /// </summary>
        public static void SetProperty171(DependencyObject element, object value)
        {
            element.SetValue(Property171Property, value);
        }

        /// <summary>
        /// get Property171 value
        /// </summary>
        public static object GetProperty171(DependencyObject element)
        {
            return element.GetValue(Property171Property);
        }

        /// <summary>
        /// dependency property Property172 Property
        /// </summary>
        public static DependencyProperty Property172Property = DependencyProperty.RegisterAttached("Property172", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property172 value
        /// </summary>
        public static void SetProperty172(DependencyObject element, object value)
        {
            element.SetValue(Property172Property, value);
        }

        /// <summary>
        /// get Property172 value
        /// </summary>
        public static object GetProperty172(DependencyObject element)
        {
            return element.GetValue(Property172Property);
        }

        /// <summary>
        /// dependency property Property173 Property
        /// </summary>
        public static DependencyProperty Property173Property = DependencyProperty.RegisterAttached("Property173", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property173 value
        /// </summary>
        public static void SetProperty173(DependencyObject element, object value)
        {
            element.SetValue(Property173Property, value);
        }

        /// <summary>
        /// get Property173 value
        /// </summary>
        public static object GetProperty173(DependencyObject element)
        {
            return element.GetValue(Property173Property);
        }

        /// <summary>
        /// dependency property Property174 Property
        /// </summary>
        public static DependencyProperty Property174Property = DependencyProperty.RegisterAttached("Property174", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property174 value
        /// </summary>
        public static void SetProperty174(DependencyObject element, object value)
        {
            element.SetValue(Property174Property, value);
        }

        /// <summary>
        /// get Property174 value
        /// </summary>
        public static object GetProperty174(DependencyObject element)
        {
            return element.GetValue(Property174Property);
        }

        /// <summary>
        /// dependency property Property175 Property
        /// </summary>
        public static DependencyProperty Property175Property = DependencyProperty.RegisterAttached("Property175", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property175 value
        /// </summary>
        public static void SetProperty175(DependencyObject element, object value)
        {
            element.SetValue(Property175Property, value);
        }

        /// <summary>
        /// get Property175 value
        /// </summary>
        public static object GetProperty175(DependencyObject element)
        {
            return element.GetValue(Property175Property);
        }

        /// <summary>
        /// dependency property Property176 Property
        /// </summary>
        public static DependencyProperty Property176Property = DependencyProperty.RegisterAttached("Property176", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property176 value
        /// </summary>
        public static void SetProperty176(DependencyObject element, object value)
        {
            element.SetValue(Property176Property, value);
        }

        /// <summary>
        /// get Property176 value
        /// </summary>
        public static object GetProperty176(DependencyObject element)
        {
            return element.GetValue(Property176Property);
        }

        /// <summary>
        /// dependency property Property177 Property
        /// </summary>
        public static DependencyProperty Property177Property = DependencyProperty.RegisterAttached("Property177", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property177 value
        /// </summary>
        public static void SetProperty177(DependencyObject element, object value)
        {
            element.SetValue(Property177Property, value);
        }

        /// <summary>
        /// get Property177 value
        /// </summary>
        public static object GetProperty177(DependencyObject element)
        {
            return element.GetValue(Property177Property);
        }

        /// <summary>
        /// dependency property Property178 Property
        /// </summary>
        public static DependencyProperty Property178Property = DependencyProperty.RegisterAttached("Property178", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property178 value
        /// </summary>
        public static void SetProperty178(DependencyObject element, object value)
        {
            element.SetValue(Property178Property, value);
        }

        /// <summary>
        /// get Property178 value
        /// </summary>
        public static object GetProperty178(DependencyObject element)
        {
            return element.GetValue(Property178Property);
        }

        /// <summary>
        /// dependency property Property179 Property
        /// </summary>
        public static DependencyProperty Property179Property = DependencyProperty.RegisterAttached("Property179", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property179 value
        /// </summary>
        public static void SetProperty179(DependencyObject element, object value)
        {
            element.SetValue(Property179Property, value);
        }

        /// <summary>
        /// get Property179 value
        /// </summary>
        public static object GetProperty179(DependencyObject element)
        {
            return element.GetValue(Property179Property);
        }

        /// <summary>
        /// dependency property Property180 Property
        /// </summary>
        public static DependencyProperty Property180Property = DependencyProperty.RegisterAttached("Property180", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property180 value
        /// </summary>
        public static void SetProperty180(DependencyObject element, object value)
        {
            element.SetValue(Property180Property, value);
        }

        /// <summary>
        /// get Property180 value
        /// </summary>
        public static object GetProperty180(DependencyObject element)
        {
            return element.GetValue(Property180Property);
        }

        /// <summary>
        /// dependency property Property181 Property
        /// </summary>
        public static DependencyProperty Property181Property = DependencyProperty.RegisterAttached("Property181", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property181 value
        /// </summary>
        public static void SetProperty181(DependencyObject element, object value)
        {
            element.SetValue(Property181Property, value);
        }

        /// <summary>
        /// get Property181 value
        /// </summary>
        public static object GetProperty181(DependencyObject element)
        {
            return element.GetValue(Property181Property);
        }

        /// <summary>
        /// dependency property Property182 Property
        /// </summary>
        public static DependencyProperty Property182Property = DependencyProperty.RegisterAttached("Property182", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property182 value
        /// </summary>
        public static void SetProperty182(DependencyObject element, object value)
        {
            element.SetValue(Property182Property, value);
        }

        /// <summary>
        /// get Property182 value
        /// </summary>
        public static object GetProperty182(DependencyObject element)
        {
            return element.GetValue(Property182Property);
        }

        /// <summary>
        /// dependency property Property183 Property
        /// </summary>
        public static DependencyProperty Property183Property = DependencyProperty.RegisterAttached("Property183", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property183 value
        /// </summary>
        public static void SetProperty183(DependencyObject element, object value)
        {
            element.SetValue(Property183Property, value);
        }

        /// <summary>
        /// get Property183 value
        /// </summary>
        public static object GetProperty183(DependencyObject element)
        {
            return element.GetValue(Property183Property);
        }

        /// <summary>
        /// dependency property Property184 Property
        /// </summary>
        public static DependencyProperty Property184Property = DependencyProperty.RegisterAttached("Property184", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property184 value
        /// </summary>
        public static void SetProperty184(DependencyObject element, object value)
        {
            element.SetValue(Property184Property, value);
        }

        /// <summary>
        /// get Property184 value
        /// </summary>
        public static object GetProperty184(DependencyObject element)
        {
            return element.GetValue(Property184Property);
        }

        /// <summary>
        /// dependency property Property185 Property
        /// </summary>
        public static DependencyProperty Property185Property = DependencyProperty.RegisterAttached("Property185", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property185 value
        /// </summary>
        public static void SetProperty185(DependencyObject element, object value)
        {
            element.SetValue(Property185Property, value);
        }

        /// <summary>
        /// get Property185 value
        /// </summary>
        public static object GetProperty185(DependencyObject element)
        {
            return element.GetValue(Property185Property);
        }

        /// <summary>
        /// dependency property Property186 Property
        /// </summary>
        public static DependencyProperty Property186Property = DependencyProperty.RegisterAttached("Property186", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property186 value
        /// </summary>
        public static void SetProperty186(DependencyObject element, object value)
        {
            element.SetValue(Property186Property, value);
        }

        /// <summary>
        /// get Property186 value
        /// </summary>
        public static object GetProperty186(DependencyObject element)
        {
            return element.GetValue(Property186Property);
        }

        /// <summary>
        /// dependency property Property187 Property
        /// </summary>
        public static DependencyProperty Property187Property = DependencyProperty.RegisterAttached("Property187", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property187 value
        /// </summary>
        public static void SetProperty187(DependencyObject element, object value)
        {
            element.SetValue(Property187Property, value);
        }

        /// <summary>
        /// get Property187 value
        /// </summary>
        public static object GetProperty187(DependencyObject element)
        {
            return element.GetValue(Property187Property);
        }

        /// <summary>
        /// dependency property Property188 Property
        /// </summary>
        public static DependencyProperty Property188Property = DependencyProperty.RegisterAttached("Property188", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property188 value
        /// </summary>
        public static void SetProperty188(DependencyObject element, object value)
        {
            element.SetValue(Property188Property, value);
        }

        /// <summary>
        /// get Property188 value
        /// </summary>
        public static object GetProperty188(DependencyObject element)
        {
            return element.GetValue(Property188Property);
        }

        /// <summary>
        /// dependency property Property189 Property
        /// </summary>
        public static DependencyProperty Property189Property = DependencyProperty.RegisterAttached("Property189", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property189 value
        /// </summary>
        public static void SetProperty189(DependencyObject element, object value)
        {
            element.SetValue(Property189Property, value);
        }

        /// <summary>
        /// get Property189 value
        /// </summary>
        public static object GetProperty189(DependencyObject element)
        {
            return element.GetValue(Property189Property);
        }

        /// <summary>
        /// dependency property Property190 Property
        /// </summary>
        public static DependencyProperty Property190Property = DependencyProperty.RegisterAttached("Property190", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property190 value
        /// </summary>
        public static void SetProperty190(DependencyObject element, object value)
        {
            element.SetValue(Property190Property, value);
        }

        /// <summary>
        /// get Property190 value
        /// </summary>
        public static object GetProperty190(DependencyObject element)
        {
            return element.GetValue(Property190Property);
        }

        /// <summary>
        /// dependency property Property191 Property
        /// </summary>
        public static DependencyProperty Property191Property = DependencyProperty.RegisterAttached("Property191", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property191 value
        /// </summary>
        public static void SetProperty191(DependencyObject element, object value)
        {
            element.SetValue(Property191Property, value);
        }

        /// <summary>
        /// get Property191 value
        /// </summary>
        public static object GetProperty191(DependencyObject element)
        {
            return element.GetValue(Property191Property);
        }

        /// <summary>
        /// dependency property Property192 Property
        /// </summary>
        public static DependencyProperty Property192Property = DependencyProperty.RegisterAttached("Property192", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property192 value
        /// </summary>
        public static void SetProperty192(DependencyObject element, object value)
        {
            element.SetValue(Property192Property, value);
        }

        /// <summary>
        /// get Property192 value
        /// </summary>
        public static object GetProperty192(DependencyObject element)
        {
            return element.GetValue(Property192Property);
        }

        /// <summary>
        /// dependency property Property193 Property
        /// </summary>
        public static DependencyProperty Property193Property = DependencyProperty.RegisterAttached("Property193", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property193 value
        /// </summary>
        public static void SetProperty193(DependencyObject element, object value)
        {
            element.SetValue(Property193Property, value);
        }

        /// <summary>
        /// get Property193 value
        /// </summary>
        public static object GetProperty193(DependencyObject element)
        {
            return element.GetValue(Property193Property);
        }

        /// <summary>
        /// dependency property Property194 Property
        /// </summary>
        public static DependencyProperty Property194Property = DependencyProperty.RegisterAttached("Property194", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property194 value
        /// </summary>
        public static void SetProperty194(DependencyObject element, object value)
        {
            element.SetValue(Property194Property, value);
        }

        /// <summary>
        /// get Property194 value
        /// </summary>
        public static object GetProperty194(DependencyObject element)
        {
            return element.GetValue(Property194Property);
        }

        /// <summary>
        /// dependency property Property195 Property
        /// </summary>
        public static DependencyProperty Property195Property = DependencyProperty.RegisterAttached("Property195", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property195 value
        /// </summary>
        public static void SetProperty195(DependencyObject element, object value)
        {
            element.SetValue(Property195Property, value);
        }

        /// <summary>
        /// get Property195 value
        /// </summary>
        public static object GetProperty195(DependencyObject element)
        {
            return element.GetValue(Property195Property);
        }

        /// <summary>
        /// dependency property Property196 Property
        /// </summary>
        public static DependencyProperty Property196Property = DependencyProperty.RegisterAttached("Property196", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property196 value
        /// </summary>
        public static void SetProperty196(DependencyObject element, object value)
        {
            element.SetValue(Property196Property, value);
        }

        /// <summary>
        /// get Property196 value
        /// </summary>
        public static object GetProperty196(DependencyObject element)
        {
            return element.GetValue(Property196Property);
        }

        /// <summary>
        /// dependency property Property197 Property
        /// </summary>
        public static DependencyProperty Property197Property = DependencyProperty.RegisterAttached("Property197", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property197 value
        /// </summary>
        public static void SetProperty197(DependencyObject element, object value)
        {
            element.SetValue(Property197Property, value);
        }

        /// <summary>
        /// get Property197 value
        /// </summary>
        public static object GetProperty197(DependencyObject element)
        {
            return element.GetValue(Property197Property);
        }

        /// <summary>
        /// dependency property Property198 Property
        /// </summary>
        public static DependencyProperty Property198Property = DependencyProperty.RegisterAttached("Property198", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property198 value
        /// </summary>
        public static void SetProperty198(DependencyObject element, object value)
        {
            element.SetValue(Property198Property, value);
        }

        /// <summary>
        /// get Property198 value
        /// </summary>
        public static object GetProperty198(DependencyObject element)
        {
            return element.GetValue(Property198Property);
        }

        /// <summary>
        /// dependency property Property199 Property
        /// </summary>
        public static DependencyProperty Property199Property = DependencyProperty.RegisterAttached("Property199", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property199 value
        /// </summary>
        public static void SetProperty199(DependencyObject element, object value)
        {
            element.SetValue(Property199Property, value);
        }

        /// <summary>
        /// get Property199 value
        /// </summary>
        public static object GetProperty199(DependencyObject element)
        {
            return element.GetValue(Property199Property);
        }

        /// <summary>
        /// dependency property Property200 Property
        /// </summary>
        public static DependencyProperty Property200Property = DependencyProperty.RegisterAttached("Property200", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property200 value
        /// </summary>
        public static void SetProperty200(DependencyObject element, object value)
        {
            element.SetValue(Property200Property, value);
        }

        /// <summary>
        /// get Property200 value
        /// </summary>
        public static object GetProperty200(DependencyObject element)
        {
            return element.GetValue(Property200Property);
        }

        /// <summary>
        /// dependency property Property201 Property
        /// </summary>
        public static DependencyProperty Property201Property = DependencyProperty.RegisterAttached("Property201", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property201 value
        /// </summary>
        public static void SetProperty201(DependencyObject element, object value)
        {
            element.SetValue(Property201Property, value);
        }

        /// <summary>
        /// get Property201 value
        /// </summary>
        public static object GetProperty201(DependencyObject element)
        {
            return element.GetValue(Property201Property);
        }

        /// <summary>
        /// dependency property Property202 Property
        /// </summary>
        public static DependencyProperty Property202Property = DependencyProperty.RegisterAttached("Property202", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property202 value
        /// </summary>
        public static void SetProperty202(DependencyObject element, object value)
        {
            element.SetValue(Property202Property, value);
        }

        /// <summary>
        /// get Property202 value
        /// </summary>
        public static object GetProperty202(DependencyObject element)
        {
            return element.GetValue(Property202Property);
        }

        /// <summary>
        /// dependency property Property203 Property
        /// </summary>
        public static DependencyProperty Property203Property = DependencyProperty.RegisterAttached("Property203", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property203 value
        /// </summary>
        public static void SetProperty203(DependencyObject element, object value)
        {
            element.SetValue(Property203Property, value);
        }

        /// <summary>
        /// get Property203 value
        /// </summary>
        public static object GetProperty203(DependencyObject element)
        {
            return element.GetValue(Property203Property);
        }

        /// <summary>
        /// dependency property Property204 Property
        /// </summary>
        public static DependencyProperty Property204Property = DependencyProperty.RegisterAttached("Property204", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property204 value
        /// </summary>
        public static void SetProperty204(DependencyObject element, object value)
        {
            element.SetValue(Property204Property, value);
        }

        /// <summary>
        /// get Property204 value
        /// </summary>
        public static object GetProperty204(DependencyObject element)
        {
            return element.GetValue(Property204Property);
        }

        /// <summary>
        /// dependency property Property205 Property
        /// </summary>
        public static DependencyProperty Property205Property = DependencyProperty.RegisterAttached("Property205", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property205 value
        /// </summary>
        public static void SetProperty205(DependencyObject element, object value)
        {
            element.SetValue(Property205Property, value);
        }

        /// <summary>
        /// get Property205 value
        /// </summary>
        public static object GetProperty205(DependencyObject element)
        {
            return element.GetValue(Property205Property);
        }

        /// <summary>
        /// dependency property Property206 Property
        /// </summary>
        public static DependencyProperty Property206Property = DependencyProperty.RegisterAttached("Property206", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property206 value
        /// </summary>
        public static void SetProperty206(DependencyObject element, object value)
        {
            element.SetValue(Property206Property, value);
        }

        /// <summary>
        /// get Property206 value
        /// </summary>
        public static object GetProperty206(DependencyObject element)
        {
            return element.GetValue(Property206Property);
        }

        /// <summary>
        /// dependency property Property207 Property
        /// </summary>
        public static DependencyProperty Property207Property = DependencyProperty.RegisterAttached("Property207", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property207 value
        /// </summary>
        public static void SetProperty207(DependencyObject element, object value)
        {
            element.SetValue(Property207Property, value);
        }

        /// <summary>
        /// get Property207 value
        /// </summary>
        public static object GetProperty207(DependencyObject element)
        {
            return element.GetValue(Property207Property);
        }

        /// <summary>
        /// dependency property Property208 Property
        /// </summary>
        public static DependencyProperty Property208Property = DependencyProperty.RegisterAttached("Property208", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property208 value
        /// </summary>
        public static void SetProperty208(DependencyObject element, object value)
        {
            element.SetValue(Property208Property, value);
        }

        /// <summary>
        /// get Property208 value
        /// </summary>
        public static object GetProperty208(DependencyObject element)
        {
            return element.GetValue(Property208Property);
        }

        /// <summary>
        /// dependency property Property209 Property
        /// </summary>
        public static DependencyProperty Property209Property = DependencyProperty.RegisterAttached("Property209", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property209 value
        /// </summary>
        public static void SetProperty209(DependencyObject element, object value)
        {
            element.SetValue(Property209Property, value);
        }

        /// <summary>
        /// get Property209 value
        /// </summary>
        public static object GetProperty209(DependencyObject element)
        {
            return element.GetValue(Property209Property);
        }

        /// <summary>
        /// dependency property Property210 Property
        /// </summary>
        public static DependencyProperty Property210Property = DependencyProperty.RegisterAttached("Property210", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property210 value
        /// </summary>
        public static void SetProperty210(DependencyObject element, object value)
        {
            element.SetValue(Property210Property, value);
        }

        /// <summary>
        /// get Property210 value
        /// </summary>
        public static object GetProperty210(DependencyObject element)
        {
            return element.GetValue(Property210Property);
        }

        /// <summary>
        /// dependency property Property211 Property
        /// </summary>
        public static DependencyProperty Property211Property = DependencyProperty.RegisterAttached("Property211", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property211 value
        /// </summary>
        public static void SetProperty211(DependencyObject element, object value)
        {
            element.SetValue(Property211Property, value);
        }

        /// <summary>
        /// get Property211 value
        /// </summary>
        public static object GetProperty211(DependencyObject element)
        {
            return element.GetValue(Property211Property);
        }

        /// <summary>
        /// dependency property Property212 Property
        /// </summary>
        public static DependencyProperty Property212Property = DependencyProperty.RegisterAttached("Property212", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property212 value
        /// </summary>
        public static void SetProperty212(DependencyObject element, object value)
        {
            element.SetValue(Property212Property, value);
        }

        /// <summary>
        /// get Property212 value
        /// </summary>
        public static object GetProperty212(DependencyObject element)
        {
            return element.GetValue(Property212Property);
        }

        /// <summary>
        /// dependency property Property213 Property
        /// </summary>
        public static DependencyProperty Property213Property = DependencyProperty.RegisterAttached("Property213", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property213 value
        /// </summary>
        public static void SetProperty213(DependencyObject element, object value)
        {
            element.SetValue(Property213Property, value);
        }

        /// <summary>
        /// get Property213 value
        /// </summary>
        public static object GetProperty213(DependencyObject element)
        {
            return element.GetValue(Property213Property);
        }

        /// <summary>
        /// dependency property Property214 Property
        /// </summary>
        public static DependencyProperty Property214Property = DependencyProperty.RegisterAttached("Property214", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property214 value
        /// </summary>
        public static void SetProperty214(DependencyObject element, object value)
        {
            element.SetValue(Property214Property, value);
        }

        /// <summary>
        /// get Property214 value
        /// </summary>
        public static object GetProperty214(DependencyObject element)
        {
            return element.GetValue(Property214Property);
        }

        /// <summary>
        /// dependency property Property215 Property
        /// </summary>
        public static DependencyProperty Property215Property = DependencyProperty.RegisterAttached("Property215", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property215 value
        /// </summary>
        public static void SetProperty215(DependencyObject element, object value)
        {
            element.SetValue(Property215Property, value);
        }

        /// <summary>
        /// get Property215 value
        /// </summary>
        public static object GetProperty215(DependencyObject element)
        {
            return element.GetValue(Property215Property);
        }

        /// <summary>
        /// dependency property Property216 Property
        /// </summary>
        public static DependencyProperty Property216Property = DependencyProperty.RegisterAttached("Property216", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property216 value
        /// </summary>
        public static void SetProperty216(DependencyObject element, object value)
        {
            element.SetValue(Property216Property, value);
        }

        /// <summary>
        /// get Property216 value
        /// </summary>
        public static object GetProperty216(DependencyObject element)
        {
            return element.GetValue(Property216Property);
        }

        /// <summary>
        /// dependency property Property217 Property
        /// </summary>
        public static DependencyProperty Property217Property = DependencyProperty.RegisterAttached("Property217", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property217 value
        /// </summary>
        public static void SetProperty217(DependencyObject element, object value)
        {
            element.SetValue(Property217Property, value);
        }

        /// <summary>
        /// get Property217 value
        /// </summary>
        public static object GetProperty217(DependencyObject element)
        {
            return element.GetValue(Property217Property);
        }

        /// <summary>
        /// dependency property Property218 Property
        /// </summary>
        public static DependencyProperty Property218Property = DependencyProperty.RegisterAttached("Property218", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property218 value
        /// </summary>
        public static void SetProperty218(DependencyObject element, object value)
        {
            element.SetValue(Property218Property, value);
        }

        /// <summary>
        /// get Property218 value
        /// </summary>
        public static object GetProperty218(DependencyObject element)
        {
            return element.GetValue(Property218Property);
        }

        /// <summary>
        /// dependency property Property219 Property
        /// </summary>
        public static DependencyProperty Property219Property = DependencyProperty.RegisterAttached("Property219", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property219 value
        /// </summary>
        public static void SetProperty219(DependencyObject element, object value)
        {
            element.SetValue(Property219Property, value);
        }

        /// <summary>
        /// get Property219 value
        /// </summary>
        public static object GetProperty219(DependencyObject element)
        {
            return element.GetValue(Property219Property);
        }

        /// <summary>
        /// dependency property Property220 Property
        /// </summary>
        public static DependencyProperty Property220Property = DependencyProperty.RegisterAttached("Property220", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property220 value
        /// </summary>
        public static void SetProperty220(DependencyObject element, object value)
        {
            element.SetValue(Property220Property, value);
        }

        /// <summary>
        /// get Property220 value
        /// </summary>
        public static object GetProperty220(DependencyObject element)
        {
            return element.GetValue(Property220Property);
        }

        /// <summary>
        /// dependency property Property221 Property
        /// </summary>
        public static DependencyProperty Property221Property = DependencyProperty.RegisterAttached("Property221", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property221 value
        /// </summary>
        public static void SetProperty221(DependencyObject element, object value)
        {
            element.SetValue(Property221Property, value);
        }

        /// <summary>
        /// get Property221 value
        /// </summary>
        public static object GetProperty221(DependencyObject element)
        {
            return element.GetValue(Property221Property);
        }

        /// <summary>
        /// dependency property Property222 Property
        /// </summary>
        public static DependencyProperty Property222Property = DependencyProperty.RegisterAttached("Property222", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property222 value
        /// </summary>
        public static void SetProperty222(DependencyObject element, object value)
        {
            element.SetValue(Property222Property, value);
        }

        /// <summary>
        /// get Property222 value
        /// </summary>
        public static object GetProperty222(DependencyObject element)
        {
            return element.GetValue(Property222Property);
        }

        /// <summary>
        /// dependency property Property223 Property
        /// </summary>
        public static DependencyProperty Property223Property = DependencyProperty.RegisterAttached("Property223", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property223 value
        /// </summary>
        public static void SetProperty223(DependencyObject element, object value)
        {
            element.SetValue(Property223Property, value);
        }

        /// <summary>
        /// get Property223 value
        /// </summary>
        public static object GetProperty223(DependencyObject element)
        {
            return element.GetValue(Property223Property);
        }

        /// <summary>
        /// dependency property Property224 Property
        /// </summary>
        public static DependencyProperty Property224Property = DependencyProperty.RegisterAttached("Property224", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property224 value
        /// </summary>
        public static void SetProperty224(DependencyObject element, object value)
        {
            element.SetValue(Property224Property, value);
        }

        /// <summary>
        /// get Property224 value
        /// </summary>
        public static object GetProperty224(DependencyObject element)
        {
            return element.GetValue(Property224Property);
        }

        /// <summary>
        /// dependency property Property225 Property
        /// </summary>
        public static DependencyProperty Property225Property = DependencyProperty.RegisterAttached("Property225", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property225 value
        /// </summary>
        public static void SetProperty225(DependencyObject element, object value)
        {
            element.SetValue(Property225Property, value);
        }

        /// <summary>
        /// get Property225 value
        /// </summary>
        public static object GetProperty225(DependencyObject element)
        {
            return element.GetValue(Property225Property);
        }

        /// <summary>
        /// dependency property Property226 Property
        /// </summary>
        public static DependencyProperty Property226Property = DependencyProperty.RegisterAttached("Property226", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property226 value
        /// </summary>
        public static void SetProperty226(DependencyObject element, object value)
        {
            element.SetValue(Property226Property, value);
        }

        /// <summary>
        /// get Property226 value
        /// </summary>
        public static object GetProperty226(DependencyObject element)
        {
            return element.GetValue(Property226Property);
        }

        /// <summary>
        /// dependency property Property227 Property
        /// </summary>
        public static DependencyProperty Property227Property = DependencyProperty.RegisterAttached("Property227", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property227 value
        /// </summary>
        public static void SetProperty227(DependencyObject element, object value)
        {
            element.SetValue(Property227Property, value);
        }

        /// <summary>
        /// get Property227 value
        /// </summary>
        public static object GetProperty227(DependencyObject element)
        {
            return element.GetValue(Property227Property);
        }

        /// <summary>
        /// dependency property Property228 Property
        /// </summary>
        public static DependencyProperty Property228Property = DependencyProperty.RegisterAttached("Property228", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property228 value
        /// </summary>
        public static void SetProperty228(DependencyObject element, object value)
        {
            element.SetValue(Property228Property, value);
        }

        /// <summary>
        /// get Property228 value
        /// </summary>
        public static object GetProperty228(DependencyObject element)
        {
            return element.GetValue(Property228Property);
        }

        /// <summary>
        /// dependency property Property229 Property
        /// </summary>
        public static DependencyProperty Property229Property = DependencyProperty.RegisterAttached("Property229", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property229 value
        /// </summary>
        public static void SetProperty229(DependencyObject element, object value)
        {
            element.SetValue(Property229Property, value);
        }

        /// <summary>
        /// get Property229 value
        /// </summary>
        public static object GetProperty229(DependencyObject element)
        {
            return element.GetValue(Property229Property);
        }

        /// <summary>
        /// dependency property Property230 Property
        /// </summary>
        public static DependencyProperty Property230Property = DependencyProperty.RegisterAttached("Property230", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property230 value
        /// </summary>
        public static void SetProperty230(DependencyObject element, object value)
        {
            element.SetValue(Property230Property, value);
        }

        /// <summary>
        /// get Property230 value
        /// </summary>
        public static object GetProperty230(DependencyObject element)
        {
            return element.GetValue(Property230Property);
        }

        /// <summary>
        /// dependency property Property231 Property
        /// </summary>
        public static DependencyProperty Property231Property = DependencyProperty.RegisterAttached("Property231", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property231 value
        /// </summary>
        public static void SetProperty231(DependencyObject element, object value)
        {
            element.SetValue(Property231Property, value);
        }

        /// <summary>
        /// get Property231 value
        /// </summary>
        public static object GetProperty231(DependencyObject element)
        {
            return element.GetValue(Property231Property);
        }

        /// <summary>
        /// dependency property Property232 Property
        /// </summary>
        public static DependencyProperty Property232Property = DependencyProperty.RegisterAttached("Property232", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property232 value
        /// </summary>
        public static void SetProperty232(DependencyObject element, object value)
        {
            element.SetValue(Property232Property, value);
        }

        /// <summary>
        /// get Property232 value
        /// </summary>
        public static object GetProperty232(DependencyObject element)
        {
            return element.GetValue(Property232Property);
        }

        /// <summary>
        /// dependency property Property233 Property
        /// </summary>
        public static DependencyProperty Property233Property = DependencyProperty.RegisterAttached("Property233", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property233 value
        /// </summary>
        public static void SetProperty233(DependencyObject element, object value)
        {
            element.SetValue(Property233Property, value);
        }

        /// <summary>
        /// get Property233 value
        /// </summary>
        public static object GetProperty233(DependencyObject element)
        {
            return element.GetValue(Property233Property);
        }

        /// <summary>
        /// dependency property Property234 Property
        /// </summary>
        public static DependencyProperty Property234Property = DependencyProperty.RegisterAttached("Property234", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property234 value
        /// </summary>
        public static void SetProperty234(DependencyObject element, object value)
        {
            element.SetValue(Property234Property, value);
        }

        /// <summary>
        /// get Property234 value
        /// </summary>
        public static object GetProperty234(DependencyObject element)
        {
            return element.GetValue(Property234Property);
        }

        /// <summary>
        /// dependency property Property235 Property
        /// </summary>
        public static DependencyProperty Property235Property = DependencyProperty.RegisterAttached("Property235", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property235 value
        /// </summary>
        public static void SetProperty235(DependencyObject element, object value)
        {
            element.SetValue(Property235Property, value);
        }

        /// <summary>
        /// get Property235 value
        /// </summary>
        public static object GetProperty235(DependencyObject element)
        {
            return element.GetValue(Property235Property);
        }

        /// <summary>
        /// dependency property Property236 Property
        /// </summary>
        public static DependencyProperty Property236Property = DependencyProperty.RegisterAttached("Property236", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property236 value
        /// </summary>
        public static void SetProperty236(DependencyObject element, object value)
        {
            element.SetValue(Property236Property, value);
        }

        /// <summary>
        /// get Property236 value
        /// </summary>
        public static object GetProperty236(DependencyObject element)
        {
            return element.GetValue(Property236Property);
        }

        /// <summary>
        /// dependency property Property237 Property
        /// </summary>
        public static DependencyProperty Property237Property = DependencyProperty.RegisterAttached("Property237", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property237 value
        /// </summary>
        public static void SetProperty237(DependencyObject element, object value)
        {
            element.SetValue(Property237Property, value);
        }

        /// <summary>
        /// get Property237 value
        /// </summary>
        public static object GetProperty237(DependencyObject element)
        {
            return element.GetValue(Property237Property);
        }

        /// <summary>
        /// dependency property Property238 Property
        /// </summary>
        public static DependencyProperty Property238Property = DependencyProperty.RegisterAttached("Property238", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property238 value
        /// </summary>
        public static void SetProperty238(DependencyObject element, object value)
        {
            element.SetValue(Property238Property, value);
        }

        /// <summary>
        /// get Property238 value
        /// </summary>
        public static object GetProperty238(DependencyObject element)
        {
            return element.GetValue(Property238Property);
        }

        /// <summary>
        /// dependency property Property239 Property
        /// </summary>
        public static DependencyProperty Property239Property = DependencyProperty.RegisterAttached("Property239", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property239 value
        /// </summary>
        public static void SetProperty239(DependencyObject element, object value)
        {
            element.SetValue(Property239Property, value);
        }

        /// <summary>
        /// get Property239 value
        /// </summary>
        public static object GetProperty239(DependencyObject element)
        {
            return element.GetValue(Property239Property);
        }

        /// <summary>
        /// dependency property Property240 Property
        /// </summary>
        public static DependencyProperty Property240Property = DependencyProperty.RegisterAttached("Property240", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property240 value
        /// </summary>
        public static void SetProperty240(DependencyObject element, object value)
        {
            element.SetValue(Property240Property, value);
        }

        /// <summary>
        /// get Property240 value
        /// </summary>
        public static object GetProperty240(DependencyObject element)
        {
            return element.GetValue(Property240Property);
        }

        /// <summary>
        /// dependency property Property241 Property
        /// </summary>
        public static DependencyProperty Property241Property = DependencyProperty.RegisterAttached("Property241", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property241 value
        /// </summary>
        public static void SetProperty241(DependencyObject element, object value)
        {
            element.SetValue(Property241Property, value);
        }

        /// <summary>
        /// get Property241 value
        /// </summary>
        public static object GetProperty241(DependencyObject element)
        {
            return element.GetValue(Property241Property);
        }

        /// <summary>
        /// dependency property Property242 Property
        /// </summary>
        public static DependencyProperty Property242Property = DependencyProperty.RegisterAttached("Property242", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property242 value
        /// </summary>
        public static void SetProperty242(DependencyObject element, object value)
        {
            element.SetValue(Property242Property, value);
        }

        /// <summary>
        /// get Property242 value
        /// </summary>
        public static object GetProperty242(DependencyObject element)
        {
            return element.GetValue(Property242Property);
        }

        /// <summary>
        /// dependency property Property243 Property
        /// </summary>
        public static DependencyProperty Property243Property = DependencyProperty.RegisterAttached("Property243", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property243 value
        /// </summary>
        public static void SetProperty243(DependencyObject element, object value)
        {
            element.SetValue(Property243Property, value);
        }

        /// <summary>
        /// get Property243 value
        /// </summary>
        public static object GetProperty243(DependencyObject element)
        {
            return element.GetValue(Property243Property);
        }

        /// <summary>
        /// dependency property Property244 Property
        /// </summary>
        public static DependencyProperty Property244Property = DependencyProperty.RegisterAttached("Property244", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property244 value
        /// </summary>
        public static void SetProperty244(DependencyObject element, object value)
        {
            element.SetValue(Property244Property, value);
        }

        /// <summary>
        /// get Property244 value
        /// </summary>
        public static object GetProperty244(DependencyObject element)
        {
            return element.GetValue(Property244Property);
        }

        /// <summary>
        /// dependency property Property245 Property
        /// </summary>
        public static DependencyProperty Property245Property = DependencyProperty.RegisterAttached("Property245", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property245 value
        /// </summary>
        public static void SetProperty245(DependencyObject element, object value)
        {
            element.SetValue(Property245Property, value);
        }

        /// <summary>
        /// get Property245 value
        /// </summary>
        public static object GetProperty245(DependencyObject element)
        {
            return element.GetValue(Property245Property);
        }

        /// <summary>
        /// dependency property Property246 Property
        /// </summary>
        public static DependencyProperty Property246Property = DependencyProperty.RegisterAttached("Property246", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property246 value
        /// </summary>
        public static void SetProperty246(DependencyObject element, object value)
        {
            element.SetValue(Property246Property, value);
        }

        /// <summary>
        /// get Property246 value
        /// </summary>
        public static object GetProperty246(DependencyObject element)
        {
            return element.GetValue(Property246Property);
        }

        /// <summary>
        /// dependency property Property247 Property
        /// </summary>
        public static DependencyProperty Property247Property = DependencyProperty.RegisterAttached("Property247", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property247 value
        /// </summary>
        public static void SetProperty247(DependencyObject element, object value)
        {
            element.SetValue(Property247Property, value);
        }

        /// <summary>
        /// get Property247 value
        /// </summary>
        public static object GetProperty247(DependencyObject element)
        {
            return element.GetValue(Property247Property);
        }

        /// <summary>
        /// dependency property Property248 Property
        /// </summary>
        public static DependencyProperty Property248Property = DependencyProperty.RegisterAttached("Property248", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property248 value
        /// </summary>
        public static void SetProperty248(DependencyObject element, object value)
        {
            element.SetValue(Property248Property, value);
        }

        /// <summary>
        /// get Property248 value
        /// </summary>
        public static object GetProperty248(DependencyObject element)
        {
            return element.GetValue(Property248Property);
        }

        /// <summary>
        /// dependency property Property249 Property
        /// </summary>
        public static DependencyProperty Property249Property = DependencyProperty.RegisterAttached("Property249", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property249 value
        /// </summary>
        public static void SetProperty249(DependencyObject element, object value)
        {
            element.SetValue(Property249Property, value);
        }

        /// <summary>
        /// get Property249 value
        /// </summary>
        public static object GetProperty249(DependencyObject element)
        {
            return element.GetValue(Property249Property);
        }

        /// <summary>
        /// dependency property Property250 Property
        /// </summary>
        public static DependencyProperty Property250Property = DependencyProperty.RegisterAttached("Property250", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property250 value
        /// </summary>
        public static void SetProperty250(DependencyObject element, object value)
        {
            element.SetValue(Property250Property, value);
        }

        /// <summary>
        /// get Property250 value
        /// </summary>
        public static object GetProperty250(DependencyObject element)
        {
            return element.GetValue(Property250Property);
        }

        /// <summary>
        /// dependency property Property251 Property
        /// </summary>
        public static DependencyProperty Property251Property = DependencyProperty.RegisterAttached("Property251", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property251 value
        /// </summary>
        public static void SetProperty251(DependencyObject element, object value)
        {
            element.SetValue(Property251Property, value);
        }

        /// <summary>
        /// get Property251 value
        /// </summary>
        public static object GetProperty251(DependencyObject element)
        {
            return element.GetValue(Property251Property);
        }

        /// <summary>
        /// dependency property Property252 Property
        /// </summary>
        public static DependencyProperty Property252Property = DependencyProperty.RegisterAttached("Property252", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property252 value
        /// </summary>
        public static void SetProperty252(DependencyObject element, object value)
        {
            element.SetValue(Property252Property, value);
        }

        /// <summary>
        /// get Property252 value
        /// </summary>
        public static object GetProperty252(DependencyObject element)
        {
            return element.GetValue(Property252Property);
        }

        /// <summary>
        /// dependency property Property253 Property
        /// </summary>
        public static DependencyProperty Property253Property = DependencyProperty.RegisterAttached("Property253", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property253 value
        /// </summary>
        public static void SetProperty253(DependencyObject element, object value)
        {
            element.SetValue(Property253Property, value);
        }

        /// <summary>
        /// get Property253 value
        /// </summary>
        public static object GetProperty253(DependencyObject element)
        {
            return element.GetValue(Property253Property);
        }

        /// <summary>
        /// dependency property Property254 Property
        /// </summary>
        public static DependencyProperty Property254Property = DependencyProperty.RegisterAttached("Property254", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property254 value
        /// </summary>
        public static void SetProperty254(DependencyObject element, object value)
        {
            element.SetValue(Property254Property, value);
        }

        /// <summary>
        /// get Property254 value
        /// </summary>
        public static object GetProperty254(DependencyObject element)
        {
            return element.GetValue(Property254Property);
        }

        /// <summary>
        /// dependency property Property255 Property
        /// </summary>
        public static DependencyProperty Property255Property = DependencyProperty.RegisterAttached("Property255", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        /// <summary>
        /// set Property255 value
        /// </summary>
        public static void SetProperty255(DependencyObject element, object value)
        {
            element.SetValue(Property255Property, value);
        }

        /// <summary>
        /// get Property255 value
        /// </summary>
        public static object GetProperty255(DependencyObject element)
        {
            return element.GetValue(Property255Property);
        }


        internal static DependencyProperty Property256Property = DependencyProperty.RegisterAttached("Property256", typeof(object), typeof(PropertyAttache), new PropertyMetadata(null));
        internal static void SetProperty256(DependencyObject element, object value)
        {
            element.SetValue(Property256Property, value);
        }
        internal static object GetProperty256(DependencyObject element)
        {
            return element.GetValue(Property256Property);
        }

        private static readonly IReadOnlyDictionary<int, DependencyProperty> propertyMapper;

        static PropertyAttache()
        {
            FieldInfo[] dependencyFields = typeof(PropertyAttache).GetFields(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public);

            propertyMapper = dependencyFields.ToDictionary(i => 
            {
                var value=(i.Name.Replace("Property", ""));

                if (int.TryParse(value, out var result))
                {
                    return result;
                }
                else
                {
                    return i.GetHashCode();
                }

            }, i => i.GetValue(null) as DependencyProperty);

        }

        /// <summary>
        /// <paramref name="index"/> must be in range 0-255
        /// </summary>
        /// <param name="target"></param>
        /// <param name="binding"></param>
        /// <param name="index">must be in range 0-255</param>
        public static void SetBinding(DependencyObject target, Binding binding, int index)
        {
            if(propertyMapper.TryGetValue(index,out var par) == false)
            {
                throw new System.IndexOutOfRangeException($"{nameof(index)} within the range of 0 to 255 (inclusive)");
            }
             
            BindingOperations.SetBinding(target, par, binding);
        }

        /// <summary>
        /// <paramref name="index"/> must be in range 0-255
        /// </summary>
        /// <param name="target"></param> 
        /// <param name="index">must be in range 0-255</param>
        public static object GetValue(DependencyObject target, int index)
        {
            if (propertyMapper.TryGetValue(index, out var par) == false)
            {
                throw new System.IndexOutOfRangeException($"{nameof(index)} within the range of 0 to 255 (inclusive)");
            }
            object value = target.GetValue(par);

            return value;
        }


        /// <summary>
        /// <paramref name="index"/> must be in range 0-255
        /// </summary>
        /// <param name="target"></param> 
        /// <param name="value"></param> 
        /// <param name="index">must be in range 0-255</param>
        public static object SetValue<T>(DependencyObject target, T value, int index)
        {
            if (propertyMapper.TryGetValue(index, out var par) == false)
            {
                throw new System.IndexOutOfRangeException($"{nameof(index)} within the range of 0 to 255 (inclusive)");
            }
            target.SetValue(par, value);

            return value;
        }



        /// <summary> 
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="dependencyProperty"> </param>
        /// <param name="binding"></param>

        public static void SetBinding(DependencyObject target, DependencyProperty dependencyProperty, Binding binding)
        {
            BindingOperations.SetBinding(target, dependencyProperty, binding);
        }


        /// <summary> 
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="dependencyProperty"></param>
        /// <param name="value"> </param>
        public static void SetValue<T>(DependencyObject target, DependencyProperty dependencyProperty, T value)
        {
            target.SetValue(dependencyProperty, value);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="dependencyProperty"></param>
        /// <returns></returns>
        public static T GetValue<T>(DependencyObject target, DependencyProperty dependencyProperty)
        {
            T value = (T)target.GetValue(dependencyProperty);
            return value;
        }
    }
}
