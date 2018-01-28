using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

    Color litColor;

    public float pulseDuration = 1f;
    public float pulseTiming = 0.5f;

    public SpriteRenderer sRend;

    
    public bool pulsateOnStart = false;

    public bool pulsating = false;

	// Use this for initialization
	void Start () {
        if(pulsateOnStart)
            StartPulsating(Color.green);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartPulsating(Color litCol)
    {
        litColor = litCol;
        pulsating = true;
        PulseToColor();
    }

    public void PulseToColor()
    {
        if (!pulsating)
            return;
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", Color.white,
            "to", litColor,
            "time", pulseDuration / 2f,
            "easetype", "easeInQuad",
            "onUpdate", "UpdateColor",
            "onComplete", "PulseFromColor"
            ));
    }

    public void PulseFromColor()
    {
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", litColor,
            "to", Color.white,
            "time", pulseDuration / 2f,
            "easetype", "easeOutQuad",
            "onUpdate", "UpdateColor",
            "onComplete", "PulseToColor"
            ));
    }

    public void StopPulsating()
    {
        pulsating = false;
    }

    public void UpdateColor(Color newCol)
    {
        sRend.color = newCol;
    }
}
