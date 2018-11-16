using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

/// <summary>
/// 判断阵型是否能生成特效元素
/// </summary>
public class JudgeFormationSystem : ReactiveSystem<GameEntity>
{
    public JudgeFormationSystem(Contexts context) : base(context.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.JudgeFormation);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isJudgeFormation;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity gameEntity in entities)
        {
            if (JudgeEliminateAll(gameEntity))
            {
                gameEntity.ReplaceEffectState(ItemEffctName.ELIMINATE_SAME_COLOR);
            }
            else if (JudgeEliminateHorizontal(gameEntity))
            {
                gameEntity.ReplaceEffectState(ItemEffctName.ELIMINATE_HORIZONTAL);
            }
            else if (JudgeEliminateVertical(gameEntity))
            {
                gameEntity.ReplaceEffectState(ItemEffctName.ELIMINATE_VERTICAL);
            }
            else if (JudgeExplode(gameEntity))
            {
                gameEntity.ReplaceEffectState(ItemEffctName.EXPLODE);
            }
            else
            {
                gameEntity.ReplaceEffectState(ItemEffctName.NONE);
            }

            gameEntity.ReplaceEliminate(true);
            gameEntity.isJudgeFormation = false;
        }
    }

    private bool JudgeEliminateAll(GameEntity entity)
    {
        var c = entity.detectionSameItem;
        if (c.sameEntitiesDown.Count + c.sameEntitiesUp.Count >= 4)
            return true;
        if (c.sameEntitiesLeft.Count + c.sameEntitiesRight.Count >= 4)
            return true;

        return false;
    }

    private bool JudgeEliminateHorizontal(GameEntity entity)
    {
        var c = entity.detectionSameItem;

        if (c.sameEntitiesLeft.Count + c.sameEntitiesRight.Count == 3)
            return true;

        return false;
    }

    private bool JudgeEliminateVertical(GameEntity entity)
    {
        var c = entity.detectionSameItem;

        if (c.sameEntitiesDown.Count + c.sameEntitiesUp.Count == 3)
            return true;

        return false;
    }

    private bool JudgeExplode(GameEntity entity)
    {
        var c = entity.detectionSameItem;
        int countHor = c.sameEntitiesLeft.Count + c.sameEntitiesRight.Count;
        int countVer = c.sameEntitiesDown.Count + c.sameEntitiesUp.Count;

        if (countHor >= 2 && countVer >= 2)
            return true;

        return false;
    }
}
