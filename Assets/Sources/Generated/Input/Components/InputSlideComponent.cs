//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity slideEntity { get { return GetGroup(InputMatcher.Slide).GetSingleEntity(); } }
    public SlideComponent slide { get { return slideEntity.slide; } }
    public bool hasSlide { get { return slideEntity != null; } }

    public InputEntity SetSlide(IntVector2 newClickPos, SlideDirection newDirection) {
        if (hasSlide) {
            throw new Entitas.EntitasException("Could not set Slide!\n" + this + " already has an entity with SlideComponent!",
                "You should check if the context already has a slideEntity before setting it or use context.ReplaceSlide().");
        }
        var entity = CreateEntity();
        entity.AddSlide(newClickPos, newDirection);
        return entity;
    }

    public void ReplaceSlide(IntVector2 newClickPos, SlideDirection newDirection) {
        var entity = slideEntity;
        if (entity == null) {
            entity = SetSlide(newClickPos, newDirection);
        } else {
            entity.ReplaceSlide(newClickPos, newDirection);
        }
    }

    public void RemoveSlide() {
        slideEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public SlideComponent slide { get { return (SlideComponent)GetComponent(InputComponentsLookup.Slide); } }
    public bool hasSlide { get { return HasComponent(InputComponentsLookup.Slide); } }

    public void AddSlide(IntVector2 newClickPos, SlideDirection newDirection) {
        var index = InputComponentsLookup.Slide;
        var component = CreateComponent<SlideComponent>(index);
        component.clickPos = newClickPos;
        component.direction = newDirection;
        AddComponent(index, component);
    }

    public void ReplaceSlide(IntVector2 newClickPos, SlideDirection newDirection) {
        var index = InputComponentsLookup.Slide;
        var component = CreateComponent<SlideComponent>(index);
        component.clickPos = newClickPos;
        component.direction = newDirection;
        ReplaceComponent(index, component);
    }

    public void RemoveSlide() {
        RemoveComponent(InputComponentsLookup.Slide);
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

    static Entitas.IMatcher<InputEntity> _matcherSlide;

    public static Entitas.IMatcher<InputEntity> Slide {
        get {
            if (_matcherSlide == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.Slide);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherSlide = matcher;
            }

            return _matcherSlide;
        }
    }
}
