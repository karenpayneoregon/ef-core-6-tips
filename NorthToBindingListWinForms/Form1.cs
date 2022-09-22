using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using NorthToBindingListWinForms.Models;

namespace NorthToBindingListWinForms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        dataGridView1.AutoGenerateColumns = false;
        Shown += OnShown;
    }

    private async void OnShown(object? sender, EventArgs e)
    {
        BindingList<Contacts> source = new BindingList<Contacts>();
        
        await Task.Run(async () =>
        {
            await using var context = new NorthContext();
            await context.Contacts
                .AsTracking()
                .Include(x => x.ContactTypeNavigation)
                .Take(5)
                .LoadAsync();

            source = context.Contacts.Local.ToBindingList();
        });
        
        dataGridView1.DataSource = source;


    }
}