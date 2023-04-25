using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
namespace Tiny.Toolkits
{
    /// <summary>
    /// result type
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public readonly ref struct Result<TResult>
    {

        /// <summary>
        /// result exception
        /// </summary>
        public readonly Exception Exception;
        /// <summary>
        /// result value
        /// </summary>
        public readonly TResult Value;

        /// <summary>
        /// result state
        /// </summary>
        public readonly bool IsValid = true;

        /// <summary>
        /// create a success <see cref="Result{TResult}"/> by <typeparamref name="TResult"/> value
        /// </summary>
        /// <param name="value"></param>
        public Result(TResult value)
        {
            IsValid = true;
            Value = value;
            Exception = null;
        }


        /// <summary>
        /// create a <see cref="Result{TResult}"/> by <typeparamref name="TResult"/> value and <paramref name="isValid"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isValid"></param>
        public Result(TResult value, bool isValid)
        {
            IsValid = isValid;
            Value = value;
            Exception = null;
        }

        /// <summary>
        /// createa faulted <see cref="Result{TResult}"/> by exception
        /// </summary>
        /// <param name="e"></param>
        public Result(Exception e)
        {
            IsValid = false;
            Exception = e;
            Value = default!;
        }

        /// <summary>
        /// create a success <see cref="Result{TResult}"/> by <typeparamref name="TResult"/> value
        /// </summary>
        /// <param name="value">result value</param>
        public static implicit operator Result<TResult>(TResult value)
        {
            return value is Exception ? throw new InvalidOperationException() : new Result<TResult>(value);
        }

        /// <summary>
        /// <see cref="object.ToString"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return IsValid == false ? Exception?.ToString() ?? "faulted result" : IsValid == true ? Value?.ToString() ?? "success result" : "";
        }


        /// <summary>
        /// check result 
        /// <para><see cref="IsValid"/>: <c>true</c> and return <see cref="Value"/></para>
        /// <para><see cref="IsValid"/>: <c>false</c> and return <paramref name="defaultValue"/></para>
        /// </summary>
        /// <param name="defaultValue">default value</param>
        /// <returns></returns>
        public TResult IfFaulted(TResult defaultValue)
        {
            return IsValid == true ? Value : defaultValue;
        }

        /// <summary>
        /// check result 
        /// <para><see cref="IsValid"/>: <c>true</c> and return <see cref="Value"/></para>
        /// <para><see cref="IsValid"/>: <c>false</c> and invoke <paramref name="invokerFunc"/> callback</para>
        /// </summary>
        /// <param name="invokerFunc">faulted callback</param>
        /// <returns></returns>
        public TResult IfFaulted(Func<Exception, TResult> invokerFunc)
        {
            return IsValid == true ? Value : invokerFunc(Exception!);
        }

        /// <summary>
        /// check result  
        /// <para><see cref="IsValid"/>: <c>true</c> and invoke <paramref name="invokeAction"/> callback</para>
        /// </summary>
        /// <param name="invokeAction">faulted callback</param>
        /// <returns></returns>
        public void IfFaulted(Action<Exception> invokeAction)
        {
            if (IsValid == false)
            {
                invokeAction(Exception!);
            }
        }

        /// <summary>
        /// check result 
        /// <para><see cref="IsValid"/>: <c>true</c> and invoke <paramref name="invokeAction"/> callback</para>
        /// </summary>
        /// <param name="invokeAction">success callback</param>
        /// <returns></returns>
        public void IfSuccess(Action<TResult> invokeAction)
        {
            if (IsValid == true)
            {
                invokeAction(Value);
            }
        }

        /// <summary>
        /// check result 
        /// <para><see cref="IsValid"/>: <c>true</c> and invoke <paramref name="invokeSuccessAction"/> callback</para>
        /// <para><see cref="IsValid"/>: <c>false</c> and invoke <paramref name="invokeFaultedAction"/> callback</para>
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="invokeSuccessAction"></param>
        /// <param name="invokeFaultedAction"></param>
        /// <returns></returns>
        public TReturn Match<TReturn>(Func<TResult, TReturn> invokeSuccessAction, Func<Exception, TReturn> invokeFaultedAction)
        {
            return IsValid ? invokeSuccessAction(Value) : invokeFaultedAction(Exception!);
        }


    }
}