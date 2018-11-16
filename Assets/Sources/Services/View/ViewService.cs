using UnityEngine;

public class ViewService : ILoadPrefabListener
{

    public static ViewService singleton = new ViewService();

    Contexts _contexts;
    Transform _parent;
    private Transform _settledParent;
    private Transform _movableParent;

    public void Initialize(Contexts contexts, Transform parent)
    {
        _contexts = contexts;
        _parent = parent;
        contexts.game.CreateEntity().AddLoadPrefabListener(this);
        _settledParent = new GameObject("settled").transform;
        _settledParent.SetParent(_parent);
        _settledParent.position = new Vector3(0, 0, -0.01f);
        _movableParent = new GameObject("movable").transform;
        _movableParent.SetParent(_parent);
    }

    public void OnLoadPrefab(GameEntity entity, string path)
    {
        Transform parent = null;
        if (entity.isMovable)
        {
            parent = _movableParent;
        }
        else
        {
            parent = _settledParent;
        }
        var prefab = Resources.Load<GameObject>(Res.PREFAB_FOLDER + path);
        var view = Object.Instantiate(prefab, parent).GetComponent<IView>();
        view.Link(entity, _contexts.game);
    }
}
