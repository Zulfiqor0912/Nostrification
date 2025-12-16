using Microsoft.Extensions.Options;
using Nostrification.Domain.Entities;
using Nostrification.Domain.Entities.MyGov;
using Nostrification.Domain.Repositories;
using System.Text;

namespace Nostrification.Infrastructure.Repositories;

public class MyGovRepository(IOptions<MyGovSettings> options) : IMyGovRepository
{
    private readonly MyGovSettings _settings = options.Value;

    public async Task<bool> SendCertificateStatusAsync(Claim claim, string version = "v2")
    {
        try
        {
            var secondUrl = version == "v3" ? _settings.ThirdUrl : _settings.SecondUrl;
            var url = $"{_settings.BaseUri}/{secondUrl}/rest-api/update/id/{claim.TaskId}/action/issuance-certificate";
            var credentials = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                .GetBytes($"{_settings.UserName}:{_settings.Password}"));

            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);

            string json = "";
            if (version == "v3")
            {
                var forma =
                    $"Ushbu ma’lumotnoma bilan fuqaro {claim.FullName} ga  {claim.name_institution_gos} tomonidan {claim.graduation_year} yilda {claim.country_educated_gos} berilgan {claim.series_doc_diploma_gos} - seriyali {claim.doc_number_diploma_gos} - raqamli ma’lumot to’g’risidagi hujiat (guvohnoma, shahodatnoma) O’zbekiston Respublikasida tan olinadi va umumiy o’rta ma’lumot (o’rta ma’lumot) haqidagi guvohnomaga (shahodatnomaga) tenglashtiriladi";
                json = $@"
                {{
                    ""IssuanceCertificateV3FormSecondaryIssuedForeign"": {{
                        ""conclusion_text"": ""{forma}"",
                        ""issue_date"": ""{claim.graduation_year}"",
                        ""name_head_education"": ""{claim.name_head_education}"",
                        ""head_organization"": ""{claim.head_organization}"",
                        ""refer_registr_numb"": ""{claim.refer_registr_numb}"",
                        ""registry_number"": ""{claim.registry_number}""
                    }}
                }}";
            }
            else
            {
                json = $@"
                {{
                    ""IssuanceCertificateFormSecondaryIssuedForeign"": {{
                        ""head_organization"": ""{claim.head_organization}"",
                        ""refer_registr_numb"": ""{claim.refer_registr_numb}"",
                        ""name_institution_gos"": ""{claim.name_institution_gos}"",
                        ""series_doc_diploma_gos"": ""{claim.series_doc_diploma_gos}"",
                        ""name_head_education"": ""{claim.name_head_education}"",
                        ""graduation_year"": ""{claim.graduation_year}"",
                        ""country_educated_gos"": ""{claim.country_educated_gos}"",
                        ""doc_number_diploma_gos"": ""{claim.doc_number_diploma_gos}"",
                        ""registry_number"": ""{claim.registry_number}"",
                        ""user_type"": ""{claim.user_type}""
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

    public async Task<bool> SendStatusAcceptAsync(int taskId, string fileBase64String, string version = "v2")
    {
        try
        {
            var secondUrl = version == "v3" ? _settings.ThirdUrl : _settings.ThirdUrl;
            var url = $"{_settings.BaseUri}/{secondUrl}/rest-api/update/id/{taskId}/action/issuance-opinion";

            var credentials = Convert.ToBase64String(
                Encoding.GetEncoding("ISO-8859-1").GetBytes($"{_settings.UserName}:{_settings.Password}"));

            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);

            string json = "";
            if (version == "v3")
            {
                json = $@"
                {{
                    ""IssuanceOpinionV3FormSecondaryIssuedForeign"": {{
                        ""commission_conclusion"": {{
                            ""target"": ""file"",
                            ""ext"": ""pdf"",
                            ""file"": ""{fileBase64String}""
                        }}
                    }}
                }}";
            }
            else
            {
                json = $@"
                {{
                    ""IssuanceOpinionFormSecondaryIssuedForeign"": {{
                        ""commission_conclusion"": {{
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
        catch 
        {
            return false;
        }
    }

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
