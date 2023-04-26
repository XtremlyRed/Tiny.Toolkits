using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Media;

using BF = System.Reflection.BindingFlags;

namespace Tiny.Toolkits.Wpf.Extension
{
    /// <summary>
    /// Invoker
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class EventBindingExtensionInvoker
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal static readonly Type[] refParameterTypes = new[] { typeof(object), typeof(object), typeof(string) };

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal static readonly IList<BindingMapper> tokenParameters = new List<BindingMapper>();


        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static readonly BrushConverter brushConverter = new();

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal static readonly IDictionary<string, Tuple<MethodInfo, bool>> tokenMethods = new Dictionary<string, Tuple<MethodInfo, bool>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal static readonly IDictionary<Type, MethodMapper[]> typeMethods = new Dictionary<Type, MethodMapper[]>();



        /// <summary>
        /// method invoker   
        /// <para>for internal use within the framework</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <param name="token"></param>
        public static void MethodExecute(object sender, object args, string token)
        {
            if (tokenParameters.FirstOrDefault(i => i.Token == token) is not BindingMapper bindingMapper)
            {
                return;
            }

            if (bindingMapper.TargetObject is not FrameworkElement frameworkElement)
            {
                frameworkElement = WpfAssist.FindParent<FrameworkElement>(bindingMapper.TargetObject);
            }

            if (frameworkElement.DataContext is null)
            {
                return;
            }

            object[] arguments = ArgumentsParse(bindingMapper.Arguments.Skip(1).ToArray(), sender, args);

            Tuple<MethodInfo, bool> tuple = GetMethod(frameworkElement.DataContext, bindingMapper.Arguments[0] as string, arguments);

            tuple.Item1?.Invoke(frameworkElement.DataContext, tuple.Item2 ? arguments : new object[] { arguments });


        }



        private static Tuple<MethodInfo, bool> GetMethod(object dataContext, string methodName, object[] arguments)
        {
            Type dataContextType = dataContext.GetType();
            if (typeMethods.TryGetValue(dataContextType, out MethodMapper[] methods) == false)
            {
                typeMethods[dataContextType] = methods = dataContext
                    .GetType()
                    .GetMethods(BF.Instance | BF.Public | BF.NonPublic)
                    .Where(i => i.Name == methodName)
                    .Select(i => new MethodMapper { Method = i, ParameterTypes = i.GetParameters().Select(i => i.ParameterType).ToArray() })
                    .ToArray();
            }



            Type[] argumentTypes = arguments.Select(i => i.GetType()).ToArray();

            MethodInfo methodInfo = methods
                .Where(i => i.Method.Name == methodName)
                .FirstOrDefault(i => Enumerable.SequenceEqual(argumentTypes, i.ParameterTypes))?.Method;

            if (methodInfo is null)
            {
                methodInfo = methods
                  .Where(i => i.Method.Name == methodName)
                  .FirstOrDefault(i => i.ParameterTypes.Length == 1 && i.ParameterTypes[0] == typeof(object[]))?.Method;

                return Tuple.Create(methodInfo, false);
            }

            return Tuple.Create(methodInfo, true);
        }

        private static object[] ArgumentsParse(object[] arguments, object sender, object args)
        {
            for (int i = 0; i < arguments.Length; i++)
            {
                try
                {
                    object current = arguments[i];
                    if (current is string stringValue)
                    {
                        if (stringValue == "$self")
                        {
                            arguments[i] = sender;
                            continue;
                        }

                        if (stringValue == "$eventArgs")
                        {
                            arguments[i] = args;
                            continue;
                        }

                        if (stringValue.StartsWith("#"))
                        {
                            if (stringValue.Contains(":"))
                            {
                                string[] pix = stringValue.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                                if (pix[1].StartsWith("b", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    arguments[i] = (Brush)brushConverter.ConvertFromString(pix[0]);
                                    continue;
                                }
                                if (pix[1].StartsWith("c", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    arguments[i] = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(stringValue);
                                    continue;
                                }
                            }
                            arguments[i] = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(stringValue);
                            continue;
                        }
                    }
                }
                catch (Exception)
                {
                }
            }

            return arguments;

        }
    }


    internal class MethodMapper
    {
        public MethodInfo Method { get; set; }
        public Type[] ParameterTypes { get; set; }
    }

    internal class BindingMapper
    {
        public DependencyObject TargetObject { get; set; }

        public string Token { get; set; }

        public object[] Arguments { get; set; }
    }
}
