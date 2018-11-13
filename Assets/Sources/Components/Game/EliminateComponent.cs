using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

/// <summary>
/// 消除组件
/// </summary>
[Game]
public class EliminateComponent : IComponent
{
    public bool canEliminate;
}
