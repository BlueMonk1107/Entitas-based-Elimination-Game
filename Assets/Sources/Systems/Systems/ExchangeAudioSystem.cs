using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ExchangeAudioSystem : ReactiveSystem<GameEntity>
{
    public ExchangeAudioSystem(Contexts context) : base(context.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Exchange);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasExchange
            && entity.exchange.exchangeState == ExchangeState.EXCHANGE
            && entity.exchange.exchangeState == ExchangeState.EXCHANGEBACK;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity entity in entities)
        {
            entity.ReplaceAudio("Audio/" + AudioName.Switch);
        }
    }
}
