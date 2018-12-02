using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class AudioView : MonoBehaviour, IAudioListener,IView
{
    private AudioSource _audioSource;

    public void OnAudio(GameEntity entity, string path)
    {
        if (_audioSource == null)
        {
            _audioSource =  gameObject.AddComponent<AudioSource>();
        }
        _audioSource.clip = Resources.Load<AudioClip>(path);
        _audioSource.Play();
    }

    public void Link(IEntity entity, IContext context)
    {
        GameEntity gameEntity = entity as GameEntity;
        gameEntity.AddAudioListener(this);
    }
}
