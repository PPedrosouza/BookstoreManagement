namespace BookstoreManagement.Communication.Responses;

public class ResponseRegisterBookJson
{
    public int Id { get; set; }
    public string Title { get; set; } 
    public string Author { get; set; } 
    public string Gender { get; set; } 
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}
