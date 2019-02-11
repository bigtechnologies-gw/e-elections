namespace EElections.Interfaces
{
    interface ICustomizable
    {
        void ApplyCustomization(PartieInfo partieInfo);
        void LoadCustomization();
        void SaveCustomization(PartieInfo partieInfo);
    }
}
