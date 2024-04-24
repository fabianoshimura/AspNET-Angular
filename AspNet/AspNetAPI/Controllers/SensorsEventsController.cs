using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace AspNetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorEventsController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<SensorEventsController> _logger;

        public SensorEventsController(IHttpClientFactory httpClientFactory, ILogger<SensorEventsController> logger)
        {
            _httpClient = httpClientFactory.CreateClient();
            _logger = logger;
        }

        [HttpGet("fetchdata")]
        public async Task<IActionResult> FetchData()
        {
            string url = "https://phdsoft-gateway.azurewebsites.net/iot/api/SensorEvent/1055d71a82dd4e5396779e4690b0d71c";
            string bearerToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImZhYmlhbm8uc2hpbXVyYUBwaGRzb2Z0LmNvbSIsInVuaXF1ZV9uYW1lIjoiRmFiaWFubyBTaGltdXJhIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbW9iaWxlcGhvbmUiOiIrNTUxMTk4NjQ1MTUzOSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvdXNlcmRhdGEiOiJ7XCJpZFwiOlwiYWQ4MWM0ZWUtYTg2My00MTQ0LTg2MTktMjk5ZTYwYzRiODhmXCIsXCJDdXN0b21lcklkXCI6XCIzNzFjZDczYmU5ZDM0ZWQ0OTUzNWM2MGE4ZTE2NjM4NFwiLFwiRnVsbE5hbWVcIjpcIkZhYmlhbm8gU2hpbXVyYVwiLFwiRW1haWxcIjpcImZhYmlhbm8uc2hpbXVyYUBwaGRzb2Z0LmNvbVwiLFwiTG9naW5cIjpcImZhYmlhbm8uc2hpbXVyYUBwaGRzb2Z0LmNvbVwiLFwiUGFzc3dvcmRIYXNoXCI6XCJlMTJkZTU1MzVhNTk3YjhhMWNlMWMzYTYxZjgzOTcyNVwiLFwiRm9yY2VDaGFuZ2VQYXNzd29yZFwiOjAsXCJQYXNzd29yZFNldERhdGVcIjpcIjIwMjMtMDYtMjNUMjE6MzA6NTAuMTExWlwiLFwiUGFzc3dvcmRFeHBpcmF0aW9uRGF5c1wiOjk5OTksXCJQYXNzd29yZERheXNUb0V4cGlyZVwiOjk2OTQsXCJQaG9uZU51bWJlclwiOlwiKzU1MTE5ODY0NTE1MzlcIixcIlBob25lTnVtYmVyQ2hlY2tlZFwiOjAsXCJUd29TdGVwc0F1dGhcIjowLFwiUm9sZXNcIjpbXSxcIkdyb3VwUm9sZXNcIjpbXSxcIkFzc2V0SWRzXCI6W10sXCJQZXJtaXNzaW9uSWRzXCI6W1wiMWVmY2YwNmEtMjhhMy00ZDViLWJhYjAtMTMwYjBmNGVkMmNhXCIsXCJiYzQxNmZlNS02Yjk3LTRlOGYtOWEzOS05MDgwZjJlODRiMTBcIixcIjQwMzBmNTQ4LWNiY2MtNGNjZC05YzI1LWRiNjg1NWZlMDUwZFwiLFwiYzY0N2IyYzMtZTZiNC00MTliLTg3MGYtYzliYWViYmU4OTU2XCIsXCI5MzM5YjkxZC02NzIwLTRkOTctODIyMy1hMTkxNjcyZGM3Y2ZcIixcImY2NTcwNTJkLWYxOTQtNGNjYi1hZTA3LTI5OTk1ZTZhNmM5NFwiLFwiYTAyNWJkYWQtNzYwNC00YTA4LWIzOTMtZjhmMTVlNzA4MzExXCJdLFwiUHJlZmVyZW5jZXNcIjp7XCJEaXNjbGFpbWVyXCI6ZmFsc2UsXCJBY3RpdmVcIjpcInRydWVcIixcIkluaXRpYWxUb3VyXCI6XCJmYWxzZVwiLFwiVGhlbWVcIjpcImRlZmF1bHRcIixcIkxhbmd1YWdlXCI6XCJlbmdsaXNoXCJ9LFwiQ3JlYXRlZEF0XCI6XCIyMDIzLTA2LTIzVDIxOjIyOjU5LjkyNFpcIixcIkFjdGl2ZVwiOnRydWUsXCJEZWxldGVkXCI6ZmFsc2V9IiwibmJmIjoxNzEzOTg2MTM0LCJleHAiOjE3MTQwMTQ5MzQsImlhdCI6MTcxMzk4NjEzNH0.bHJcdQHM_BP4VmeGzzN9ENmO5VezNyg6GAaoEYxih9Y"; // Ensure this is correct

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);

                HttpResponseMessage response = await _httpClient.SendAsync(request);

                _logger.LogInformation("Status Code: {StatusCode}", response.StatusCode);
                response.EnsureSuccessStatusCode();

                // Here you can handle the response in a way that fits your needs
                string responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogInformation("Response: {Response}", responseContent);

                return Ok(responseContent); // Returns the raw response content
            }
            catch (HttpRequestException e)
            {
                _logger.LogError("Error fetching data: {Message}", e.Message);
                return BadRequest("Error fetching data: " + e.Message);
            }
        }
    }
}
