using Entitas;
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
            if (!gameEntity.isJudgeFormation)
            {
                sameEntities.Add(gameEntity);
            }
            else
            {
                gameEntity.isJudgeFormation = false;
            }
                

            sameEntities.AddRange(gameEntity.detectionSameItem.sameEntitiesLeft);
            sameEntities.AddRange(gameEntity.detectionSameItem.sameEntitiesRight);
            sameEntities.AddRange(gameEntity.detectionSameItem.sameEntitiesUp);
            sameEntities.AddRange(gameEntity.detectionSameItem.sameEntitiesDown);

            foreach (IEntity e in sameEntities)
            {
                temp = e as GameEntity;
                if (temp != null)
                {
                    temp.isDestroyed = true;
                }
            }
        }
        
    }
}
