using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 消息处理中心，负责消息的转发
/// ui->msgCenter->character
/// </summary>
public class MsgCenter : MonoBase {

    public static MsgCenter _instance;

    private void Awake()
    {
        _instance = this;
        gameObject.AddComponent<AudioManager>();
        gameObject.AddComponent<UIManager>();
    }

    /// <summary>
    /// 发送消息,系统里面所有的消息都通过这个方法来转发
    /// </summary>
    public void Dispatch(int areaCode,int eventCode,object message)
    {
        switch (areaCode)
        {
            case AreaCode.AUDIO:
                AudioManager._instance.Execute(eventCode,message);

                break;
            case AreaCode.CHARACTER:

                break;
            case AreaCode.Net:

                break;
            case AreaCode.GAME:

                break;
            case AreaCode.UI:



                break;
            default:
                break;
        }
    }

}
