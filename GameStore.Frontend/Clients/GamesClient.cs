using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient(HttpClient httpClient)
{
    public async Task<GameSummary[]> GetGamesAsync() => await httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? Array.Empty<GameSummary>();

    public async Task AddGameAsync(GameDetails game) => await httpClient.PostAsJsonAsync("games", game);

    public async Task<GameDetails> GetGameAsync(int id) => await httpClient.GetFromJsonAsync<GameDetails>($"games/{id}") ?? throw new InvalidOperationException("Game not found");

    public async Task UpdateGameAsync(GameDetails updatedGame) => await httpClient.PutAsJsonAsync($"games/{updatedGame.Id}", updatedGame);

    public async Task DeleteGameAsync(int id) => await httpClient.DeleteAsync($"games/{id}");
}
