using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DG.Tweening;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class GameBoardElementView : View, ISlideListener
{
    public SpriteRenderer sprite;
    public float destroyDuration;
    private IntVector2 _lastPos;
    private static int _changeTimes;
    private ExchangeState _exchangeState;

    public override void Link(IEntity entity, IContext context)
    {
        base.Link(entity, context);
        _lastPos = IntVector2.DefaultValue();
        _exchangeState = ExchangeState.NONE;
        transform.position = new Vector3(_thisGameEntity.move.target.x, Contexts.sharedInstance.game.gameBoard.rows,0);
    }

    public override void OnMove(GameEntity entity, IntVector2 target)
    {
    
        transform.DOLocalMove(new Vector3(target.x, target.y, 0f), 0.3f).OnComplete(() =>
        {
            _thisGameEntity.isMoveComplete = true;
        });
    }
    
    protected override void Destroy()
    {
        var color = sprite.color;
        color.a = 0f;
        sprite.material.DOColor(color, destroyDuration);
        gameObject.transform
            .DOScale(Vector3.one * 1.5f, destroyDuration)
            .OnComplete(base.Destroy);
    }

    public void OnSlide(InputEntity entity, SlideDirection direction)
    {
        throw new NotImplementedException();
    }
}
