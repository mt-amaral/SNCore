

namespace Admin.Domain.Entities;

public class CronExpression
{
    public short Id { get; init; }
    public string Second { get; private set; } = string.Empty;
    public string Minute { get; private set; } = string.Empty;
    public string Hour { get; private set; } = string.Empty;
    public string Day { get; private set; } = string.Empty;
    public string Month { get; private set; } = string.Empty;
    public string Weesday { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;

    public ICollection<RunTime> RunTime { get; private set; } = new HashSet<RunTime>();

    public void UpdateDescription(string description)
    {
        Description = description;
    }

    public string GetExpression()
    {
        // regra: não pode ter "*" nos dois
        if (Day == "*" && Weesday == "*")
            Weesday = "?"; // ou: day = "?"

        return $"{Second} {Minute} {Hour} {Day} {Month} {Weesday}";
    }
}


