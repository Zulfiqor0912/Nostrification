using Microsoft.Extensions.Options;
using Nostrification.Domain.Entities.MyGov;
using Nostrification.Domain.Repositories;
using System.Text;

namespace Nostrification.Infrastructure.Repositories;

public class MyGovRepository(IOptions<MyGovSettings> options) : IMyGovRepository
{
    private readonly MyGovSettings _settings = options.Value;
    public async Task<bool> SendStatusGetAsync(int taskId, string version = "v2")
    {
        var secondUrl = version == "v3" ? _settings.ThirdUrl : _settings.SecondUrl;
        var url = $"{_settings.BaseUri}/{secondUrl}/rest-api/update/id/{taskId}/action/acceptance";

        var credentials = Convert.ToBase64String(
            Encoding.GetEncoding("ISO-8859-1").GetBytes(_settings.UserName + ":" + _settings.Password));

        using var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);

        string json = "";
        if (version == "v3")
        {
            json = $@"
                {{
                    ""AcceptanceV3FormSecondaryIssuedForeign"": {{
                        ""notification_application_consideration"": ""qabul qilindi""
                    }}
                }}";
        }
        else
        {
            json = $@"
                {{
                    ""AcceptanceFormSecondaryIssuedForeign"": {{
                        ""notification_application_consideration"": ""qabul qilindi""
                    }}
                }}";
        }

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync(url, content);
        return response.IsSuccessStatusCode;
    }
}
