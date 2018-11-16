using System;
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
        string name = "";
        foreach (GameEntity entity in entities)
        {
            switch (entity.effectState.itemEffctName)
            {
                case ItemEffctName.ELIMINATE_SAME_COLOR:
                    name = Res.ALL_POSTFIX;
                    break;
                case ItemEffctName.ELIMINATE_HORIZONTAL:
                    name = Res.HORIZONTAL_POSTFIX;
                    break;
                case ItemEffctName.ELIMINATE_VERTICAL:
                    name = Res.VERTICAL_POSTFIX;
                    break;
                case ItemEffctName.EXPLODE:
                    name = Res.EXPLODE_POSTFIX;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            entity.ReplaceLoadSprite(Res.SPRITES_FOLDER + entity.loadPrefab.path + name);
        }
    }
}
