using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 元素消除响应系统
/// </summary>
public class EliminateSystem : ReactiveSystem<GameEntity> {

    public EliminateSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Eliminate);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasEliminate && entity.eliminate.canEliminate;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        List<IEntity> sameEntities = new List<IEntity>();
        GameEntity temp;
        foreach (GameEntity gameEntity in entities)
        {
            sameEntities.Add(gameEntity);
            sameEntities.AddRange(gameEntity.detectionSameItem.sameEntitiesHorizontal);
            sameEntities.AddRange(gameEntity.detectionSameItem.sameEntitiesVertical);

            foreach (IEntity e in sameEntities)
            {
                temp = e as GameEntity;
                if (temp != null) temp.isDestroyed = true;
            }
        }
        
    }
}
