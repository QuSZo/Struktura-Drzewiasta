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
                    Name = "Dokumenty",
                    CustomSortId = 1
                },
                new Node()
                {
                    Name = "Obrazy",
                    CustomSortId = 2,
                    Nodes = new List<Node>()
                    {
                        new Node()
                        {
                            Name = "Wakacje nad morzem",
                            CustomSortId = 1,
                        },
                        new Node()
                        {
                            Name = "Wakacje w górach",
                            CustomSortId = 2,
                        }
                    }
                }
            }
        };

        return nodes;
    }
}