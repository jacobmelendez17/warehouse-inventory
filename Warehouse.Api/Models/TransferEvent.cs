namespace Warehouse.Api.Models;

public class TransferEvent
{
    public int Id { get; set; }
    public int StockTransferId { get; set; }
    public StockTransfer StockTransfer { get; set; } = null;
    public string Action { get; set; } = string.Empty;
    public DateTime OccuredAtUtc { get; set; } = DateTime.UtcNow;
}