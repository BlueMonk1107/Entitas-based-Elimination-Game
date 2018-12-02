public sealed class GameSystems : Feature {

    public GameSystems(Contexts contexts) {

        // Input
        Add(new ClickSystem(contexts));
        Add(new SlideSystem(contexts));

        // Update
        Add(new GameBoardSystems(contexts));
        Add(new ScoreSystem(contexts));

        // Events
        Add(new InputEventSystems(contexts));
        Add(new GameEventSystems(contexts));
        Add(new GameStateEventSystems(contexts));

        // Cleanup
        Add(new DestroyEntitySystem(contexts));
        Add(new DebugMessageSystem(contexts));
    }
}
