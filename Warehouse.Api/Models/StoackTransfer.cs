namespace Warehouse.Api.Models;

public class StockTransfer
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int FromBranchId { get; set; }
    public int ToBranchId { get; set; }
    public int Quantity { get; set; }
    public string Status { get; set; } = "Pending";
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime? DecidedAtUtc { get; set; }
    public DateTime? FulfilledAtUtc { get; set; }
}