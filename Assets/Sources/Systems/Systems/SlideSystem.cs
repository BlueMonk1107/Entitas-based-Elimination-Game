using System;
using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideSystem : ReactiveSystem<InputEntity>
{
    public SlideSystem(Contexts contexts) : base(contexts.input)
    {
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.Slide);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasSlide;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        if (entities.Count == 1)
        {
            InputEntity entity = entities.SingleEntity();
            bool canMove = Contexts.sharedInstance.game.GetEntitiesWithMove(new IntVector2(entity.slide.clickPos.x, entity.slide.clickPos.y)).SingleEntity().isMovable;

            if (canMove)
            {
                var pos = GetPos(entity);
                Contexts.sharedInstance.input.ReplaceClick(pos.x, pos.y);
            }
        }
    }

    private IntVector2 GetPos(InputEntity entity)
    {
        int x = entity.slide.clickPos.x;
        int y = entity.slide.clickPos.y;

        switch (entity.slide.direction)
        {
            case SlideDirection.LEFT:
                x--;
                break;
            case SlideDirection.RIGHT:
                x++;
                break;
            case SlideDirection.UP:
                y++;
                break;
            case SlideDirection.DOWN:
                y--;
                break;
        }

        x = LimitValue(x, 0, Contexts.sharedInstance.game.gameBoard.columns);
        y = LimitValue(y, 0, Contexts.sharedInstance.game.gameBoard.rows);

        return new IntVector2(x, y);
    }

    private int LimitValue(int value, int min, int max)
    {
        if (value < min)
        {
            value++;
        }
        else if (value >= max)
        {
            value--;
        }

        return value;
    }
}
