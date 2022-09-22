using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace GetStartedWinForms
{
    public partial class MainForm : Form
    {
        private ProductsContext dbContext;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            dbContext = new ProductsContext();

            // Uncomment the line below to start fresh with a new database.
            // this.dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            dbContext.Categories.Load();

            categoryBindingSource.DataSource = dbContext.Categories.Local.ToBindingList();
            
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            dbContext?.Dispose();
            dbContext = null;
        }

        private void dataGridViewCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (dbContext == null || dataGridViewCategories.CurrentRow is null) return;
            var category = (Category)dataGridViewCategories.CurrentRow.DataBoundItem;

            if (category is not null)
            {
                dbContext.Entry(category).Collection(e => e.Products).Load();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            dbContext!.SaveChanges();

            dataGridViewCategories.Refresh();
            dataGridViewProducts.Refresh();
        }
    }
}
