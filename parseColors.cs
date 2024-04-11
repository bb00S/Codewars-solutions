using System;
using System.Collections.Generic;


public class HtmlColorParser
{
    private readonly IDictionary<string, string> presetColors;

    public HtmlColorParser(IDictionary<string, string> presetColors)
    {
        this.presetColors = presetColors;
    }

    public RGB Parse(string color)
    {
        if (presetColors.ContainsKey(color.ToLower()))
        {
            return ParseHexColor(presetColors[color.ToLower()]);
        }
        else if (color.StartsWith("#") && (color.Length == 4 || color.Length == 7))
        {
            return ParseHexColor(color);
        }
        else
        {
            throw new ArgumentException("Invalid color format.");
        }
    }

    private RGB ParseHexColor(string hexColor)
    {
        hexColor = hexColor.TrimStart('#');
        int length = hexColor.Length;

        byte r, g, b;

        if (length == 3)
        {
            r = Convert.ToByte(hexColor.Substring(0, 1) + hexColor.Substring(0, 1), 16);
            g = Convert.ToByte(hexColor.Substring(1, 1) + hexColor.Substring(1, 1), 16);
            b = Convert.ToByte(hexColor.Substring(2, 1) + hexColor.Substring(2, 1), 16);
        }
        else if (length == 6)
        {
            r = Convert.ToByte(hexColor.Substring(0, 2), 16);
            g = Convert.ToByte(hexColor.Substring(2, 2), 16);
            b = Convert.ToByte(hexColor.Substring(4, 2), 16);
        }
        else
        {
            throw new ArgumentException("Invalid hex color format.");
        }

        return new RGB(r, g, b);
    }

    public static void Main()
    {
        var presetColors = new Dictionary<string, string>()
        {
            { "red", "#FF0000" },
            { "green", "#00FF00" },
            { "blue", "#0000FF" },
            { "limegreen", "#32CD32" }
            // Add more preset colors as needed
        };

        var colorParser = new HtmlColorParser(presetColors);

        RGB color1 = colorParser.Parse("#80FFA0");
        RGB color2 = colorParser.Parse("#3B7");
        RGB color3 = colorParser.Parse("LimeGreen");

        Console.WriteLine($"Parsed color 1: R={color1.r}, G={color1.g}, B={color1.b}");
        Console.WriteLine($"Parsed color 2: R={color2.r}, G={color2.g}, B={color2.b}");
        Console.WriteLine($"Parsed color 3: R={color3.r}, G={color3.g}, B={color3.b}");
    }
}
