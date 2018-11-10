//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public SlideListenerComponent slideListener { get { return (SlideListenerComponent)GetComponent(InputComponentsLookup.SlideListener); } }
    public bool hasSlideListener { get { return HasComponent(InputComponentsLookup.SlideListener); } }

    public void AddSlideListener(System.Collections.Generic.List<ISlideListener> newValue) {
        var index = InputComponentsLookup.SlideListener;
        var component = CreateComponent<SlideListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSlideListener(System.Collections.Generic.List<ISlideListener> newValue) {
        var index = InputComponentsLookup.SlideListener;
        var component = CreateComponent<SlideListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSlideListener() {
        RemoveComponent(InputComponentsLookup.SlideListener);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherSlideListener;

    public static Entitas.IMatcher<InputEntity> SlideListener {
        get {
            if (_matcherSlideListener == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.SlideListener);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherSlideListener = matcher;
            }

            return _matcherSlideListener;
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
public partial class InputEntity {

    public void AddSlideListener(ISlideListener value) {
        var listeners = hasSlideListener
            ? slideListener.value
            : new System.Collections.Generic.List<ISlideListener>();
        listeners.Add(value);
        ReplaceSlideListener(listeners);
    }

    public void RemoveSlideListener(ISlideListener value, bool removeComponentWhenEmpty = true) {
        var listeners = slideListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveSlideListener();
        } else {
            ReplaceSlideListener(listeners);
        }
    }
}
