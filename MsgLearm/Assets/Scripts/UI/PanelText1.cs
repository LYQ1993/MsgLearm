using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PanelText1 : UIBase {

    public Button btn;
    public Text txt;

	// Use this for initialization
	void Start () {

        btn.onClick.AddListener(onClick);
    }

    void onClick()
    {
        txt.text += 1;
        MsgCenter._instance.Dispatch(AreaCode.AUDIO,AudioEvent.PLAY_AUDIO,"5");
    }


}
