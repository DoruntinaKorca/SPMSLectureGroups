using Application.DTOs.LectureGroupDtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.SyncDataServices.Http
{
    public class HttpUsersDataClient : IUsersDataClient
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _config;

        public HttpUsersDataClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task SendLectureGroupToUsers(RequestLectureGroupDto lectureGroup)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(lectureGroup),
                Encoding.UTF8,
                "application/json"
                );

            var response = await _httpClient.PostAsync($"{_config["SPMSUsers"]}",httpContent);


            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("-----> sync POST to USERS SERVICE was OK!!");
            }
            else
            {
                Console.WriteLine("----> sync POST to USERS SERVICE was not OK!!");
            }

        }
    }

}