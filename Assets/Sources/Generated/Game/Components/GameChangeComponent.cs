//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ChangeComponent change { get { return (ChangeComponent)GetComponent(GameComponentsLookup.Change); } }
    public bool hasChange { get { return HasComponent(GameComponentsLookup.Change); } }

    public void AddChange(IntVector2 newFirstPos, IntVector2 newSecondPos) {
        var index = GameComponentsLookup.Change;
        var component = CreateComponent<ChangeComponent>(index);
        component.firstPos = newFirstPos;
        component.secondPos = newSecondPos;
        AddComponent(index, component);
    }

    public void ReplaceChange(IntVector2 newFirstPos, IntVector2 newSecondPos) {
        var index = GameComponentsLookup.Change;
        var component = CreateComponent<ChangeComponent>(index);
        component.firstPos = newFirstPos;
        component.secondPos = newSecondPos;
        ReplaceComponent(index, component);
    }

    public void RemoveChange() {
        RemoveComponent(GameComponentsLookup.Change);
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

    static Entitas.IMatcher<GameEntity> _matcherChange;

    public static Entitas.IMatcher<GameEntity> Change {
        get {
            if (_matcherChange == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Change);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherChange = matcher;
            }

            return _matcherChange;
        }
    }
}