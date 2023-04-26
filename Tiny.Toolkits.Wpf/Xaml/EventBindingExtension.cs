using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

using Tiny.Toolkits.Wpf.Extension;

namespace Tiny.Toolkits
{
    /// <summary>
    /// {e:EventBinding Click}
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

            @objects.ForEach((item, index) =>
            {
                if (item is Binding binding)
                {
                    PropertyAttache.SetBinding(targetObject, binding, index);
                    @objects[index] = PropertyAttache.GetValue(targetObject, index);
                }
            });

            Delegate @delegate = CreateDelegate(eventInfo, token: out string token);

            EventBindingExtensionInvoker.tokenParameters.Add(new BindingMapper()
            {
                Token = token,
                Arguments = @objects,
                TargetObject = targetObject,
            });

            return @delegate;
        }

        private Delegate CreateDelegate(EventInfo eventInfo, out string token)
        {
            token = $"Token_{Guid.NewGuid()}".Replace("-", "");

            Type eventHandlerType = eventInfo.EventHandlerType;

            MethodInfo methodInfo = eventHandlerType.GetMethod("Invoke");

            DynamicMethod method = new(token, methodInfo.ReturnType, methodInfo.GetParameters().Select(i => i.ParameterType).ToArray());

            ILGenerator gen = method.GetILGenerator();
            gen.Emit(OpCodes.Ldarg, 0);
            gen.Emit(OpCodes.Ldarg, 1);
            gen.Emit(OpCodes.Ldstr, token);

            methodInfo = typeof(EventBindingExtensionInvoker).GetMethod("MethodExecute", EventBindingExtensionInvoker.refParameterTypes);

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


    }
}
