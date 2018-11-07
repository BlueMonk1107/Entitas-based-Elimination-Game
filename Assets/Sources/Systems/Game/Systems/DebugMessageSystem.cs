using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class DebugMessageSystem : ReactiveSystem<GameEntity>
{
    public DebugMessageSystem(Contexts context) : base(context.game)
    {

    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.DebugMsg);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasDebugMsg;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity entity in entities)
        {
            Debug.Log(entity.debugMsg.message);
        }
    }
}
