namespace Esoterica.Lib;
public static class Formatter
{
    private static readonly int charA = Convert.ToInt32('a');
    private static Dictionary<string, Dictionary<int, string>> Formats = new()
        {
            { "char", NumberFormats.Letters },
            { "none", new Dictionary<int, string>() }
        };

    private static string _formatType = "char";
    public static string FormatType
    {
        get => _formatType;
        set
        {
            if (!Formats.ContainsKey(value))
            {
                _formatType = "none";
            }
        }
    }

    public static int SignificantDigits = 6;

    public static void AddFormat(string formatName, Dictionary<int, string> values)
    {
        if (Formats.ContainsKey(formatName))
        {
            Formats[formatName] = values;
            return;
        }

        Formats.Add(formatName, values);
    }

    public static string Format(this BigDouble value)
    {
        if (value < 1)
        {
            return "0";
        }

        var units = Formats[FormatType];

        var n = (int)BigDouble.Log(value, 1000);
        var m = value / Math.Pow(1000, n);
        var unit = "";

        if (n < units.Count)
        {
            unit = units[n];
        }
        else
        {
            unit = value.ToString();
        }

        var num = (BigDouble.Floor(m * 100) / 100).ToString();
        if (num.Length > SignificantDigits)
            num = num.Remove(SignificantDigits);

        return num + unit;
    }

    public static string Format(this BigDouble value, string format)
    {
        if (string.IsNullOrWhiteSpace(format))
            format = FormatType;

        if (!Formats.ContainsKey(format))
        {
            return value.ToString();
        }

        if (value < 1)
        {
            return "0";
        }

        var units = Formats[format];

        var n = (int)BigDouble.Log(value, 1000);
        var m = value / Math.Pow(1000, n);
        var unit = "";

        if (n < units.Count)
        {
            unit = units[n];
        }
        else
        {
            unit = value.ToString();
        }

        var num = (BigDouble.Floor(m * 100) / 100).ToString();
        if (num.Length > SignificantDigits)
            num = num.Remove(SignificantDigits);

        return num + unit;
    }
}