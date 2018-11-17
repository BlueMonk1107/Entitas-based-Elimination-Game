using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

/// <summary>
/// 爆炸消除效果
/// </summary>
public class ExplodeSystem : ReactiveSystem<GameEntity>
{
    public ExplodeSystem(Contexts context) : base(context.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroyed);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasEffectState && entity.effectState.itemEffctName == ItemEffctName.EXPLODE;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        IntVector2 pos = IntVector2.DefaultValue();
        foreach (GameEntity entity in entities)
        {
            pos = entity.move.target;

            for (int x = pos.x - 1; x <= pos.x + 1; x++)
            {
                for (int y = pos.y - 1; y <= pos.y + 1; y++)
                {
                    try
                    {
                        Contexts.sharedInstance.game.GetEntitiesWithMove(new IntVector2(x, y))
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
}
