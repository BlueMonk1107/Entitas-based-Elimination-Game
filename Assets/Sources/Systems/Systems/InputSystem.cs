using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public sealed class InputSystem : ReactiveSystem<InputEntity>, ICleanupSystem
{

    readonly Contexts _contexts;
    readonly IGroup<InputEntity> _input;
    readonly List<InputEntity> _inputBuffer = new List<InputEntity>();
    private InputComponent _lastInputComponent;

    public InputSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
        _input = contexts.input.GetGroup(InputMatcher.Input);
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.Input);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasInput;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        var inputEntity = entities.SingleEntity();
        var input = inputEntity.input;
        bool canMove = _contexts.game.GetEntitiesWithMove(new IntVector2(input.x, input.y)).SingleEntity().isMovable;

        if (canMove)
        {
            if (_lastInputComponent != null)
            {
                //检测当前操作的是否是上下左右四个点中的一个
                if ((input.x == _lastInputComponent.x - 1 && input.y == _lastInputComponent.y)
                  || (input.x == _lastInputComponent.x + 1 && input.y == _lastInputComponent.y)
                  || (input.y == _lastInputComponent.y - 1 && input.x == _lastInputComponent.x)
                  || (input.y == _lastInputComponent.y + 1 && input.x == _lastInputComponent.x))
                {
                    ReplaceChange(input);
                    ReplaceChange(_lastInputComponent);
                    _lastInputComponent = null;
                }
            }
            else
            {
                _lastInputComponent = new InputComponent();
            }

            if (_lastInputComponent != null)
            {
                _lastInputComponent.x = input.x;
                _lastInputComponent.y = input.y;
            }
        }
       
    }

   
    private void ReplaceChange(InputComponent input)
    {
        foreach (var e in _contexts.game.GetEntitiesWithMove(new IntVector2(input.x, input.y)).Where(e => e.isInteractive))
        {
            e.ReplaceExchange(ExchangeState.START);
        }
    }

    public void Cleanup()
    {
        foreach (var e in _input.GetEntities(_inputBuffer))
        {
            e.Destroy();
        }
    }
}
