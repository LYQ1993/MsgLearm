using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 每个模块的基类
///     保存自身注册的一系列消息
/// </summary>
public class ManagerBase :MonoBase {

    //处理自身消息
    public override void Execute(int eventCode, object message)
    {
        if (!dic.ContainsKey(eventCode))
        {
            Debug.LogWarning("没有注册过这个"+eventCode);
            return;
        }

        List<MonoBase> list = dic[eventCode];
        for (int i = 0; i < list.Count; i++)
        {
            list[i].Execute(eventCode, message);
        }
    } 


    //存储消息的事件码 和哪个脚本关联的字典

    //角色模块    有一个动作是移动
    //            移动模块需要关心这个事件
    //            动画模块需要关心这个事件
    //            音效模块需要关心这个事件

    private Dictionary<int, List<MonoBase>> dic = new Dictionary<int, List<MonoBase>>();


    /// <summary>
    /// 添加事件
    /// </summary>
    /// <param name="eventCode"></param>
    /// <param name="mono"></param>
    public void Add(int eventCode,MonoBase mono)
    {
        List<MonoBase> list = null;

        //之前 没有注册过
        if (!dic.ContainsKey(eventCode))
        {
            list = new List<MonoBase>();
            list.Add(mono);
            dic.Add(eventCode,list);
            return;
        }

        //之前注册过
        list = dic[eventCode];
        list.Add(mono);
    }

    /// <summary>
    /// 添加多个事件
    /// </summary>
    /// <param name="eventCode"></param>
    /// <param name="mono"></param>
    public void Add(int[] eventCode, MonoBase mono)
    {
        for (int i = 0; i < eventCode.Length; i++)
        {
            Add(eventCode[i],mono);
        }
    }

    /// <summary>
    /// 移除事件
    /// </summary>
    /// <param name="eventCode"></param>
    /// <param name="mono"></param>
    public void Remove(int eventCode, MonoBase mono)
    {
        //没注册多，警告
        if (!dic.ContainsKey(eventCode))
        {
            Debug.LogWarning("没有这个事件"+eventCode);
            return;
        }

        List<MonoBase> list = dic[eventCode];
        if (list.Count==1)
        {
            dic.Remove(eventCode);
        }
        else
        {
            list.Remove(mono);
        }

    }

    /// <summary>
    /// 移除多个事件
    /// </summary>
    /// <param name="eventCode"></param>
    /// <param name="mono"></param>
    public void Remove(int[] eventCode, MonoBase mono)
    {
        for (int i = 0; i < eventCode.Length; i++)
        {
            Remove(eventCode[i], mono);
        }
    }


}
