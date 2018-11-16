using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 根据特效给元素切换图片
/// </summary>
public class ChangeItemSpriteSystem : ReactiveSystem<GameEntity> {

    public ChangeItemSpriteSystem(Contexts context) : base(context.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.EffectState);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasEffectState && entity.effectState.itemEffctName != ItemEffctName.NONE;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity entity in entities)
        {

        }
    }
}
