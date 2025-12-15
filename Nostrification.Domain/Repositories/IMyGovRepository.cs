using Nostrification.Domain.Entities;

namespace Nostrification.Domain.Repositories;

public interface IMyGovRepository
{
    Task<bool> SendStatusGetAsync(int taskId, string version = "v2");
    Task<bool> SendStatusRejectAsync(Claim claim, string fileBase64String, string version = "v2");
    Task<bool> SendStatusAcceptAsync(int taskId, string fileBase64String, string version = "v2");
    Task<bool> SendCertificateStatusAsync(Claim claim, string version = "v2");  
}
