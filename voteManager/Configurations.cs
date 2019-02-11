using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using EElections.Helpers;

namespace EElections
{
    public static class Configurations
    {
        public static PartieInfo PartieInfo { get; private set; }
        public static string SettingFile { get; }

        static Configurations()
        {
            // PartieInfo = new PartieInfo();
            SettingFile = Path.Combine(FileUtils.BaseDir, "settings.xml");
            Load();
        }

        public static void Load()
        {
            if (File.Exists(SettingFile))
            {
                XDocument xdoc = XDocument.Load(SettingFile);

                if (xdoc.Root == null)
                {
                    return;
                }

                PartieInfo = new PartieInfo()
                {
                    Name = xdoc.Root.Element(nameof(PartieInfo.Name))?.Value,
                    LogoFile = xdoc.Root.Element(nameof(PartieInfo.LogoFile))?.Value,
                    PrimaryColor = ParseToColor(xdoc.Root.Element(nameof(PartieInfo.PrimaryColor))?.Value),
                    SecondaryColor = ParseToColor(xdoc.Root.Element(nameof(PartieInfo.SecondaryColor))?.Value),
                    Website = xdoc.Root.Element(nameof(PartieInfo.Website))?.Value,
                };
            }
            else
            {
                XElement partieInfoEl = new XElement("PartieInfo",
                typeof(PartieInfo).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Select(p => new XElement(p.Name, string.Empty)));

                XElement rootEl = new XElement("Settings");
                rootEl.Add(partieInfoEl);

                PartieInfo = new PartieInfo();

                rootEl.Save(SettingFile, SaveOptions.None);
            }
        }


        public static void Save()
        {
            // root element
            XElement xEl = new XElement("PartieInfo",
            typeof(PartieInfo).GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Select(p => new XElement(p.Name, FormatValue(p.GetValue(PartieInfo)))));
            xEl.Save(SettingFile, SaveOptions.None);
        }

        private static Color ParseToColor(string value)
        {
            int rgbColorValue = int.Parse(value);
            return Color.FromArgb(rgbColorValue);
        }

        private static object FormatValue(object value)
        {
            if (value is string)
            {
                return value;
            }
            // logo file path
            if (value is null)
            {
                return string.Empty;
            }
            Color c = (Color)value;
            return c.ToArgb().ToString();
        }
    }
}
