using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using System.Net;
namespace MarketPlace.Services
{
    public interface IRequest
    {
        Task<string> PostWebForm(string adress, Dictionary<string, string> form);
        Task<T> GetRequest<T>(string endpoint, bool token);
        Task GetRequest<T>(string endpoint, bool token, Action<HttpStatusCode, T> _callback);
        Task<T> PostRequest<T, D>(string endpoint, D postData, bool token);
        Task<string> PostRequest<T>(string endpoint, T postData, bool token);
        Task<string> GetResponse(string endpoint, bool token);
        string Token { get; set; }
        string Endpoint { get; set; }

        Task<string> UploadFile(string endpoint, byte[] file);
    }
}
