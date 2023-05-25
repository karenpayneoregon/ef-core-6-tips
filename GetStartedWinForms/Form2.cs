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
using GetStartedWinForms.Models;
using Microsoft.EntityFrameworkCore;

namespace GetStartedWinForms;
public partial class Form2 : Form
{
    public Form2()
    {
        InitializeComponent();
    }

    private void Form2_Load(object sender, EventArgs e)
    {
        using var context = new NorthwindContext();
        CategoryCombobox.DataSource = context.Categories.ToList();
        CategoryCombobox.SelectedIndexChanged += CategoryCombobox_SelectedIndexChanged;
    }

    private void CategoryCombobox_SelectedIndexChanged(object sender, EventArgs e)
    {
        var category = CategoryCombobox.SelectedItem as Category;
        using var context = new NorthwindContext();

        var products = context
            .Products
            .Where(p => p.CategoryId == category.CategoryId)
            .ToList();
        if (products.Any())
        {
            Debug.WriteLine(products.Count);
        }
    }
}
