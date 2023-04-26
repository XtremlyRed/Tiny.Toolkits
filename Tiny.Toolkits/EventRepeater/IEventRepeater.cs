
using System;
using System.Threading.Tasks;

namespace Tiny.Toolkits
{
    /// <summary>
    ///  <see cref="IEventRepeater"/>  interface 
    /// </summary>
    public interface IEventRepeater
    {
        /// <summary>
        /// Unregister all message callback from subscriber
        /// </summary>
        /// <param name="subscriber"></param>
        void UnregisterAll(object subscriber);

        /// <summary>
        /// Unregister all message callback from subscriber by token
        /// </summary> 
        /// <param name="unregisterToken"></param>
        void Unregister(string unregisterToken);

        /// <summary>
        ///  execute a message callback  by token and other message parameters
        /// </summary>
        /// <param name="publishToken"></param>
        /// <param name="messengerParamters"></param>
        void Publish(string publishToken, params object[] messengerParamters);

        /// <summary>
        ///  async execute a message callback  by token and other message parameters
        /// </summary>
        /// <param name="publishToken"></param>
        /// <param name="messengerParamters"></param>
        /// <returns></returns>
        Task PublishAsync(string publishToken, params object[] messengerParamters);

        /// <summary>
        ///  execute a message callback  by token and other message parameters
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="publishToken"></param>
        /// <param name="messengerParamters"></param>
        /// <returns><typeparamref name="TResult"/></returns>
        TResult Publish<TResult>(string publishToken, params object[] messengerParamters);

        /// <summary>
        ///  async execute a message callback  by token and other message parameters
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="publishToken"></param>
        /// <param name="messengerParamters"></param>
        /// <returns><typeparamref name="TResult"/></returns>
        Task<TResult> PublishAsync<TResult>(string publishToken, params object[] messengerParamters);


        #region 0

        /// <summary>
        /// subscribe function
        /// </summary> 
        /// <typeparam name="TResult">return value type</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        void Subscribe<TResult>(object subscriber, string token, Func<TResult> subscribeDelegate);

        /// <summary>
        /// subscribe function
        /// </summary> 
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        void Subscribe(object subscriber, string token, Action subscribeDelegate);

        #endregion

        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        void Subscribe<TMessage1>(object subscriber, string token, Action<TMessage1> subscribeDelegate);

        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TResult">return value type</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        void Subscribe<TMessage1, TResult>(object subscriber, string token, Func<TMessage1, TResult> subscribeDelegate);
        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        void Subscribe<TMessage1, TMessage2>(object subscriber, string token, Action<TMessage1, TMessage2> subscribeDelegate);
        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TResult">return value type</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        void Subscribe<TMessage1, TMessage2, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TResult> subscribeDelegate);
        /// <summary>
        /// subscribe function
        /// </summary>
        /// <typeparam name="TMessage1">parameter 1</typeparam>
        /// <typeparam name="TMessage2">parameter 2</typeparam>
        /// <typeparam name="TMessage3">parameter 3</typeparam>
        /// <param name="subscriber">subscriber</param>
        /// <param name="token">subscribe token</param>
        /// <param name="subscribeDelegate">subscribe callback</param>
        void Subscribe<TMessage1, TMessage2, TMessage3>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TResult> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TResult> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TResult> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TResult> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TResult> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TResult> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TResult> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TResult> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TResult> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TResult> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TResult> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14, TResult> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14, TMessage15>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14, TMessage15> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14, TMessage15, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14, TMessage15, TResult> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14, TMessage15, TMessage16>(object subscriber, string token, Action<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14, TMessage15, TMessage16> subscribeDelegate);
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
        void Subscribe<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14, TMessage15, TMessage16, TResult>(object subscriber, string token, Func<TMessage1, TMessage2, TMessage3, TMessage4, TMessage5, TMessage6, TMessage7, TMessage8, TMessage9, TMessage10, TMessage11, TMessage12, TMessage13, TMessage14, TMessage15, TMessage16, TResult> subscribeDelegate);


    }
}
