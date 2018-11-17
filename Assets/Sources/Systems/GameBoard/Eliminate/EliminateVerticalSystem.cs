using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

/// <summary>
/// 消除一列元素
/// </summary>
public class EliminateVerticalSystem : ReactiveSystem<GameEntity>
{
    public EliminateVerticalSystem(Contexts context) : base(context.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroyed);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasEffectState && entity.effectState.itemEffctName == ItemEffctName.ELIMINATE_VERTICAL;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity entity in entities)
        {
            for (int x = 0; x < Contexts.sharedInstance.game.gameBoard.columns; x++)
            {
                try
                {
                    Contexts.sharedInstance.game.GetEntitiesWithMove(new IntVector2(x, entity.move.target.y))
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
