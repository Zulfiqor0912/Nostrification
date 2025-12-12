using Microsoft.Extensions.Options;
using Nostrification.Domain.Entities;
using Nostrification.Domain.Entities.MyGov;
using Nostrification.Domain.Repositories;
using System.Text;

namespace Nostrification.Infrastructure.Repositories;

public class MyGovRepository(IOptions<MyGovSettings> options) : IMyGovRepository
{
    private readonly MyGovSettings _settings = options.Value;
    public async Task<bool> SendStatusGetAsync(int taskId, string version = "v2")
    {
        try
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
        catch
        {
            return false;
        }
    }

    public async Task<bool> SendStatusRejectAsync(Claim claim, string fileBase64String, string version = "v2")
    {
        try
        {
            var secondUrl = version == "v3" ? _settings.ThirdUrl : _settings.SecondUrl;
            var url = $"{_settings.BaseUri}/{secondUrl}/rest-api/update/id/{claim.TaskId}/action/refusal-notice";

            var userPass = $"{_settings.UserName}:{_settings.Password}";
            var userPasswordByte = Encoding.GetEncoding("ISO-8859-1").GetBytes(userPass);

            var credintials = Convert.ToBase64String(userPasswordByte);
            using var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credintials);

            var json = "";

            if (version == "v3")
            {
                json = $@"
            {{
                ""RefusalNoticeV3FormSecondaryIssuedForeign"": {{
                    ""conclusion_text"": ""{claim.rejection_reason}"",
                    ""name_head_education"": ""{claim.name_head_education}""
                }}
            }}";
            }
            else
            {
                json = $@"
                {{
                    ""RefusalNoticeFormSecondaryIssuedForeign"": {{
                        ""refusal_notice"": {{
                            ""target"": ""file"",
                            ""ext"": ""pdf"",
                            ""file"": ""{fileBase64String}""
                        }}
                    }}
                }}";
            }

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, content);
            return response.IsSuccessStatusCode;
        }
        catch { return false; }
        
    }
    
}
