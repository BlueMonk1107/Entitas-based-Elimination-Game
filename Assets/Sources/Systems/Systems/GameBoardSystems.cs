using Vuforia;

public sealed class GameBoardSystems : Feature
{

    public GameBoardSystems(Contexts contexts)
    {
        Add(new GameBoardSystem(contexts));
        Add(new FallSystem(contexts));
        Add(new FillSystem(contexts));
        Add(new EliminateSystem(contexts));
        Add(new ExhangeMotionSystem(contexts));
        Add(new JudgeSameColorSystem(contexts));
        Add(new ExhangeBackSystem(contexts));
        Add(new GetSameColorSystem(contexts));
        Add(new MoveCompleteSystem(contexts));
        Add(new ChangeItemSpriteSystem(contexts));
        Add(new JudgeFormationSystem(contexts));

        Add(new EliminateHorizontalSystem(contexts));
        Add(new EliminateSameColorSystem(contexts));
        Add(new EliminateVerticalSystem(contexts));

        Add(new ExplodeSystem(contexts));

        Add(new EliminateAudioSystem(contexts));
        Add(new FallAudioSystem(contexts));
        Add(new ExchangeAudioSystem(contexts));
    }
}
