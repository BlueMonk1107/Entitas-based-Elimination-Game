using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class FallAudioSystem : ReactiveSystem<GameEntity>
{
    public FallAudioSystem(Contexts context) : base(context.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Move);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasFallState && entity.fallState.state == FallState.FALL;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity entity in entities)
        {
            entity.ReplaceAudio("Audio/" + AudioName.Fall);
        }
    }
}
