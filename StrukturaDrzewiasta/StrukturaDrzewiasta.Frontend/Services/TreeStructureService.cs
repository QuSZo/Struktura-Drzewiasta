using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using MatBlazor;
using StrukturaDrzewiasta.Shared;

namespace StrukturaDrzewiasta.Frontend.Services;

public interface ITreeStructureService
{
    public Task CreateNode(CreateNodeDto createNodeDto);
    public Task EditNode(EditNodeDto editNodeDto);
    public Task MoveNode(MoveNodeDto moveNodeDto);
    public Task<List<ReadNodeTreeDto>> GetNodeTree(string sortedBy);
    public Task DeleteNode(int nodeId);
}

public class TreeStructureService : ITreeStructureService
{
    private readonly HttpClient _httpClient;
    private readonly IMatToaster _matToaster;

    public TreeStructureService(HttpClient httpClient, IMatToaster matToaster)
    {
        _httpClient = httpClient;
        _matToaster = matToaster;
    }

    public async Task CreateNode(CreateNodeDto createNodeDto)
    {
        var response = await _httpClient.PostAsJsonAsync("https://localhost:7162/api/TreeStructure", createNodeDto);
        if(!response.IsSuccessStatusCode)
        {
            string message = await response.Content.ReadAsStringAsync();
            _matToaster.Add(message, MatToastType.Danger, "Error");
        }
    }

    public async Task EditNode(EditNodeDto editNodeDto)
    {
        var response = await _httpClient.PutAsJsonAsync("https://localhost:7162/api/TreeStructure/update", editNodeDto);
        if(!response.IsSuccessStatusCode)
        {
            string message = await response.Content.ReadAsStringAsync();
            _matToaster.Add(message, MatToastType.Danger, "Error");
        }
    }

    public async Task MoveNode(MoveNodeDto moveNodeDto)
    {
        var response = await _httpClient.PutAsJsonAsync("https://localhost:7162/api/TreeStructure/move", moveNodeDto);
        if(!response.IsSuccessStatusCode)
        {
            string message = await response.Content.ReadAsStringAsync();
            _matToaster.Add(message, MatToastType.Danger, "Error");
        }
    }

    public async Task<List<ReadNodeTreeDto>> GetNodeTree(string sortedBy)
    {
        var response = await _httpClient.GetAsync($"https://localhost:7162/api/TreeStructure?sortedBy={sortedBy}");
        var content = await response.Content.ReadFromJsonAsync<List<ReadNodeTreeDto>>();
        if(!response.IsSuccessStatusCode)
        {
            string message = await response.Content.ReadAsStringAsync();
            _matToaster.Add(message, MatToastType.Danger, "Error");
        }
        return content;
    }

    public async Task DeleteNode(int nodeId)
    {
        var response = await _httpClient.DeleteAsync($"https://localhost:7162/api/TreeStructure/{nodeId}");
        if(!response.IsSuccessStatusCode)
        {
            string message = await response.Content.ReadAsStringAsync();
            _matToaster.Add(message, MatToastType.Danger, "Error");
        }
    }
}