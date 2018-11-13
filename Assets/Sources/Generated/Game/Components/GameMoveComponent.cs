//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MoveComponent move { get { return (MoveComponent)GetComponent(GameComponentsLookup.Move); } }
    public bool hasMove { get { return HasComponent(GameComponentsLookup.Move); } }

    public void AddMove(IntVector2 newTarget) {
        var index = GameComponentsLookup.Move;
        var component = CreateComponent<MoveComponent>(index);
        component.target = newTarget;
        AddComponent(index, component);
    }

    public void ReplaceMove(IntVector2 newTarget) {
        var index = GameComponentsLookup.Move;
        var component = CreateComponent<MoveComponent>(index);
        component.target = newTarget;
        ReplaceComponent(index, component);
    }

    public void RemoveMove() {
        RemoveComponent(GameComponentsLookup.Move);
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

    static Entitas.IMatcher<GameEntity> _matcherMove;

    public static Entitas.IMatcher<GameEntity> Move {
        get {
            if (_matcherMove == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Move);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMove = matcher;
            }

            return _matcherMove;
        }
    }
}
