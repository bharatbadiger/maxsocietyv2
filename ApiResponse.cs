using System.Net;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Maxsociety
{
    // public interface IApiResponse
    // {
    //     [JsonIgnore]
    //     ModelStateDictionary ModelState {get;}
    //     void SetModelState(ModelStateDictionary modelState);
    // }
    // public class ApiResponse : IApiResponse 
    // {
    //     [JsonIgnore]
    //     public HttpStatusCode? StatusCode {get; set;}
    //     [JsonIgnore]
    //     public ModelStateDictionary ModelState {get; private set;} = new ModelStateDictionary();

    //     public void SetModelState(ModelStateDictionary modelState) => this.ModelState = modelState;

    //     public ValidationProblemDetails ProblemDetails => new ValidationProblemDetails(ModelState);
    // }

    // public class ApiResponse<TDataType> : ApiResponse, IApiResponse
    // {
    //     [JsonIgnore]
    //     public TDataType? Data {get; set;}
    // }

    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}