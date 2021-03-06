//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public LoadSpriteListenerComponent loadSpriteListener { get { return (LoadSpriteListenerComponent)GetComponent(GameComponentsLookup.LoadSpriteListener); } }
    public bool hasLoadSpriteListener { get { return HasComponent(GameComponentsLookup.LoadSpriteListener); } }

    public void AddLoadSpriteListener(System.Collections.Generic.List<ILoadSpriteListener> newValue) {
        var index = GameComponentsLookup.LoadSpriteListener;
        var component = CreateComponent<LoadSpriteListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceLoadSpriteListener(System.Collections.Generic.List<ILoadSpriteListener> newValue) {
        var index = GameComponentsLookup.LoadSpriteListener;
        var component = CreateComponent<LoadSpriteListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveLoadSpriteListener() {
        RemoveComponent(GameComponentsLookup.LoadSpriteListener);
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

    static Entitas.IMatcher<GameEntity> _matcherLoadSpriteListener;

    public static Entitas.IMatcher<GameEntity> LoadSpriteListener {
        get {
            if (_matcherLoadSpriteListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LoadSpriteListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLoadSpriteListener = matcher;
            }

            return _matcherLoadSpriteListener;
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

    public void AddLoadSpriteListener(ILoadSpriteListener value) {
        var listeners = hasLoadSpriteListener
            ? loadSpriteListener.value
            : new System.Collections.Generic.List<ILoadSpriteListener>();
        listeners.Add(value);
        ReplaceLoadSpriteListener(listeners);
    }

    public void RemoveLoadSpriteListener(ILoadSpriteListener value, bool removeComponentWhenEmpty = true) {
        var listeners = loadSpriteListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveLoadSpriteListener();
        } else {
            ReplaceLoadSpriteListener(listeners);
        }
    }
}
