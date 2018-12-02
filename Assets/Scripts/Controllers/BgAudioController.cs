using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class BgAudioController : MonoBehaviour {

    public void Start()
    {
        var entity = Contexts.sharedInstance.game.CreateEntity();
        IView audio = gameObject.AddComponent<AudioView>();
        gameObject.Link(entity, Contexts.sharedInstance.game);
        audio.Link(entity, Contexts.sharedInstance.game);

        entity.ReplaceAudio("Audio/" + AudioName.Bg);
    }
}
