using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

/// <summary>
/// 检测相同元素组件
/// </summary>
[Game]
public class DetectionSameItemComponent : IComponent
{
    public List<IEntity> sameEntitiesLeft;
    public List<IEntity> sameEntitiesRight;
    public List<IEntity> sameEntitiesUp;
    public List<IEntity> sameEntitiesDown;
}
