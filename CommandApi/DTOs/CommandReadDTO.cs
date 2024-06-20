namespace CommandApi.DTOs;

public class CommandReadDTO
{
    public long Id { get; set; }

    public string? HowTo { get; set; }

    public string? Line { get; set; }

    public string? Platform { get; set; }
}