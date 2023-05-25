using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GetStartedWinForms.Models;

public class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; }
    public override string ToString() => Name;

    public virtual ObservableCollectionListSource<Product> Products { get; } = new();
    //public virtual ICollection<Product> Products { get; set; }
}
