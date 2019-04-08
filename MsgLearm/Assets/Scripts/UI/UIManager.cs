using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : ManagerBase
{

    public static UIManager _instance;

    void Awake()
    {
        _instance = this;
    }
}
