using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour {

    public GameObject curPlug;
    public Texture2D cursorTexture;
    public Vector2 cursorPos;

	// Use this for initialization
	void Start () {
        QualitySettings.vSyncCount = 0;
        Cursor.SetCursor(cursorTexture, cursorPos, CursorMode.ForceSoftware);
    }
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        if(curPlug)
        {
            curPlug.transform.position = mouseWorldPos;
        }
	}

    public void PickUpPlug(GameObject newPlug)
    {
        if(!curPlug)
            curPlug = newPlug;
    }

    public GameObject PutDownPlug()
    {
        GameObject placedPlug = curPlug;
        curPlug = null;
        return placedPlug;
    }
}
