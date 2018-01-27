using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackController : MonoBehaviour {


    //When the mouse hovers over the GameObject, it turns to this color (red)
    public Color mouseOverColor = Color.blue;
    //This stores the GameObject’s original color
    Color originalColor;
    //Get the GameObject’s mesh renderer to access the GameObject’s material and color
    SpriteRenderer sRend;

    public GameObject curPlug;
    public CursorController cursorCont;

    void Start()
    {
        //Fetch the mesh renderer component from the GameObject
        sRend = GetComponent<SpriteRenderer>();
        //Fetch the original color of the GameObject
        originalColor = sRend.color;
    }

    void OnMouseOver()
    {
        //Change the color of the GameObject to red when the mouse is over GameObject
        sRend.color = mouseOverColor;
    }

    void OnMouseExit()
    {
        //Reset the color of the GameObject back to normal
        sRend.color = originalColor;
    }

    void OnMouseDown()
    {
        // add receiving end of plug/jack
        GameObject newPlug = null;
        bool newPlugPlaced = false;

        if (cursorCont.curPlug)
        {
            newPlug = cursorCont.PutDownPlug();
            newPlug.transform.position = transform.position;
            newPlugPlaced = true;
        }


        if (curPlug)
        {
            cursorCont.PickUpPlug(curPlug);
            curPlug = null;
        }

        if(newPlugPlaced)
            curPlug = newPlug;
        
    }

    void OnMouseUp()
    {
        //Debug.Log("up");
    }
}
