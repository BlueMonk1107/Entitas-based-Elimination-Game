using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCompleteSystem : ReactiveSystem<GameEntity> {

    public MoveCompleteSystem(Contexts context) : base(context.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.MoveComplete);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isMoveComplete;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity gameEntity in entities)
        {
            gameEntity.isGetSameColor = true;
            gameEntity.isMoveComplete = false;
        }
    }
}
