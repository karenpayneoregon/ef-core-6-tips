using NorthWind2020ConsoleApp.Models;

namespace NorthWind2020ConsoleAppCore7.Models
{
    public class Manager
    {
        public Employees Employee { get; set; }
        public List<Employees> Workers { get; set; } = new();
    }
}