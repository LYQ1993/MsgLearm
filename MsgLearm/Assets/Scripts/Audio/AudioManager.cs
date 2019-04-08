using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : ManagerBase {
    public static AudioManager _instance;

    void Awake () {
        _instance = this;
    }
 
}
