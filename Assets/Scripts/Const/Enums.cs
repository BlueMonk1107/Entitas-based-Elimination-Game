
/// <summary>
/// 鼠标操作的滑动方向
/// </summary>
public enum SlideDirection
{
    LEFT,
    RIGHT,
    UP,
    DOWN
}

public enum ExchangeState
{
    NONE,
    START,
    EXCHANGE,
    EXCHANGEBACK,
    END
}

/// <summary>
/// 特殊元素效果名称
/// </summary>
public enum ItemEffctName
{
    NONE,
    /// <summary>
    /// 消除所有同色元素
    /// </summary>
    ELIMINATE_SAME_COLOR,
    /// <summary>
    /// 消除行
    /// </summary>
    ELIMINATE_HORIZONTAL,
    /// <summary>
    /// 消除列
    /// </summary>
    ELIMINATE_VERTICAL,
    /// <summary>
    /// 爆炸
    /// </summary>
    EXPLODE
}