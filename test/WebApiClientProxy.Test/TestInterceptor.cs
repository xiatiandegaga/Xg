using Castle.Core.Internal;
using Castle.DynamicProxy;
using Cloud.Utilities.Json;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApiClientProxy.Test
{
    public class TestInterceptor : IInterceptor
    {
        protected static MethodInfo MakeRequestAndGetResultAsyncMethod { get; }
        private readonly IHttpClientFactory _httpClientFactory;
        public TestInterceptor(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        static TestInterceptor()
        {
            MakeRequestAndGetResultAsyncMethod = typeof(TestInterceptor)
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(m => m.Name == nameof(MakeRequestAndGetResultAsync) && m.IsGenericMethodDefinition);
        }

        private async Task<HttpContent>  MakeRequestAsync(IInvocation invocation)
        {
            var client = _httpClientFactory.CreateClient();
            //var requestMessage = new HttpRequestMessage(action.GetHttpMethod(), url)
            //{
            //    Content = RequestPayloadBuilder.BuildContent(action, invocation.ArgumentsDictionary, JsonSerializer, apiVersion)
            //};

            //var response = await client.SendAsync(
            //    requestMessage,
            //    HttpCompletionOption.ResponseHeadersRead /*this will buffer only the headers, the content will be used as a stream*/,
            //    GetCancellationToken()
            //);
            //var requestMessage = new HttpRequestMessage(action.GetHttpMethod(), url)
            //{
            //    Content = RequestPayloadBuilder.BuildContent(action, invocation.ArgumentsDictionary, JsonSerializer, apiVersion)
            //};
            return (await client.GetAsync("http://localhost:5000/api/WeatherForecast/"+ invocation.Method.Name+"?"+ JsonUtility.Serialize(invocation.Arguments))).Content;
        }


        private async Task<T> MakeRequestAndGetResultAsync<T>(IInvocation invocation)
        {
            try
            {
                var responseContent = await MakeRequestAsync(invocation);

            var stringContent = await responseContent.ReadAsStringAsync();
            if (typeof(T) == typeof(string))
            {
                return (T)(object)stringContent;
            }

            if (stringContent.IsNullOrEmpty())
            {
                return default;
            }
          
                return JsonSerializer.Deserialize<T>(stringContent);
            }
            catch(Exception ex) 
            {
                var wq = ex;
                return default(T);
            }
        }

        private async Task<object> GetResultAsync(Task task, Type resultType)
        {
            await task;
            return typeof(Task<>)
                .MakeGenericType(resultType)
                .GetProperty(nameof(Task<object>.Result), BindingFlags.Instance | BindingFlags.Public)
                .GetValue(task);
        }

        public void Intercept(IInvocation invocation)
        {
            
            Console.WriteLine("Before AnimalInterceptor.Intercept");
            var client = _httpClientFactory.CreateClient();
            var returnType = invocation.Method.ReturnType;
            if (invocation.Method.ReturnType.GenericTypeArguments.IsNullOrEmpty())
            {
                var result = (Task)MakeRequestAndGetResultAsyncMethod
                       .Invoke(this, new object[] { invocation });

                invocation.ReturnValue = result;
            }
            else
            {
                var result = (Task)MakeRequestAndGetResultAsyncMethod
                        .MakeGenericMethod(invocation.Method.ReturnType)
                        .Invoke(this, new object[] { invocation });

                invocation.ReturnValue = GetResultAsync(
                       result,
                       invocation.Method.ReturnType
                   ).Result;
            }
            //if (invocation.Method.ReturnType.GenericTypeArguments.IsNullOrEmpty())
            //{
            //     ret = client.GetStringAsync("http://localhost:5000/api/WeatherForecast/get").Result;
            //}
            //else
            //{
            //    MakeRequestAndGetResultAsync
            //}
            //if (invocation.InvocationTarget != null)
            //{
            //    invocation.Proceed();
            //}
            Console.WriteLine("After AnimalInterceptor.Intercept");
        }
    }
}
