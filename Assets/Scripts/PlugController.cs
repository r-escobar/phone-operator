using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugController : MonoBehaviour {

    public JackController curJackController;

    public void SetNewJackController(GameObject jackObj)
    {
        curJackController = jackObj.GetComponent<JackController>();
    }
}
