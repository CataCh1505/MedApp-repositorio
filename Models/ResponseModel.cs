namespace MedApp_Api.Models;

public class ResponseModel
{
    public bool Success { get; set; }
    public bool? Handled { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }
}
