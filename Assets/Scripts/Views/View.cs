using System;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class View : MonoBehaviour, IView, IMoveListener, IDestroyedListener
{
    protected GameEntity _thisGameEntity;

    public virtual void Link(IEntity entity, IContext context) {
        gameObject.Link(entity, context);
        _thisGameEntity = (GameEntity)entity;
        _thisGameEntity.AddMoveListener(this);
        _thisGameEntity.AddDestroyedListener(this);

        var pos = _thisGameEntity.move.target;
        transform.localPosition = new Vector3(pos.x, pos.y);
    }

    public virtual void OnMove(GameEntity entity, IntVector2 value) {
    }

    public virtual void OnDestroyed(GameEntity entity) {
        Destroy();
    }

    protected virtual void Destroy() {
        gameObject.Unlink();
        Destroy(gameObject);
    }
}
