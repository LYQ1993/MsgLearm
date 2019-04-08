using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBase {
    
    /// <summary>
    /// 自身关心的消息集合
    /// </summary>
    List<int> list = new List<int>();

    /// <summary>
    /// 绑定一个或多个消息
    /// </summary>
    /// <param name="eventCodes"></param>
    protected void Bind(params int[] eventCodes)
    {
        list.AddRange(eventCodes);
        UIManager._instance.Add(list.ToArray(), this);
    }

    /// <summary>
    /// 解除绑定一个或多个消息
    /// </summary>
    /// <param name="eventCodes"></param>
    protected void UnBind()
    {
        UIManager._instance.Remove(list.ToArray(), this);
        list.Clear();
    }

    private void OnDestroy()
    {
        if (list != null)
        {
            UnBind();
        }
    }

    //发消息
    public void Dispatch(int areaCode, int eventCode, object message)
    {
        MsgCenter._instance.Dispatch(areaCode, eventCode, message);
    }
}
