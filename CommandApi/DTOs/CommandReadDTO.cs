namespace CommandApi.Dto;

public class CommandReadDto
{
    public long Id { get; set; }

    public string? HowTo { get; set; }

    public string? Line { get; set; }

    public string? Platform { get; set; }
}