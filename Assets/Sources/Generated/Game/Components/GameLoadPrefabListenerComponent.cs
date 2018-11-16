//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public LoadPrefabListenerComponent loadPrefabListener { get { return (LoadPrefabListenerComponent)GetComponent(GameComponentsLookup.LoadPrefabListener); } }
    public bool hasLoadPrefabListener { get { return HasComponent(GameComponentsLookup.LoadPrefabListener); } }

    public void AddLoadPrefabListener(System.Collections.Generic.List<ILoadPrefabListener> newValue) {
        var index = GameComponentsLookup.LoadPrefabListener;
        var component = CreateComponent<LoadPrefabListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceLoadPrefabListener(System.Collections.Generic.List<ILoadPrefabListener> newValue) {
        var index = GameComponentsLookup.LoadPrefabListener;
        var component = CreateComponent<LoadPrefabListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveLoadPrefabListener() {
        RemoveComponent(GameComponentsLookup.LoadPrefabListener);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLoadPrefabListener;

    public static Entitas.IMatcher<GameEntity> LoadPrefabListener {
        get {
            if (_matcherLoadPrefabListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LoadPrefabListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLoadPrefabListener = matcher;
            }

            return _matcherLoadPrefabListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddLoadPrefabListener(ILoadPrefabListener value) {
        var listeners = hasLoadPrefabListener
            ? loadPrefabListener.value
            : new System.Collections.Generic.List<ILoadPrefabListener>();
        listeners.Add(value);
        ReplaceLoadPrefabListener(listeners);
    }

    public void RemoveLoadPrefabListener(ILoadPrefabListener value, bool removeComponentWhenEmpty = true) {
        var listeners = loadPrefabListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveLoadPrefabListener();
        } else {
            ReplaceLoadPrefabListener(listeners);
        }
    }
}
