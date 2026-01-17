using Microsoft.Extensions.Options;
using Nostrification.Domain.Entities;
using Nostrification.Domain.Entities.MyGov;
using Nostrification.Domain.Repositories;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Nostrification.Infrastructure.Repositories;

public class MyGovRepository(IOptions<MyGovSettings> options) : IMyGovRepository
{
    private readonly MyGovSettings _settings = options.Value;

    public Task<string> GetJsonStringAsync(int taskId, string version = "v2")
    {
        //var secondUrl = version == "v3" ? _settings.ThirdUrl : _settings.SecondUrl;
        //var url = $"{_settings.BaseUri}/{secondUrl}/rest-api/get-task/?id={taskId}";

        //var credentials = Convert.ToBase64String(
        //    Encoding.GetEncoding("ISO-8859-1")
        //        .GetBytes($"{_settings.UserName}:{_settings.Password}")
        //);

        //using var httpClient = new HttpClient();
        //httpClient.DefaultRequestHeaders.Authorization =
        //    new AuthenticationHeaderValue("Basic", credentials);

        //var response = await httpClient.GetAsync(url);
        //response.EnsureSuccessStatusCode();

        //return await response.Content.ReadAsStringAsync();

        var json = @"{
            ""task"": {
                ""id"": 223966316,
                ""status"": ""process"",
                ""created_date"": ""2025-10-20 17:34:05"",
                ""last_update"": ""2025-10-20 17:50:41"",
                ""current_node"": ""application-review"",
                ""version_code"": ""v3"",
                ""from_operator"": false,
                ""operator_org"": null,
                ""operator_org_id"": null,
                ""repo_lang"": null
            },
            ""entities"": {
                ""SecondaryIssuedForeign"": {
                    ""name_head_education"": {
                        ""label"": ""Xalq taʼlimi boshqarmasi boshlig‘i F.I.O"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""registry_number"": {
                        ""label"": ""Reyestr raqami"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""doc_number_diploma_gos"": {
                        ""label"": ""Hujjat (diplom, attestat, sertifikat) raqami"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""series_doc_diploma_gos"": {
                        ""label"": ""Hujjat (diplom, attestat, sertifikat) seriyasi"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""country_educated_gos"": {
                        ""label"": ""Ta’lim olingan mamlakat"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""graduation_year"": {
                        ""label"": ""Diplom berilgan yil"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""name_institution_gos"": {
                        ""label"": ""Taʼlim muassasasining nomi"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""refer_registr_numb"": {
                        ""label"": ""Maʼlumotnoma ro‘yxatga olish raqami"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""refusal_notice"": {
                        ""label"": ""Уведомление об отказе в рассмотрении заявления"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""commission_conclusion"": {
                        ""label"": ""Komissiya xulosasi"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""country_educated"": {
                        ""label"": ""Ta’lim olingan mamlakat"",
                        ""value"": ""Antigua va Barbuda"",
                        ""real_value"": ""8""
                    },
                    ""form_education"": {
                        ""label"": ""Ta'lim shakli"",
                        ""value"": ""Sirtqi"",
                        ""real_value"": ""4""
                    },
                    ""type_edu"": {
                        ""label"": ""Ta’lim bosqichi:"",
                        ""value"": ""O‘rta ta'lim"",
                        ""real_value"": ""1""
                    },
                    ""country_born_child"": {
                        ""label"": ""Shaxsini tasqidlovchi hujjat:"",
                        ""value"": """",
                        ""real_value"": null
                    },
                    ""fio_child"": {
                        ""label"": ""F.I.O. (bitiruvchining yoki o'quvchining)"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""who_for_child"": {
                        ""label"": ""Ariza kim tomonidan yo‘llanmoqda?"",
                        ""value"": """",
                        ""real_value"": null
                    },
                    ""date_receiving"": {
                        ""label"": ""Olgan sanasi"",
                        ""value"": """",
                        ""real_value"": """"
                    },
                    ""email"": {
                        ""label"": ""Email"",
                        ""value"": ""botya14@gmail.com"",
                        ""real_value"": ""botya14@gmail.com""
                    },
                    ""phone"": {
                        ""label"": ""Phone"",
                        ""value"": ""998959804089"",
                        ""real_value"": ""998959804089""
                    },
                    ""passport_foreign"": {
                        ""label"": ""O‘zbekiston Respublikasi fuqarosining pasporti"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""passport_uz"": {
                        ""label"": ""Pasport seriyasi va raqami"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""name_parent_substitute"": {
                        ""label"": ""F.I.O."",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""name_parent"": {
                        ""label"": ""F.I.O."",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""district"": {
                        ""label"": ""Tuman (shahar)"",
                        ""value"": ""Yunusobod tumani"",
                        ""real_value"": ""1726266""
                    },
                    ""region"": {
                        ""label"": ""Hudud"",
                        ""value"": ""Toshkent shahri"",
                        ""real_value"": ""1726""
                    },
                    ""translation_cert_edu"": {
                        ""label"": ""Xorijiy mamlakatlarda taʼlimni tugatganligi to‘g‘risidagi hujjatning davlat tiliga notarial tasdiqlangan tarjimasi va unga ilova"",
                        ""value"": ""cf210b2f-bb64-2008-e07a-e13b6683b4ba"",
                        ""real_value"": ""cf210b2f-bb64-2008-e07a-e13b6683b4ba""
                    },
                    ""copy_cert_edu"": {
                        ""label"": ""Xorijiy davlatlarda ta’lim olganlik to‘g‘risidagi hujjat va unga ilovaning nusxasi"",
                        ""value"": ""6ba30c35-f295-9c97-a486-a1bc214f4a15"",
                        ""real_value"": ""6ba30c35-f295-9c97-a486-a1bc214f4a15""
                    },
                    ""number_doc_edu"": {
                        ""label"": ""Hujjat (diplom, attestat, sertifikat) raqami"",
                        ""value"": ""123"",
                        ""real_value"": ""123""
                    },
                    ""series_doc_edu"": {
                        ""label"": ""Hujjat (diplom, attestat, sertifikat) seriyasi"",
                        ""value"": ""123"",
                        ""real_value"": ""123""
                    },
                    ""date_grad_edu"": {
                        ""label"": ""Taʼlim muassasasining tugash sanasi"",
                        ""value"": """",
                        ""real_value"": """"
                    },
                    ""date_applied_edu"": {
                        ""label"": ""Taʼlim muassasasiga qabul qilingan sana"",
                        ""value"": """",
                        ""real_value"": """"
                    },
                    ""place_edu"": {
                        ""label"": ""Taʼlim muassasasining manzili"",
                        ""value"": ""test"",
                        ""real_value"": ""test""
                    },
                    ""title_edu"": {
                        ""label"": ""Ta'lim muassasasi nomi"",
                        ""value"": ""test"",
                        ""real_value"": ""test""
                    },
                    ""scan_born_cert"": {
                        ""label"": ""Скан свидетельства о рождении"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""date_of_given_cert"": {
                        ""label"": ""Дата выдачи свидетельства о рождении"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""series_cert_foreign"": {
                        ""label"": ""Tug'ilganlik to'g'risidagi guvohnoma seriyasi va raqami"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""series_cert_uz"": {
                        ""label"": ""Tug'ilganlik to'g'risidagi guvohnoma seriyasi va raqami"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""dob_child"": {
                        ""label"": ""Bolaning tug‘ilgan sanasi"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""notice_consideration"": {
                        ""label"": ""Уведомление о принятии заявления на рассмотрение"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""reject_reason"": {
                        ""label"": ""Причина отказа"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""edc_applicant"": {
                        ""label"": ""ЭЦП заявителя"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""edc_authority"": {
                        ""label"": ""ЭЦП госоргана"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""offer"": {
                        ""label"": ""Oferta"",
                        ""value"": """",
                        ""real_value"": null
                    },
                    ""agree"": {
                        ""label"": ""Подтверждаю"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""passport_number"": {
                        ""label"": ""Pasport seriyasi va raqami"",
                        ""value"": ""AE2280651"",
                        ""real_value"": ""AE2280651""
                    },
                    ""passport_issue_date"": {
                        ""label"": ""Berilgan sana"",
                        ""value"": ""2025-04-10"",
                        ""real_value"": ""2025-04-10""
                    },
                    ""permit_address"": {
                        ""label"": ""Permit Address"",
                        ""value"": ""БОДОМЗОР МФЙ, РАИС КЎЧАСИ, uy:7-7А"",
                        ""real_value"": ""БОДОМЗОР МФЙ, РАИС КЎЧАСИ, uy:7-7А""
                    },
                    ""user_type"": {
                        ""label"": ""Foydalanuvchi turi"",
                        ""value"": ""Jismoniy shaxs"",
                        ""real_value"": ""I""
                    },
                    ""birthday"": {
                        ""label"": ""Tug'ilgan sanasi"",
                        ""value"": ""08-04-1998"",
                        ""real_value"": ""08-04-1998""
                    },
                    ""full_name"": {
                        ""label"": ""F.I.O."",
                        ""value"": ""CHO‘LLIYEV O‘TKIRJON SHUXRATOVICH"",
                        ""real_value"": ""CHO‘LLIYEV O‘TKIRJON SHUXRATOVICH""
                    },
                    ""authority_id"": {
                        ""label"": ""Authority ID"",
                        ""value"": 10355,
                        ""real_value"": 10355
                    },
                    ""id"": {
                        ""label"": ""ID"",
                        ""value"": ""37980"",
                        ""real_value"": ""37980""
                    },
                    ""peraddress"": {
                        ""label"": ""Yashash manzili"",
                        ""value"": ""БОДОМЗОР МФЙ, РАИС КЎЧАСИ, uy:7-7А"",
                        ""real_value"": ""БОДОМЗОР МФЙ, РАИС КЎЧАСИ, uy:7-7А""
                    },
                    ""phones"": {
                        ""label"": ""Telefon raqami"",
                        ""value"": ""998959804089"",
                        ""real_value"": ""998959804089""
                    },
                    ""mail"": {
                        ""label"": ""Elektron pochta"",
                        ""value"": ""botya14@gmail.com"",
                        ""real_value"": ""botya14@gmail.com""
                    },
                    ""head_organization"": {
                        ""label"": ""Hududiy boshqaruv nomi"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""exam_lang"": {
                        ""label"": ""Imtihonni qaysi tilda topshirmoqchisiz?"",
                        ""value"": """",
                        ""real_value"": null
                    },
                    ""pinfl"": {
                        ""label"": ""Arizachi JSHSHIR"",
                        ""value"": ""30804986520010"",
                        ""real_value"": ""30804986520010""
                    },
                    ""select_child"": {
                        ""label"": ""Выберите ребенка"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""who_child"": {
                        ""label"": ""Qarindoshlik darajasi"",
                        ""value"": """",
                        ""real_value"": null
                    },
                    ""birth_certificate"": {
                        ""label"": ""Tug'ilganlik to'g'risidagi guvohnoma seriyasi va raqami"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""child_age_question"": {
                        ""label"": ""Arizachi turi"",
                        ""value"": ""Arizachi"",
                        ""real_value"": ""1""
                    },
                    ""child_pinfl"": {
                        ""label"": ""Bolaning JSHSHIR"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""document_obtained"": {
                        ""label"": ""Документ получен после 2022 года ?"",
                        ""value"": ""Ha"",
                        ""real_value"": ""1""
                    },
                    ""scanned_copy_file"": {
                        ""label"": ""Скан-копия документа с апостилем, выданным уполномоченным органом страны, выдавшей документ"",
                        ""value"": ""a5e9e9e3-0952-987a-6d2b-77b168f5eae3"",
                        ""real_value"": ""a5e9e9e3-0952-987a-6d2b-77b168f5eae3""
                    },
                    ""conclusion_text"": {
                        ""label"": ""Текст заключения"",
                        ""value"": null,
                        ""real_value"": null
                    },
                    ""issue_date"": {
                        ""label"": ""Berilgan sana"",
                        ""value"": null,
                        ""real_value"": null
                    }
                }
            }
        }";
        return Task.FromResult(json);
    }

    public async Task<(byte[] fileBytes, string fileName)> GetRepoFileAsunc(int taskId, string version = "v2")
    {
        var secondUrl = version == "v3" ? _settings.ThirdUrl : _settings.SecondUrl;
        var url = $"{_settings.BaseUri}/{secondUrl}/rest-api/get-repo-list?id={taskId}";

        var credintials = Convert.ToBase64String(
            Encoding.GetEncoding("ISO-8859-1")
                .GetBytes($"{_settings.UserName}:{_settings.Password}")
            );

        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credintials);

        var listResponse = await httpClient.GetAsync(url);
        listResponse.EnsureSuccessStatusCode();

        var listJson = await listResponse.Content.ReadAsStringAsync();
        var repoList = JsonSerializer.Deserialize<List<MyGovRepoList>>(listJson);

        //if (repoList is null || repoList.Count == 0)
        //    throw new Exception("RepoList bo'sh");

        var guid = repoList[0].Guid;

        var fileUrl = $"{_settings.BaseUri}/{secondUrl}/rest-api/get-repo?guid={guid}";
        var fileResponse = await httpClient.GetAsync(fileUrl);
        fileResponse.EnsureSuccessStatusCode();

        var fileJson = await fileResponse.Content.ReadAsStringAsync();
        var fileInfo = JsonSerializer.Deserialize<MyGovRepoFile>(fileJson);

        //if (fileInfo == null || string.IsNullOrEmpty(fileInfo.file))
        //    throw new Exception("Fayl topilmadi yoki bo‘sh.");

        byte[] fileBytes = Convert.FromBase64String(fileInfo!.File);
        string fileName = $"xulosa_{taskId}.{fileInfo.Ext}";

        return (fileBytes, fileName);
    }

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
            return true;
            //var response = await httpClient.PostAsync(url, content);
            //return response.IsSuccessStatusCode;
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
            return true;
            //var response = await httpClient.PostAsync(url, content);
            //return response.IsSuccessStatusCode;
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
            return true;
            //var response = await httpClient.PostAsync(url, content);
            //return response.IsSuccessStatusCode;
        }
        catch
        {
            return true;
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

            return true;
            //var response = await httpClient.PostAsync(url, content);
            //return response.IsSuccessStatusCode;
        }
        catch { return false; }
        
    }
    
}
