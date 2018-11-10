//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ChangeListenerComponent changeListener { get { return (ChangeListenerComponent)GetComponent(GameComponentsLookup.ChangeListener); } }
    public bool hasChangeListener { get { return HasComponent(GameComponentsLookup.ChangeListener); } }

    public void AddChangeListener(System.Collections.Generic.List<IChangeListener> newValue) {
        var index = GameComponentsLookup.ChangeListener;
        var component = CreateComponent<ChangeListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceChangeListener(System.Collections.Generic.List<IChangeListener> newValue) {
        var index = GameComponentsLookup.ChangeListener;
        var component = CreateComponent<ChangeListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveChangeListener() {
        RemoveComponent(GameComponentsLookup.ChangeListener);
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

    static Entitas.IMatcher<GameEntity> _matcherChangeListener;

    public static Entitas.IMatcher<GameEntity> ChangeListener {
        get {
            if (_matcherChangeListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ChangeListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherChangeListener = matcher;
            }

            return _matcherChangeListener;
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

    public void AddChangeListener(IChangeListener value) {
        var listeners = hasChangeListener
            ? changeListener.value
            : new System.Collections.Generic.List<IChangeListener>();
        listeners.Add(value);
        ReplaceChangeListener(listeners);
    }

    public void RemoveChangeListener(IChangeListener value, bool removeComponentWhenEmpty = true) {
        var listeners = changeListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveChangeListener();
        } else {
            ReplaceChangeListener(listeners);
        }
    }
}
