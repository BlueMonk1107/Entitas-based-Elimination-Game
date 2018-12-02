using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Entitas.CodeGeneration.Attributes;

[Game,Event(EventTarget.Self)]
public class AudioComponent : IComponent
{
    public string path;
}
