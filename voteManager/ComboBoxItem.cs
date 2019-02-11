using System.Linq;
using System.Reflection;

namespace EElections
{
    public class DisplayItem<T>
    {
        public string DisplayProperty { get; set; }

        public T Item { get; set; }

        public DisplayItem(T obj)
        {
            PropertyInfo propInfo = typeof(T).GetProperties().FirstOrDefault(prop => prop.Name.Equals("name", System.StringComparison.OrdinalIgnoreCase));
            if (propInfo == null)
            {
                propInfo = obj.GetType().GetProperties().FirstOrDefault(prop => prop.Name.Equals("id", System.StringComparison.OrdinalIgnoreCase));
            }
            Item = obj;
            // extract value
            DisplayProperty = propInfo?.GetValue(obj).ToString();

            // mapping due to translation to portuguese
            switch (DisplayProperty)
            {
                case "North":
                    DisplayProperty = "Norte";
                    break;
                case "South":
                    DisplayProperty = "Sul";
                    break;
                case "West":
                    DisplayProperty = "Oeste";
                    break;
                case "East":
                    DisplayProperty = "Leste";
                    break;
                    // SAB is already in portuguese.
            }

        }

        public override string ToString() => DisplayProperty;
    }
}
