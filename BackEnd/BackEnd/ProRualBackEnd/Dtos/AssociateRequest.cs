namespace ProRualBackEnd.Dtos
{
    public class AssociateRequest
    {
        public List<Guid> BeneficiaryIds { get; set; }
        public Guid OrganizationId { get; set; }
    }
}
