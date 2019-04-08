using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudioCtr :AudioBase {
	 
	void Awake () {
        Bind(AudioEvent.PLAY_AUDIO);
	}

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case AudioEvent.PLAY_AUDIO:
                print("播放了"+message);
                break;
            default:
                break;
        }
    }

}
