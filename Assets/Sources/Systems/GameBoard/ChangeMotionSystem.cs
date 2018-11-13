using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangeMotionSystem : ReactiveSystem<GameEntity>
{
    public ChangeMotionSystem(Contexts context) : base(context.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Change);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasChange;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        if (entities.Count == 2)
        {
            var one = entities[0].position.value;
            var two = entities[1].position.value;
            entities[0].ReplaceMove(two);
            entities[1].ReplaceMove(one);
        }
    }
}
