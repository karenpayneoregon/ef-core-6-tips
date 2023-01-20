using System.Reflection;

namespace MaxLengthApp.Classes
{
    public class Details
    {
        public string Name { get; }
        public IEnumerable<PropertyInfo> NavigationProperties { get; }

        public Details(string name, IEnumerable<PropertyInfo> navigationProperties)
        {
            Name = name;
            NavigationProperties = navigationProperties;
        }
    }
}