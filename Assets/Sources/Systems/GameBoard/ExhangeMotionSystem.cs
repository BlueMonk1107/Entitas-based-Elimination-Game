using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExhangeMotionSystem : ReactiveSystem<GameEntity>
{
    public ExhangeMotionSystem(Contexts context) : base(context.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Exchange);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasExchange
               && (entity.exchange.exchangeState == ExchangeState.START
                   || entity.exchange.exchangeState == ExchangeState.END);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        if (entities.Count == 2)
        {
            Exhange(entities[0], entities[1]);
        }
    }

    private void Exhange(GameEntity one, GameEntity two)
    {
        var onePos = one.move.target;
        var twoPos = two.move.target;
        one.ReplaceMove(twoPos);
        two.ReplaceMove(onePos);
        one.exchange.exchangeState = ExchangeState.MOVING;
        two.exchange.exchangeState = ExchangeState.MOVING;
    }
}
