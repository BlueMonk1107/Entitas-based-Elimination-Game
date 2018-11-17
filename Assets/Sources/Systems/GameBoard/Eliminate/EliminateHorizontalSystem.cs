using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class EliminateHorizontalSystem : ReactiveSystem<GameEntity>
{
    public EliminateHorizontalSystem(Contexts context) : base(context.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroyed);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasEffectState && entity.effectState.itemEffctName == ItemEffctName.ELIMINATE_HORIZONTAL;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity entity in entities)
        {
            for (int y = 0; y < Contexts.sharedInstance.game.gameBoard.columns; y++)
            {
                try
                {
                    Contexts.sharedInstance.game.GetEntitiesWithMove(new IntVector2(entity.move.target.x, y))
                        .SingleEntity()
                        .isDestroyed = true;
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
    }
}
