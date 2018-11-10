using Entitas;
using Entitas.Unity;
using UnityEngine;

public class View : MonoBehaviour, IView, IPositionListener, IDestroyedListener
{
    protected GameEntity _thisGameEntity;

    public virtual void Link(IEntity entity, IContext context) {
        gameObject.Link(entity, context);
        _thisGameEntity = (GameEntity)entity;
        _thisGameEntity.AddPositionListener(this);
        _thisGameEntity.AddDestroyedListener(this);

        var pos = _thisGameEntity.position.value;
        transform.localPosition = new Vector3(pos.x, pos.y);
    }

    public virtual void OnPosition(GameEntity entity, IntVector2 value) {
        transform.localPosition = new Vector3(value.x, value.y);
    }

    public virtual void OnDestroyed(GameEntity entity) {
        Destroy();
    }

    protected virtual void Destroy() {
        gameObject.Unlink();
        Destroy(gameObject);
    }
}
