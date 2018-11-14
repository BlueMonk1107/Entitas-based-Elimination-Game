using Entitas;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 判断是否存在满足条件的相邻同色元素
/// </summary>
public class JudgeSameColorSystem : ReactiveSystem<GameEntity> {

    public JudgeSameColorSystem(Contexts context) : base(context.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.DetectionSameItem);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasDetectionSameItem;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        List<IEntity> sameEntities = new List<IEntity>();
        foreach (GameEntity gameEntity in entities)
        {
            sameEntities = gameEntity.detectionSameItem.sameEntities;
            gameEntity.ReplaceEliminate(sameEntities.Count > 2);
        }
    }
}
