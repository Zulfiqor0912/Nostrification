using Nostrification.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nostrification.Application.Claims.Dtos;

public class ClaimDto
{
    public int Id { get; set; }
    public int TaskId { get; set; }
    public int? ClaimerTypeId { get; set; }
    public string? ParentName { get; set; }
    public string? FullName { get; set; }
    public string? PassportFile { get; set; }
    public int? RegionId { get; set; }
    //public int? DistrictId { get; set; }
    public string? Adress { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    //public int? UniversityCountry { get; set; }
    public string? UniversityName { get; set; }
    //public string? UniversityAdress { get; set; }
    //public int? StudyStepId { get; set; }
    //public int? StudyTypeId { get; set; }
    public string? DiplomSeria { get; set; }
    public string? DiplomNumber { get; set; }
    public string? DiplomGetDate { get; set; }
    public string? StudyStartYear { get; set; }
    public string? StudyEndYear { get; set; }
    public string? File1 { get; set; }
    public string? File2 { get; set; }
    public string? AppostilFile { get; set; }
    public int? StatusId { get; set; }
    public string? AnswerFile { get; set; }
    //public string? AnswerComment { get; set; }
    public DateTime? AnswerDate { get; set; }
    public virtual ClaimerType ClaimerType { get; set; }
    public virtual ClaimStatus ClaimStatus { get; set; }
    public virtual Country Country { get; set; }
    public virtual Region Region { get; set; }
    public virtual Region District { get; set; }
    public virtual StudyStep StudyStep { get; set; }
    public virtual StudyType StudyType { get; set; }
    //public string Status { get; set; }
    public DateTime? CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    //public string? CurrentNode { get; set; }
    //public bool? FromOperator { get; set; }
    //public string? OperatorOrg { get; set; }
    //public DateTime? OwnCreateDate { get; set; }
    //public DateTime? OwnUpdateDate { get; set; }
    public string? refer_registr_numb { get; set; }
    public string? name_institution_gos { get; set; }
    public string? graduation_year { get; set; }
    public string? country_educated_gos { get; set; }
    public string? series_doc_diploma_gos { get; set; }
    public string? doc_number_diploma_gos { get; set; }
    //public string? head_organization { get; set; }
    public string? name_head_education { get; set; }
    public string? registry_number { get; set; }
    //public string? user_type { get; set; }
    //public string? rejection_reason { get; set; }
    public string? PINF { get; set; }
    public int? Version { get; set; }
}
