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
        foreach (GameEntity gameEntity in entities)
        {
            if (IsMeetTheConditions(gameEntity))
            {
                gameEntity.isJudgeFormation = true;
            }
        }
    }

    //是否符合消除条件
    private bool IsMeetTheConditions(GameEntity gameEntity)
    {
        int left = gameEntity.detectionSameItem.sameEntitiesLeft.Count;
        int right = gameEntity.detectionSameItem.sameEntitiesRight.Count;
        int up = gameEntity.detectionSameItem.sameEntitiesUp.Count;
        int down = gameEntity.detectionSameItem.sameEntitiesDown.Count;

        return left + right >= 2 
            || up   + down  >= 2;
    }
}
