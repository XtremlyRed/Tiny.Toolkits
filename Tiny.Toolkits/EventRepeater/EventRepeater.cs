using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Tiny.Toolkits
{
    /// <summary>
    /// Messenger
    /// </summary>
    public class EventRepeater : IEventRepeater
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly ConcurrentDictionary<string, InvokeInfo> mappers = new();

        /// <summary>
        /// tokens
        /// </summary>
        public IReadOnlyList<string> Tokens => mappers.Keys.ToArray();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        public virtual void Unregister(string token)
        {
            mappers.TryRemove(token, out InvokeInfo mapper);
            mapper?.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriber"></param>
        /// <Exception cref="ArgumentNullException"></Exception>
        public virtual void UnregisterAll(object subscriber)
        {
            if (subscriber == null)
            {
                throw new ArgumentNullException(nameof(subscriber));
            }

            KeyValuePair<string, InvokeInfo>[] exists = mappers.Where(i => i.Value.Subscriber == subscriber).ToArray();
            foreach (KeyValuePair<string, InvokeInfo> item in exists)
            {
                mappers.TryRemove(item.Key, out InvokeInfo mapper);
                mapper?.Dispose();
            }
        }

        /// <summary>
        /// Publish
        /// </summary>
        /// <param name="publishToken"></param>
        /// <param name="messengerParamters"></param>
        /// <Exception cref="ArgumentNullException"></Exception>
        /// <Exception cref="ArgumentException"></Exception>
        public virtual void Publish(string publishToken, params object[] messengerParamters)
        {
            _ = publishToken ?? throw new ArgumentNullException(nameof(publishToken));

            if (mappers.TryGetValue(publishToken, out InvokeInfo mapper))
            {
                if (string.Compare(mapper.ReturnType.Name, "void", StringComparison.OrdinalIgnoreCase) != 0)
                {
                    throw new ArgumentException("return type error or type Exception");
                }

                mapper.Invoke(messengerParamters ?? new object[] { null! });

                return;
            }

            throw new ArgumentException($"{nameof(publishToken)} does not exist");
        }

        /// <summary>
        ///  Publish
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="publishToken"></param>
        /// <param name="messengerParamters"></param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        /// <Exception cref="ArgumentException"></Exception>
        public virtual TResult Publish<TResult>(string publishToken, params object[] messengerParamters)
        {
            _ = publishToken ?? throw new ArgumentNullException(nameof(publishToken));

            if (mappers.TryGetValue(publishToken, out InvokeInfo mapper))
            {
                if (Equals(mapper.ReturnType, typeof(TResult)) == false)
                {
                    throw new ArgumentException("return type error or type Exception");
                }

                object invokerValue = mapper.Invoke(messengerParamters ?? new object[] { null! });

                return invokerValue is TResult returnValue ? returnValue : default!;
            }

            throw new ArgumentException("publishToken does not exist");

        }

        /// <summary>
        ///  PublishAsync
        /// </summary>
        /// <param name="publishToken"></param> 
        /// <param name="messageParams"></param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public virtual Task PublishAsync(string publishToken, params object[] messageParams)
        {
            _ = publishToken ?? throw new ArgumentNullException(nameof(publishToken));

            return Task.Factory.StartNew(() => Publish(publishToken, messageParams), CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
        }

        /// <summary>
        ///  PublishAsync
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="publishToken"></param> 
        /// <param name="messageParams"></param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public virtual Task<TResult> PublishAsync<TResult>(string publishToken, params object[] messageParams)
        {
            _ = publishToken ?? throw new ArgumentNullException(nameof(publishToken));

            return Task.Factory.StartNew(() => Publish<TResult>(publishToken, messageParams), CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
        }

        /// <summary>
        /// subscribe function
        /// </summary> 
        /// <typeparam name="TResult">return value type</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TResult>(object subscriber, string token, Func<TResult> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }

        /// <summary>
        /// subscribe function
        /// </summary> 
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe(object subscriber, string token, Action subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        #region 1
        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1>(object subscriber, string token, Action<TMessage1> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TResult">return value type</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TResult>(object subscriber, string token, Func<TMessage1, TResult> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        #endregion
        #region 2
        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2>(object subscriber, string token, Action<TMessage1, TMessage2> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TResult">return value type</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TResult> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        #endregion
        #region 3
        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TResult">return value type</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TResult> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        #endregion
        #region 4
        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TResult">return value type</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TResult> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        #endregion
        #region 5
        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <typeparam name="TResult">return value type</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TResult> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        #endregion
        #region 6
        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <typeparam name="TMessage6">parameter 6</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <typeparam name="TMessage6">parameter 6</typeparam>
        /// <typeparam name="TResult">return value type</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TResult> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        #endregion
        #region 7
        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <typeparam name="TMessage6">parameter 6</typeparam>
        /// <typeparam name="TMessage7">parameter 7</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <typeparam name="TMessage6">parameter 6</typeparam>
        /// <typeparam name="TMessage7">parameter 7</typeparam>
        /// <typeparam name="TResult">return value type</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TResult> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        #endregion
        #region 8
        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <typeparam name="TMessage6">parameter 6</typeparam>
        /// <typeparam name="TMessage7">parameter 7</typeparam>
        /// <typeparam name="TMessage8">parameter 8</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <typeparam name="TMessage6">parameter 6</typeparam>
        /// <typeparam name="TMessage7">parameter 7</typeparam>
        /// <typeparam name="TMessage8">parameter 8</typeparam>
        /// <typeparam name="TResult">return value type</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TResult> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        #endregion
        #region 9
        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <typeparam name="TMessage6">parameter 6</typeparam>
        /// <typeparam name="TMessage7">parameter 7</typeparam>
        /// <typeparam name="TMessage8">parameter 8</typeparam>
        /// <typeparam name="TMessage9">parameter 9</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <typeparam name="TMessage6">parameter 6</typeparam>
        /// <typeparam name="TMessage7">parameter 7</typeparam>
        /// <typeparam name="TMessage8">parameter 8</typeparam>
        /// <typeparam name="TMessage9">parameter 9</typeparam>
        /// <typeparam name="TResult">return value type</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TResult> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        #endregion
        #region 10
        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <typeparam name="TMessage6">parameter 6</typeparam>
        /// <typeparam name="TMessage7">parameter 7</typeparam>
        /// <typeparam name="TMessage8">parameter 8</typeparam>
        /// <typeparam name="TMessage9">parameter 9</typeparam>
        /// <typeparam name="TMessage10">parameter 10</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <typeparam name="TMessage6">parameter 6</typeparam>
        /// <typeparam name="TMessage7">parameter 7</typeparam>
        /// <typeparam name="TMessage8">parameter 8</typeparam>
        /// <typeparam name="TMessage9">parameter 9</typeparam>
        /// <typeparam name="TMessage10">parameter 10</typeparam>
        /// <typeparam name="TResult">return value type</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TResult> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        #endregion
        #region 11
        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <typeparam name="TMessage6">parameter 6</typeparam>
        /// <typeparam name="TMessage7">parameter 7</typeparam>
        /// <typeparam name="TMessage8">parameter 8</typeparam>
        /// <typeparam name="TMessage9">parameter 9</typeparam>
        /// <typeparam name="TMessage10">parameter 10</typeparam>
        /// <typeparam name="TMessage11">parameter 11</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <typeparam name="TMessage6">parameter 6</typeparam>
        /// <typeparam name="TMessage7">parameter 7</typeparam>
        /// <typeparam name="TMessage8">parameter 8</typeparam>
        /// <typeparam name="TMessage9">parameter 9</typeparam>
        /// <typeparam name="TMessage10">parameter 10</typeparam>
        /// <typeparam name="TMessage11">parameter 11</typeparam>
        /// <typeparam name="TResult">return value type</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TResult> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        #endregion
        #region 12
        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <typeparam name="TMessage6">parameter 6</typeparam>
        /// <typeparam name="TMessage7">parameter 7</typeparam>
        /// <typeparam name="TMessage8">parameter 8</typeparam>
        /// <typeparam name="TMessage9">parameter 9</typeparam>
        /// <typeparam name="TMessage10">parameter 10</typeparam>
        /// <typeparam name="TMessage11">parameter 11</typeparam>
        /// <typeparam name="TMessage12">parameter 12</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <typeparam name="TMessage6">parameter 6</typeparam>
        /// <typeparam name="TMessage7">parameter 7</typeparam>
        /// <typeparam name="TMessage8">parameter 8</typeparam>
        /// <typeparam name="TMessage9">parameter 9</typeparam>
        /// <typeparam name="TMessage10">parameter 10</typeparam>
        /// <typeparam name="TMessage11">parameter 11</typeparam>
        /// <typeparam name="TMessage12">parameter 12</typeparam>
        /// <typeparam name="TResult">return value type</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TResult> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        #endregion
        #region 13
        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <typeparam name="TMessage6">parameter 6</typeparam>
        /// <typeparam name="TMessage7">parameter 7</typeparam>
        /// <typeparam name="TMessage8">parameter 8</typeparam>
        /// <typeparam name="TMessage9">parameter 9</typeparam>
        /// <typeparam name="TMessage10">parameter 10</typeparam>
        /// <typeparam name="TMessage11">parameter 11</typeparam>
        /// <typeparam name="TMessage12">parameter 12</typeparam>
        /// <typeparam name="TMessage13">parameter 13</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <typeparam name="TMessage6">parameter 6</typeparam>
        /// <typeparam name="TMessage7">parameter 7</typeparam>
        /// <typeparam name="TMessage8">parameter 8</typeparam>
        /// <typeparam name="TMessage9">parameter 9</typeparam>
        /// <typeparam name="TMessage10">parameter 10</typeparam>
        /// <typeparam name="TMessage11">parameter 11</typeparam>
        /// <typeparam name="TMessage12">parameter 12</typeparam>
        /// <typeparam name="TMessage13">parameter 13</typeparam>
        /// <typeparam name="TResult">return value type</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TResult> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        #endregion
        #region 14
        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <typeparam name="TMessage6">parameter 6</typeparam>
        /// <typeparam name="TMessage7">parameter 7</typeparam>
        /// <typeparam name="TMessage8">parameter 8</typeparam>
        /// <typeparam name="TMessage9">parameter 9</typeparam>
        /// <typeparam name="TMessage10">parameter 10</typeparam>
        /// <typeparam name="TMessage11">parameter 11</typeparam>
        /// <typeparam name="TMessage12">parameter 12</typeparam>
        /// <typeparam name="TMessage13">parameter 13</typeparam>
        /// <typeparam name="TMessage14">parameter 14</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <typeparam name="TMessage6">parameter 6</typeparam>
        /// <typeparam name="TMessage7">parameter 7</typeparam>
        /// <typeparam name="TMessage8">parameter 8</typeparam>
        /// <typeparam name="TMessage9">parameter 9</typeparam>
        /// <typeparam name="TMessage10">parameter 10</typeparam>
        /// <typeparam name="TMessage11">parameter 11</typeparam>
        /// <typeparam name="TMessage12">parameter 12</typeparam>
        /// <typeparam name="TMessage13">parameter 13</typeparam>
        /// <typeparam name="TMessage14">parameter 14</typeparam>
        /// <typeparam name="TResult">return value type</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14, TResult> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        #endregion
        #region 15
        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <typeparam name="TMessage6">parameter 6</typeparam>
        /// <typeparam name="TMessage7">parameter 7</typeparam>
        /// <typeparam name="TMessage8">parameter 8</typeparam>
        /// <typeparam name="TMessage9">parameter 9</typeparam>
        /// <typeparam name="TMessage10">parameter 10</typeparam>
        /// <typeparam name="TMessage11">parameter 11</typeparam>
        /// <typeparam name="TMessage12">parameter 12</typeparam>
        /// <typeparam name="TMessage13">parameter 13</typeparam>
        /// <typeparam name="TMessage14">parameter 14</typeparam>
        /// <typeparam name="TMessage15">parameter 15</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14, TMessage15>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14, TMessage15> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <typeparam name="TMessage6">parameter 6</typeparam>
        /// <typeparam name="TMessage7">parameter 7</typeparam>
        /// <typeparam name="TMessage8">parameter 8</typeparam>
        /// <typeparam name="TMessage9">parameter 9</typeparam>
        /// <typeparam name="TMessage10">parameter 10</typeparam>
        /// <typeparam name="TMessage11">parameter 11</typeparam>
        /// <typeparam name="TMessage12">parameter 12</typeparam>
        /// <typeparam name="TMessage13">parameter 13</typeparam>
        /// <typeparam name="TMessage14">parameter 14</typeparam>
        /// <typeparam name="TMessage15">parameter 15</typeparam>
        /// <typeparam name="TResult">return value type</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14, TMessage15, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14, TMessage15, TResult> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        #endregion
        #region 16
        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <typeparam name="TMessage6">parameter 6</typeparam>
        /// <typeparam name="TMessage7">parameter 7</typeparam>
        /// <typeparam name="TMessage8">parameter 8</typeparam>
        /// <typeparam name="TMessage9">parameter 9</typeparam>
        /// <typeparam name="TMessage10">parameter 10</typeparam>
        /// <typeparam name="TMessage11">parameter 11</typeparam>
        /// <typeparam name="TMessage12">parameter 12</typeparam>
        /// <typeparam name="TMessage13">parameter 13</typeparam>
        /// <typeparam name="TMessage14">parameter 14</typeparam>
        /// <typeparam name="TMessage15">parameter 15</typeparam>
        /// <typeparam name="TMessage16">parameter 16</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14, TMessage15, TMessage16>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14, TMessage15, TMessage16> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <typeparam name="TMessage4">parameter 4</typeparam>
        /// <typeparam name="TMessage5">parameter 5</typeparam>
        /// <typeparam name="TMessage6">parameter 6</typeparam>
        /// <typeparam name="TMessage7">parameter 7</typeparam>
        /// <typeparam name="TMessage8">parameter 8</typeparam>
        /// <typeparam name="TMessage9">parameter 9</typeparam>
        /// <typeparam name="TMessage10">parameter 10</typeparam>
        /// <typeparam name="TMessage11">parameter 11</typeparam>
        /// <typeparam name="TMessage12">parameter 12</typeparam>
        /// <typeparam name="TMessage13">parameter 13</typeparam>
        /// <typeparam name="TMessage14">parameter 14</typeparam>
        /// <typeparam name="TMessage15">parameter 15</typeparam>
        /// <typeparam name="TMessage16">parameter 16</typeparam>
        /// <typeparam name="TResult">return value type</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        public virtual void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14, TMessage15, TMessage16, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14, TMessage15, TMessage16, TResult> subscribeDelegate)
        {
            _ = token ?? throw new ArgumentNullException(nameof(token));
            _ = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
            MethodInfo method = subscribeDelegate?.Method ?? throw new ArgumentNullException(nameof(subscribeDelegate));
            if (mappers.TryGetValue(token, out InvokeInfo mapper) == false)
            {
                mappers[token] = mapper = new InvokeInfo();
            }
            mapper.Update(subscriber, token, method, subscribeDelegate);
        }


        #endregion




        private class InvokeInfo : IDisposable
        {
            private object Handler;
            private MethodInfo Method;
            public SynchronizationContext synchronizationContext;
            public void Update(object subscriber, string token, MethodInfo method, object handler)
            {
                synchronizationContext = SynchronizationContext.Current;

                Token = token;
                Subscriber = subscriber;
                Arguments = method.GetParameters().Select(i => i.ParameterType).ToArray();
                ReturnType = method.ReturnType;
                Handler = handler;
                Method = Handler.GetType().GetMethod(nameof(MethodInfo.Invoke));
            }

            public string Token { get; private set; }

            public object Subscriber { get; private set; }

            public Type[] Arguments { get; private set; }

            public Type ReturnType { get; private set; }

            public void Dispose()
            {
                Subscriber = null;
                Token = null;
                Arguments = null;
                ReturnType = null;
                Method = null;
                Handler = null;
            }

            public object Invoke(params object[] messageParams)
            {
                object invokerValue = Method?.Invoke(Handler, messageParams);
                return invokerValue;
            }
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
