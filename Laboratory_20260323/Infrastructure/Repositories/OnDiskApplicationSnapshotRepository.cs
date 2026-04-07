using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Persistence.Mappers;
using System.Text.Json;

namespace Laboratory_20260323.Infrastructure.Repositories;

public class OnDiskApplicationSnapshotRepository : IApplicationSnapshotRepository
{
    public void Save(ApplicationDataSnapshot snapshot, string path)
    {
        string contents = JsonSerializer.Serialize(snapshot);
        File.WriteAllText(path, contents);
    }

    public ApplicationDataSnapshot Load(string path)
    {
        string contents = File.ReadAllText(path);
        return JsonSerializer.Deserialize<ApplicationDataSnapshot>(contents);
    }
}
