using System.Text.RegularExpressions;

namespace Admin.App.Client.Utils;

public static class CronExpressionTranslator
{
    // Mapeamento de dias da semana e meses para português
    private static readonly Dictionary<int, string> DaysOfWeek = new Dictionary<int, string>
    {
        { 0, "domingo" }, { 1, "segunda-feira" }, { 2, "terça-feira" },
        { 3, "quarta-feira" }, { 4, "quinta-feira" }, { 5, "sexta-feira" },
        { 6, "sábado" }, { 7, "domingo" }
    };

    private static readonly Dictionary<int, string> Months = new Dictionary<int, string>
    {
        { 1, "janeiro" }, { 2, "fevereiro" }, { 3, "março" }, { 4, "abril" },
        { 5, "maio" }, { 6, "junho" }, { 7, "julho" }, { 8, "agosto" },
        { 9, "setembro" }, { 10, "outubro" }, { 11, "novembro" }, { 12, "dezembro" }
    };

    // Valida e traduz a expressão cron
    public static (bool IsValid, string Description) Translate(string cronExpression)
    {
        if (!ValidateCronExpression(cronExpression))
            return (false, "Expressão cron inválida.");

        string[] parts = cronExpression.Split(' ');
        if (parts.Length != 5)
            return (false, "Formato cron incorreto. Use: minuto hora dia mês dia-da-semana.");

        string minute = parts[0];
        string hour = parts[1];
        string day = parts[2];
        string month = parts[3];
        string dayOfWeek = parts[4];

        List<string> descriptionParts = new List<string>();

        // Parte 1: Horário (minuto e hora)
        if (minute == "0" && hour == "0")
            descriptionParts.Add("à meia-noite");
        else if (minute == "0")
            descriptionParts.Add($"às {hour}:00");
        else if (hour.Contains('/') || hour.Contains('-') || hour == "*")
            descriptionParts.Add($"a cada {GetDescription(hour, "hora", "hora")}");
        else
            descriptionParts.Add($"aos {minute} minutos da hora {hour}");

        // Parte 2: Dia do mês
        if (day != "*")
            descriptionParts.Add($"no dia {GetDayDescription(day)}");

        // Parte 3: Mês
        if (month != "*")
            descriptionParts.Add($"em {GetMonthDescription(month)}");

        // Parte 4: Dia da semana
        if (dayOfWeek != "*")
            descriptionParts.Add(GetDayOfWeekDescription(dayOfWeek));

        // Combinar todas as partes
        string description = string.Join(", ", descriptionParts).TrimEnd() + ".";
        return (true, char.ToUpper(description[0]) + description.Substring(1));
    }

    // Validação da expressão cron
    private static bool ValidateCronExpression(string cronExpression)
    {
        string cronPattern = @"^(\*|(\d+(-\d+)?)(,\d+(-\d+)?)*|\*/\d+)(\s+(\*|(\d+(-\d+)?)(,\d+(-\d+)?)*|\*/\d+)){4}$";
        return Regex.IsMatch(cronExpression, cronPattern);
    }

    // Descrição de intervalos (ex: "1-5" → "de segunda a sexta-feira")
    private static string GetDescription(string field, string singular, string plural)
    {
        if (field == "*") return $"qualquer {singular}";
        if (field.Contains('/')) return $"a cada {field.Split('/')[1]} {plural}";
        if (field.Contains('-')) return $"de {field.Split('-')[0]} a {field.Split('-')[1]}";
        if (field.Contains(',')) return $"nos {field.Replace(",", " e")}";
        return $"na {singular} {field}";
    }

    // Descrição de dias da semana
    private static string GetDayOfWeekDescription(string dayOfWeek)
    {
        if (dayOfWeek == "*") return "";
        if (int.TryParse(dayOfWeek, out int day))
            return DaysOfWeek.ContainsKey(day) ? $"apenas na {DaysOfWeek[day]}" : "";
        return $"nos dias {dayOfWeek}";
    }

    // Descrição de meses
    private static string GetMonthDescription(string month)
    {
        if (month == "*") return "";
        if (int.TryParse(month, out int m))
            return Months.ContainsKey(m) ? Months[m] : "";
        return $"no mês {month}";
    }

    // Descrição do dia do mês
    private static string GetDayDescription(string day)
    {
        if (day == "1") return "1º";
        return day;
    }
}