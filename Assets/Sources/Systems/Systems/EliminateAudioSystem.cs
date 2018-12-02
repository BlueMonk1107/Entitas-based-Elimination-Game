using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class EliminateAudioSystem : ReactiveSystem<GameEntity>
{
    public EliminateAudioSystem(Contexts context) : base(context.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Eliminate);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasEffectState;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity entity in entities)
        {
            switch (entity.effectState.itemEffctName)
            {
                case ItemEffctName.NONE:
                    entity.ReplaceAudio("Audio/" + AudioName.NormalBomb);
                    break;
                case ItemEffctName.ELIMINATE_SAME_COLOR:
                    entity.ReplaceAudio("Audio/" + AudioName.SpecialBomb);
                    break;
                case ItemEffctName.ELIMINATE_HORIZONTAL:
                    entity.ReplaceAudio("Audio/" + AudioName.SpecialBomb);
                    break;
                case ItemEffctName.ELIMINATE_VERTICAL:
                    entity.ReplaceAudio("Audio/" + AudioName.SpecialBomb);
                    break;
                case ItemEffctName.EXPLODE:
                    entity.ReplaceAudio("Audio/" + AudioName.SpecialBomb);
                    break;
            }
        }
    }
}

