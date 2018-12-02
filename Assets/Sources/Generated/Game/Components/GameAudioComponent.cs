//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AudioComponent audio { get { return (AudioComponent)GetComponent(GameComponentsLookup.Audio); } }
    public bool hasAudio { get { return HasComponent(GameComponentsLookup.Audio); } }

    public void AddAudio(string newPath) {
        var index = GameComponentsLookup.Audio;
        var component = CreateComponent<AudioComponent>(index);
        component.path = newPath;
        AddComponent(index, component);
    }

    public void ReplaceAudio(string newPath) {
        var index = GameComponentsLookup.Audio;
        var component = CreateComponent<AudioComponent>(index);
        component.path = newPath;
        ReplaceComponent(index, component);
    }

    public void RemoveAudio() {
        RemoveComponent(GameComponentsLookup.Audio);
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

    static Entitas.IMatcher<GameEntity> _matcherAudio;

    public static Entitas.IMatcher<GameEntity> Audio {
        get {
            if (_matcherAudio == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Audio);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAudio = matcher;
            }

            return _matcherAudio;
        }
    }
}