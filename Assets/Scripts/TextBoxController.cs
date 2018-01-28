using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxController : MonoBehaviour {

    public Vector3 worldPos;

    public float growTime = 0.5f;
    public float shrinkTime = 0.5f;

    public float displayDuration = 5f;

    public Color borderCol = Color.red;

	// Use this for initialization
	void Start () {
        transform.localScale = Vector3.zero;

        if (borderCol == Color.clear)
            borderCol = Color.red;

        GetComponent<Image>().color = borderCol;
        transform.GetChild(1).GetComponentInChildren<Image>().color = borderCol;

        //Grow();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Grow()
    {
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", 0f,
            "to", 1f,
            "time", growTime,
            "easetype", "easeOutBack",
            "onUpdate", "UpdateSize",
            "onComplete", "Shrink"
        ));
    }


    public void Shrink()
    {
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", 1f,
            "to", 0f,
            "time", shrinkTime,
            "delay", displayDuration,
            "easetype", "easeInBack",
            "onUpdate", "UpdateSize",
            "onComplete", "DestroySelf"
        ));
    }

    public void ShrinkImmediate()
    {
        iTween.Stop(gameObject);

        iTween.ValueTo(gameObject, iTween.Hash(
            "from", transform.localScale.x,
            "to", 0f,
            "time", shrinkTime / 2f,
            "easetype", "easeInBack",
            "onUpdate", "UpdateSize",
            "onComplete", "DestroySelf"
        ));
    }

    public void UpdateSize(float newScale)
    {
        GetComponent<RectTransform>().localScale = Vector3.one * newScale;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void MoveToScreenPoint(Vector3 worldPos){

    }
}
