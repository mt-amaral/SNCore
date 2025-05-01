

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

    public string GetExpression(CronExpression expression)
    {
        var day = expression.Day;
        var weekday = expression.Weesday;

        // regra: não pode ter "*" nos dois
        if (day == "*" && weekday == "*")
            weekday = "?"; // ou: day = "?"

        return $"{expression.Second} {expression.Minute} {expression.Hour} {day} {expression.Month} {weekday}";
    }
}


