using System.Drawing;

namespace EElections
{
    public class PartieInfo
    {
        public string Name { get; set; }
        public string Website { get; set; }
        public string LogoFile { get; set; }
        public Color PrimaryColor { get; set; }
        public Color SecondaryColor { get; set; }

        public PartieInfo()
        {
            Name = "Default Partie";
            LogoFile = string.Empty;
            Website = string.Empty;
            PrimaryColor = Color.FromKnownColor(KnownColor.Control);
            SecondaryColor = Color.FromKnownColor(KnownColor.Control);
        }
    }
}
