using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JackController : MonoBehaviour {


    //When the mouse hovers over the GameObject, it turns to this color (red)
    public Color mouseOverColor = Color.blue;
    //This stores the GameObject’s original color
    Color originalColor;
    //Get the GameObject’s mesh renderer to access the GameObject’s material and color
    SpriteRenderer sRend;

    public GameObject curPlug;
    public CursorController cursorCont;

    public GameObject indicatorLight;

    public GameObject textBoxPrefab;
    GameObject curTextBox;

    public Speaker curSpeaker;

    int curRamblingIndex = 0;



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

            //newPlug.transform.parent.GetComponent<WireController>().TestForMatch();
        }


        if (curPlug)
        {
            cursorCont.PickUpPlug(curPlug);

            curPlug.GetComponent<PlugController>().curJackController = null;

            curPlug = null;
        }

        if(newPlugPlaced)
        {
            curPlug = newPlug;
            curPlug.GetComponent<PlugController>().curJackController = this;
        }

    }

    void OnMouseUp()
    {
        //Debug.Log("up");
    }

    public void ReceiveNewSpeaker(Speaker newSpeaker)
    {
        curRamblingIndex = 0;

        curSpeaker = newSpeaker;

        ClearTextBoxState();
        Ramble();
    }

    void Ramble()
    {
        if (curRamblingIndex > curSpeaker.rambling.Length)
            curRamblingIndex = 0;

        Speak(curSpeaker.rambling[curRamblingIndex], 5f);

        curRamblingIndex++;

        Invoke("Ramble", 7f);
    }

    void CorrectMatchResolve()
    {
        ClearTextBoxState();

        Speak(curSpeaker.correctMatchResponse, 5f);
    }

    void MismatchResolve()
    {
        ClearTextBoxState();

        Speak(curSpeaker.wrongMatchResponse, 5f);
    }

    public void Speak(string lineToSpeak, float onScreenDuration)
    {

        Vector3 positionAdjustment = new Vector3(indicatorLight.GetComponent<SpriteRenderer>().bounds.size.x / 2f, indicatorLight.GetComponent<SpriteRenderer>().bounds.size.y / 1f, 0f);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(indicatorLight.transform.position + positionAdjustment);

        

        GameObject newTextBox = Instantiate(textBoxPrefab);
        newTextBox.transform.SetParent(GameObject.Find("Canvas").transform);
        newTextBox.GetComponent<RectTransform>().localScale = Vector3.one;
        newTextBox.GetComponent<RectTransform>().position = screenPos;
        newTextBox.GetComponentInChildren<Text>().text = lineToSpeak;

        TextBoxController newTextBoxCont = newTextBox.GetComponent<TextBoxController>();
        newTextBoxCont.displayDuration = onScreenDuration;
        newTextBoxCont.borderCol = curSpeaker.color;
        newTextBoxCont.Grow();

        curTextBox = newTextBox;

        //Destroy(newTextBox, onScreenDuration);
    }

    void ClearTextBoxState()
    {
        CancelInvoke();
        Destroy(curTextBox);
    }
}
