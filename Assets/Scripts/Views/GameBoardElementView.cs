using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DG.Tweening;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class GameBoardElementView : View, IChangeListener, ISlideListener
{
    public SpriteRenderer sprite;
    public float destroyDuration;
    private IntVector2 _lastPos;
    private static int _changeTimes;
    private ChangeState _changeState;

    public override void Link(IEntity entity, IContext context)
    {
        base.Link(entity, context);
        _thisGameEntity.AddChangeListener(this);
        _lastPos = IntVector2.DefaultValue();
        _changeState = ChangeState.NONE;
        transform.position = new Vector3(_thisGameEntity.position.value.x, Contexts.sharedInstance.game.gameBoard.rows,0);
    }

    public override void OnMove(GameEntity entity, IntVector2 target)
    {
        _thisGameEntity.ReplacePosition(target);
    
        transform.DOLocalMove(new Vector3(target.x, target.y, 0f), 0.3f).OnComplete(() =>
        {
            
            _thisGameEntity.ReplaceEliminate(_thisGameEntity.detectionSameItem.sameEntities.Count > 2);

            if (_changeState == ChangeState.START)
            {
                var e = Contexts.sharedInstance.game.GetEntitiesWithPosition(_lastPos).Single();
                _changeTimes++;
                if (_changeTimes == 2)
                {
                    _changeTimes = 0;

                    if (!_thisGameEntity.eliminate.canEliminate && !e.eliminate.canEliminate)
                    {
                        e.ReplaceMove(_thisGameEntity.position.value);
                        _thisGameEntity.ReplaceMove(_lastPos);
                        _lastPos = IntVector2.DefaultValue();
                    }
                    else
                    {
                        _lastPos = IntVector2.DefaultValue();
                    }
                }
                _changeState = ChangeState.END;
            }
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

    public void OnChange(GameEntity entity, IntVector2 firstPos, IntVector2 secondPos)
    {
        if (_thisGameEntity != null)
        {
            _changeState = ChangeState.START;
            _lastPos = _thisGameEntity.position.value;
            //_thisGameEntity.ReplaceMove(_thisGameEntity.position.value.Equals(firstPos) ? secondPos : firstPos);
        }
    }
}
