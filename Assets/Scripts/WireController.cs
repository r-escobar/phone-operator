using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireController : MonoBehaviour {

    public GameObject plug1;
    public GameObject plug2;

    public GameObject wireTap;

    LineRenderer lineRend;

	// Use this for initialization
	void Start () {
        lineRend = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        lineRend.SetPosition(0, plug1.transform.position);
        lineRend.SetPosition(1, plug2.transform.position);

        wireTap.transform.position = (plug1.transform.position + plug2.transform.position) / 2f;
        
        float wireTapAngle = Mathf.Atan((plug2.transform.position.y - plug1.transform.position.y) / (plug2.transform.position.x - plug1.transform.position.x));
        wireTap.transform.eulerAngles = new Vector3(0f, 0f, Mathf.Rad2Deg * wireTapAngle);
    }
}
