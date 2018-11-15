using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public sealed class ClickSystem : ReactiveSystem<InputEntity>
{
    readonly Contexts _contexts;
    readonly IGroup<InputEntity> _input;
    readonly List<InputEntity> _inputBuffer = new List<InputEntity>();
    private ClickComponent _lastInputComponent;

    public ClickSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
        _input = contexts.input.GetGroup(InputMatcher.Click);
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.Click);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasClick;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        var inputEntity = entities.SingleEntity();
        var click = inputEntity.click;
        bool canMove = _contexts.game.GetEntitiesWithMove(new IntVector2(click.x, click.y)).SingleEntity().isMovable;

        if (canMove)
        {
            if (_lastInputComponent != null)
            {
                //检测当前操作的是否是上下左右四个点中的一个
                if ((click.x == _lastInputComponent.x - 1 && click.y == _lastInputComponent.y)
                  || (click.x == _lastInputComponent.x + 1 && click.y == _lastInputComponent.y)
                  || (click.y == _lastInputComponent.y - 1 && click.x == _lastInputComponent.x)
                  || (click.y == _lastInputComponent.y + 1 && click.x == _lastInputComponent.x))
                {
                    ReplaceChange(click);
                    ReplaceChange(_lastInputComponent);
                    _lastInputComponent = null;
                }
            }
            else
            {
                _lastInputComponent = new ClickComponent();
            }

            if (_lastInputComponent != null)
            {
                _lastInputComponent.x = click.x;
                _lastInputComponent.y = click.y;
            }
        }
       
    }

   
    private void ReplaceChange(ClickComponent input)
    {
        foreach (var e in _contexts.game.GetEntitiesWithMove(new IntVector2(input.x, input.y)).Where(e => e.isInteractive))
        {
            e.ReplaceExchange(ExchangeState.START);
        }
    }
}
