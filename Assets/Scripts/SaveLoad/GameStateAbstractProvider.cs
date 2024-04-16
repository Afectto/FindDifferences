public abstract class GameStateAbstractProvider : IGameStateProvider, IGameStateSaver
{
    protected virtual string KEY { get; set; } = "";

    public GameStateData GameState { get; protected set; }

    public abstract void SaveGameState();
    public abstract void LoadGameState();

    protected GameStateData InitFromSetting()
    {
        var gameState = new GameStateData
        {
            LevelNum = 1
        };
        return gameState;
    }
}