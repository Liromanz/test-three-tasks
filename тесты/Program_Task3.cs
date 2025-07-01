/*using System.Text.RegularExpressions;

// Задание 3
// запихнула все в один файл, чтобы удобней было запускать
// -------------------------------------------------------

var log = new LogStandardizer();
log.StandardizeLogs("logfile.txt", "output.txt", "problems.txt");

// -------------------------------------------------------

public interface ILogParser
{
    bool TryParse(string line, out string standardizedLine);
}

public class Format1Parser : ILogParser
{
    private static readonly Regex Format1Regex = new Regex(
        @"^(\d{2}\.\d{2}\.\d{4})\s(\d{2}:\d{2}:\d{2}\.\d{3})\s(INFORMATION|INFO|WARNING|WARN|ERROR|DEBUG)\s(.+)$",
        RegexOptions.Compiled);

    public bool TryParse(string line, out string standardizedLine)
    {
        standardizedLine = string.Empty;

        Match match = Format1Regex.Match(line);
        if (match.Success)
        {
            string date = match.Groups[1].Value.Replace(".", "-");
            string time = match.Groups[2].Value;
            string level = NormalizeLogLevel(match.Groups[3].Value);
            string message = match.Groups[4].Value;

            standardizedLine = $"{date}\t{time}\t{level}\tDEFAULT\t{message}";
            return true;
        }
        return false;
    }

    private static string NormalizeLogLevel(string level)
    {
        switch (level)
        {
            case "INFORMATION":
            case "INFO":
                return "INFO";
            case "WARNING":
            case "WARN":
                return "WARN";
            default:
                return level;
        }
    }
}

public class Format2Parser : ILogParser
{
    private static readonly Regex Format2Regex = new Regex(
        @"^(\d{4}-\d{2}-\d{2})\s(\d{2}:\d{2}:\d{2}\.\d{4})\|(\s*(INFORMATION|INFO|WARNING|WARN|ERROR|DEBUG))\|\d+\|([^|]+)\|(.+)$",
        RegexOptions.Compiled);

    public bool TryParse(string line, out string standardizedLine)
    {
        standardizedLine = string.Empty;

        Match match = Format2Regex.Match(line);
        if (match.Success)
        {
            string date = match.Groups[1].Value;
            string time = match.Groups[2].Value;
            string level = NormalizeLogLevel(match.Groups[3].Value.Trim());
            string method = match.Groups[4].Value;
            string message = match.Groups[5].Value;

            standardizedLine = $"{date}\t{time}\t{level}\t{method}\t{message}";
            return true;
        }
        return false;
    }

    private static string NormalizeLogLevel(string level)
    {
        switch (level)
        {
            case "INFORMATION":
            case "INFO":
                return "INFO";
            case "WARNING":
            case "WARN":
                return "WARN";
            default:
                return level;
        }
    }
}


public class LogStandardizer
{
    private readonly List<ILogParser> parsers = new List<ILogParser>
    {
        new Format1Parser(),
        new Format2Parser()
    };

    public void StandardizeLogs(string inputFilePath, string outputFilePath, string problemsFilePath)
    {
        using var input = new StreamReader(inputFilePath);
        using var output = new StreamWriter(outputFilePath, false);
        using var problems = new StreamWriter(problemsFilePath, false);

        string line;
        while ((line = input.ReadLine()) != null)
        {
            bool parsed = false;
            foreach (var parser in parsers)
            {
                if (parser.TryParse(line, out var standardizedLine))
                {
                    output.WriteLine(standardizedLine);
                    Console.WriteLine("прошло:\t\t" + standardizedLine);
                    parsed = true;
                    break;
                }
            }

            if (!parsed)
            {
                problems.WriteLine(line);
                Console.WriteLine("не прошло:\t" + line);
            }
        }
    }
}*/