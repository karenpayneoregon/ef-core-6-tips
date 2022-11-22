using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GetStartedWinForms.Data;

namespace GetStartedWinForms;

public partial class StoreForm : Form
{
    public StoreForm()
    {
        InitializeComponent();
    }

    private void ExecuteButton_Click(object sender, EventArgs e)
    {
        using var context = new StoreContext();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var saturdayOrSundayDelivered = context.Orders.AsEnumerable().Where(o => o.DeliveredDate.IsWeekend()).ToList();
        foreach (var order in saturdayOrSundayDelivered)
        {
            Debug.WriteLine($"{order.Id,-5}{order.DeliveredDate:f}");
        }

    }
}

public static class Extensions
{
    public static bool IsWeekend(this DateTime self)
    {
        return (self.DayOfWeek == DayOfWeek.Sunday || self.DayOfWeek == DayOfWeek.Saturday);
    }
}