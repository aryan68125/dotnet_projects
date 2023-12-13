namespace mvc_tutorial.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; } //property

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
