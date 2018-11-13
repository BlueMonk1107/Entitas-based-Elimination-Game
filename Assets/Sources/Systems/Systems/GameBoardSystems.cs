using Vuforia;

public sealed class GameBoardSystems : Feature {

    public GameBoardSystems(Contexts contexts) {
        Add(new GameBoardSystem(contexts));
        Add(new FallSystem(contexts));
        Add(new FillSystem(contexts));
        Add(new EliminateSystem(contexts));
        Add(new ChangeMotionSystem(contexts));
    }
}
