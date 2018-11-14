//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly GetSameColorComponent getSameColorComponent = new GetSameColorComponent();

    public bool isGetSameColor {
        get { return HasComponent(GameComponentsLookup.GetSameColor); }
        set {
            if (value != isGetSameColor) {
                var index = GameComponentsLookup.GetSameColor;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : getSameColorComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherGetSameColor;

    public static Entitas.IMatcher<GameEntity> GetSameColor {
        get {
            if (_matcherGetSameColor == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GetSameColor);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGetSameColor = matcher;
            }

            return _matcherGetSameColor;
        }
    }
}
