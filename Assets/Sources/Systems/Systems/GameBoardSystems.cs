using Vuforia;

public sealed class GameBoardSystems : Feature {

    public GameBoardSystems(Contexts contexts) {
        Add(new GameBoardSystem(contexts));
        Add(new FallSystem(contexts));
        Add(new FillSystem(contexts));
        Add(new EliminateSystem(contexts));
        Add(new ExhangeMotionSystem(contexts));
        Add(new JudgeSameColorSystem(contexts));
        Add(new ExhangeBackSystem(contexts));
        Add(new GetSameColorSystem(contexts));
        Add(new MoveCompleteSystem(contexts));
    }
}
