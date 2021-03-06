//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public EliminateComponent eliminate { get { return (EliminateComponent)GetComponent(GameComponentsLookup.Eliminate); } }
    public bool hasEliminate { get { return HasComponent(GameComponentsLookup.Eliminate); } }

    public void AddEliminate(bool newCanEliminate) {
        var index = GameComponentsLookup.Eliminate;
        var component = CreateComponent<EliminateComponent>(index);
        component.canEliminate = newCanEliminate;
        AddComponent(index, component);
    }

    public void ReplaceEliminate(bool newCanEliminate) {
        var index = GameComponentsLookup.Eliminate;
        var component = CreateComponent<EliminateComponent>(index);
        component.canEliminate = newCanEliminate;
        ReplaceComponent(index, component);
    }

    public void RemoveEliminate() {
        RemoveComponent(GameComponentsLookup.Eliminate);
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

    static Entitas.IMatcher<GameEntity> _matcherEliminate;

    public static Entitas.IMatcher<GameEntity> Eliminate {
        get {
            if (_matcherEliminate == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Eliminate);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEliminate = matcher;
            }

            return _matcherEliminate;
        }
    }
}
