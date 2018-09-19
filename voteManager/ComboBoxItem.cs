using System.Linq;

namespace VoteManager.Forms
{
    public class DisplayItem<T>
    {
        public string DisplayProperty { get; set; }

        public T Item { get; set; }

        public DisplayItem(T obj)
        {
            var propInfo = typeof(T).GetProperties().FirstOrDefault(prop => prop.Name.Equals("name", System.StringComparison.OrdinalIgnoreCase));
            if (propInfo == null)
            {
                propInfo = obj.GetType().GetProperties().FirstOrDefault(prop => prop.Name.Equals("id", System.StringComparison.OrdinalIgnoreCase));
            }
            Item = obj;
            // extract value
            DisplayProperty = propInfo?.GetValue(obj).ToString();
        }

        public override string ToString() => DisplayProperty;
    }
}
