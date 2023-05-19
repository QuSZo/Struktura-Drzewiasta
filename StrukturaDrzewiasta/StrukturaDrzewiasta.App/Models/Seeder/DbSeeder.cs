using StrukturaDrzewiasta.App.Models.DbModels;

namespace StrukturaDrzewiasta.App.Models.Seeder;

public class DbSeeder
{
    private readonly AppDbContext _appDbContext;

    public DbSeeder(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Seed()
    {
        if (_appDbContext.Database.CanConnect())
        {
            if (!_appDbContext.Node.Any())
            {
                var nodes = GetNodes();
                _appDbContext.Node.AddRange(nodes);
                _appDbContext.SaveChanges();
            }
        }
    }

    private Node GetNodes()
    {
        var nodes = new Node()
        {
            Name = "root",
            ParentNodeId = null,
            Nodes = new List<Node>()
            {
                new Node()
                {
                    Name = "Dokumenty"
                },
                new Node()
                {
                    Name = "Obrazy"
                }
            }
        };

        return nodes;
    }
}