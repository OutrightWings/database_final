
public class StudentCode
{
    public int Id { get; set; }
    public string Code { get; set; } = "";
    public DateTime DateGenerated { get; set; }
    public bool Approved { get; set; }
    public DateTime? DateApproved { get; set; }
    public int? ApprovalUserId { get; set; }
    public string? ApprovalUsername { get; set; } // will join users table
}

