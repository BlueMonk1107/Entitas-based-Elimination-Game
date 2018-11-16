using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 数据
/// </summary>
public class Data
{
    /// <summary>
    /// 特殊效果阵型数据
    /// </summary>
    public static int[][,] Formation = {
        new[,]
        {
            {1,1,1,1,1}
        },
         new[,]
        {
            {1,1,1,1}
        },
        new [,]
        {
            {0,1,0},
            {0,1,0},
            {1,1,1}
        },
        new [,]
        {
            {0,0,1},
            {0,0,1},
            {1,1,1}
        },
    };
}
