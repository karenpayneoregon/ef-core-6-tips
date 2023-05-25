using NorthWind2020ConsoleApp.Models;
#pragma warning disable CS8618

namespace NorthWind2020ConsoleAppCore7.Models
{
    public class Manager
    {
        public Employees Employee { get; set; }
        public List<Employees> Workers { get; set; } = new();
    }
}