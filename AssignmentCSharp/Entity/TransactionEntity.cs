namespace AssignmentCSharp.Entity;

public class TransactionEntity
{
    private long transactionId { get; set; }
    private String accountSend{ get; set; }
    private String personSend{ get; set; }
    private String accountReceive{ get; set; }
    private String personrRceive{ get; set; }
    private double transactionAmount{ get; set; }
    private String message{ get; set; }
    private DateTime create_at{ get; set; }
    private DateTime update_at{ get; set; }
    private DateTime create_by{ get; set; }
    private DateTime update_by{ get; set; }

    public TransactionEntity()
    {
    }

    public TransactionEntity(long transactionId, string accountSend, string personSend, string accountReceive, string personrRceive, double transactionAmount, string message, DateTime createAt, DateTime updateAt, DateTime createBy, DateTime updateBy)
    {
        this.transactionId = transactionId;
        this.accountSend = accountSend;
        this.personSend = personSend;
        this.accountReceive = accountReceive;
        this.personrRceive = personrRceive;
        this.transactionAmount = transactionAmount;
        this.message = message;
        create_at = createAt;
        update_at = updateAt;
        create_by = createBy;
        update_by = updateBy;
    }
}