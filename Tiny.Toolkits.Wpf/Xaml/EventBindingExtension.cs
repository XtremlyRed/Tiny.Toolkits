using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;



using BF = System.Reflection.BindingFlags;
 
namespace Tiny.Toolkits
{
    /// <summary>
    /// Used to bind this method to the xaml control
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class CommandBindingAttribute : Attribute
    {

    }
     
    /// <summary>
    /// {e:EventBinding Click}
    /// <para>The binding method must be marked with <see cref="CommandBindingAttribute"/></para>
    /// </summary>
    public partial class EventBindingExtension : MarkupExtension
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private readonly object[] @objects;



        /// <summary>
        /// ProvideValue
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (serviceProvider.GetService(typeof(IProvideValueTarget)) is not IProvideValueTarget targetProvider)
            {
                throw new InvalidOperationException();
            }
            if (targetProvider.TargetObject is not DependencyObject targetObject)
            {
                string msg = $"The bound element must be derived from the {typeof(DependencyObject).FullName}.";
                throw new ArgumentException(msg);
            }

            if (targetProvider.TargetProperty is not EventInfo eventInfo)
            {
                throw new InvalidOperationException();
            }
             
            Delegate @delegate = CreateDelegate(eventInfo, token: out string token);

            PropertyAttache.SetProperty0(targetObject, @objects);

            // EventBindingExtensionInvoker.tokenParameters.Add();

            return @delegate;
        }

        private Delegate CreateDelegate(EventInfo eventInfo, out string token)
        {
            token = string.Empty;

            Type eventHandlerType = eventInfo.EventHandlerType;

            MethodInfo methodInfo = eventHandlerType.GetMethod("Invoke");

            DynamicMethod method = new(token, methodInfo.ReturnType, methodInfo.GetParameters().Select(i => i.ParameterType).ToArray());

            ILGenerator gen = method.GetILGenerator();
            gen.Emit(OpCodes.Ldarg, 0);
            gen.Emit(OpCodes.Ldarg, 1);
            gen.Emit(OpCodes.Ldstr, token);

            methodInfo = typeof(EventBindingExtensionInvoker).GetMethod(nameof(EventBindingExtensionInvoker.MethodExecute), EventBindingExtensionInvoker.refParameterTypes);

            gen.Emit(OpCodes.Call, methodInfo);
            gen.Emit(OpCodes.Ret);

            return method.CreateDelegate(eventHandlerType);
        }





        private Delegate CreateEmptyDelegate(EventInfo eventInfo)
        {
            Type eventHandlerType = eventInfo.EventHandlerType;

            MethodInfo methodInfo = eventHandlerType.GetMethod("Invoke");

            DynamicMethod method = new("EmptyHandler", typeof(void), methodInfo.GetParameters().Select(i => i.ParameterType).ToArray());
            method.GetILGenerator().Emit(OpCodes.Ret);
            Delegate @delegate = method.CreateDelegate(eventHandlerType);

            return @delegate;
        }



        #region hide base function

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj"> The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        ///  Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return base.ToString();
        }


        #endregion



        #region  c

        /// <summary> 
        /// 0 parameters
        /// </summary>  
        public EventBindingExtension(string methodName)
        {
            @objects = new object[] { methodName };
        }
        /// <summary> 
        /// 1 parameters
        /// </summary>  
        public EventBindingExtension(string methodName, object param0)
        {
            @objects = new object[] { methodName, param0 };
        }
        /// <summary> 
        /// 2 parameters
        /// </summary>  
        public EventBindingExtension(string methodName, object param0, object param1)
        {
            @objects = new object[] { methodName, param0, param1 };
        }
        /// <summary> 
        /// 3 parameters
        /// </summary>  
        public EventBindingExtension(string methodName, object param0, object param1, object param2)
        {
            @objects = new object[] { methodName, param0, param1, param2 };
        }
        /// <summary> 
        /// 4 parameters
        /// </summary>  
        public EventBindingExtension(string methodName, object param0, object param1, object param2, object param3)
        {
            @objects = new object[] { methodName, param0, param1, param2, param3 };
        }
        /// <summary> 
        /// 5 parameters
        /// </summary>  
        public EventBindingExtension(string methodName, object param0, object param1, object param2, object param3, object param4)
        {
            @objects = new object[] { methodName, param0, param1, param2, param3, param4 };
        }
        /// <summary> 
        /// 6 parameters
        /// </summary>  
        public EventBindingExtension(string methodName, object param0, object param1, object param2, object param3, object param4, object param5)
        {
            @objects = new object[] { methodName, param0, param1, param2, param3, param4, param5 };
        }
        /// <summary> 
        /// 7 parameters
        /// </summary>  
        public EventBindingExtension(string methodName, object param0, object param1, object param2, object param3, object param4, object param5, object param6)
        {
            @objects = new object[] { methodName, param0, param1, param2, param3, param4, param5, param6 };
        }
        /// <summary> 
        /// 8 parameters
        /// </summary>  
        public EventBindingExtension(string methodName, object param0, object param1, object param2, object param3, object param4, object param5, object param6, object param7)
        {
            @objects = new object[] { methodName, param0, param1, param2, param3, param4, param5, param6, param7 };
        }
        /// <summary> 
        /// 9 parameters
        /// </summary>  
        public EventBindingExtension(string methodName, object param0, object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8)
        {
            @objects = new object[] { methodName, param0, param1, param2, param3, param4, param5, param6, param7, param8 };
        }
        /// <summary> 
        /// 10 parameters
        /// </summary>  
        public EventBindingExtension(string methodName, object param0, object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, object param9)
        {
            @objects = new object[] { methodName, param0, param1, param2, param3, param4, param5, param6, param7, param8, param9 };
        }
        /// <summary> 
        /// 11 parameters
        /// </summary>  
        public EventBindingExtension(string methodName, object param0, object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, object param9, object param10)
        {
            @objects = new object[] { methodName, param0, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10 };
        }
        /// <summary> 
        /// 12 parameters
        /// </summary>  
        public EventBindingExtension(string methodName, object param0, object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, object param9, object param10, object param11)
        {
            @objects = new object[] { methodName, param0, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11 };
        }
        /// <summary> 
        /// 13 parameters
        /// </summary>  
        public EventBindingExtension(string methodName, object param0, object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, object param9, object param10, object param11, object param12)
        {
            @objects = new object[] { methodName, param0, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12 };
        }
        /// <summary> 
        /// 14 parameters
        /// </summary>  
        public EventBindingExtension(string methodName, object param0, object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, object param9, object param10, object param11, object param12, object param13)
        {
            @objects = new object[] { methodName, param0, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13 };
        }
        /// <summary> 
        /// 15 parameters
        /// </summary>  
        public EventBindingExtension(string methodName, object param0, object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, object param9, object param10, object param11, object param12, object param13, object param14)
        {
            @objects = new object[] { methodName, param0, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14 };
        }
        /// <summary> 
        /// 16 parameters
        /// </summary>  
        public EventBindingExtension(string methodName, object param0, object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, object param9, object param10, object param11, object param12, object param13, object param14, object param15)
        {
            @objects = new object[] { methodName, param0, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15 };
        }
        /// <summary> 
        /// 17 parameters
        /// </summary>  
        public EventBindingExtension(string methodName, object param0, object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, object param9, object param10, object param11, object param12, object param13, object param14, object param15, object param16)
        {
            @objects = new object[] { methodName, param0, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15, param16 };
        }
        /// <summary> 
        /// 18 parameters
        /// </summary>  
        public EventBindingExtension(string methodName, object param0, object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, object param9, object param10, object param11, object param12, object param13, object param14, object param15, object param16, object param17)
        {
            @objects = new object[] { methodName, param0, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15, param16, param17 };
        }


        #endregion


    }


    /// <summary>
    /// Invoker
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class EventBindingExtensionInvoker
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal static readonly Type[] refParameterTypes = new[] { typeof(object), typeof(object), typeof(string) };

        //[EditorBrowsable(EditorBrowsableState.Never)]
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //internal static readonly IList<BindingMapper> tokenParameters = new List<BindingMapper>();


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
            if (sender is not DependencyObject dependencyObject)
            {
                return;
            }

            object[] @objects = PropertyAttache.GetProperty0(dependencyObject) as object[];

            @objects.ForEach((item, index) =>
            {
                if (item is Binding binding)
                {
                    PropertyAttache.SetBinding(dependencyObject, binding, index);
                    @objects[index] = PropertyAttache.GetValue(dependencyObject, index);
                }
            });

            if (dependencyObject is not FrameworkElement frameworkElement)
            {
                frameworkElement = WpfAssist.FindParent<FrameworkElement>(dependencyObject);
            }

            if (frameworkElement.DataContext is null)
            {
                return;
            }

            object[] arguments = ArgumentsParse(@objects.Skip(1).ToArray(), sender, args);

            Tuple<MethodInfo, bool> tuple = GetMethod(frameworkElement.DataContext, @objects[0] as string, arguments);

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
                    .Where(i => i.GetAttribute<CommandBindingAttribute>() != null)
                    .Select(i => new MethodMapper { Method = i, ParameterTypes = i.GetParameters().Select(i => i.ParameterType).ToArray() })
                    .ToArray();
            }

            Type[] argumentTypes = arguments.Select(i => i.GetType()).ToArray();

            MethodInfo methodInfo = methods
                .Where(i => i.Method.Name == methodName && i.ParameterTypes.Length == argumentTypes.Length)
                .FirstOrDefault(i => argumentTypes.Zip(i.ParameterTypes, (i1, i2) => i2.IsAssignableFrom(i1)).Aggregate(true, (s, e) => s && e))
                ?.Method;

            if (methodInfo != null)
            {
                return Tuple.Create(methodInfo, true);
            }

            methodInfo = methods
              .Where(i => i.Method.Name == methodName)
              .FirstOrDefault(i => i.ParameterTypes.Length == 1 && i.ParameterTypes[0] == typeof(object[]))?.Method;

            return methodInfo != null
                ? Tuple.Create(methodInfo, false)
                : throw new Exception($"Method with {methodName} ss not matched or method not annotated with {typeof(CommandBindingAttribute)}");
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

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class MethodMapper
    {
        public MethodInfo Method { get; set; }

        public Type[] ParameterTypes { get; set; }
    }

}
