using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireController : MonoBehaviour {

    public GameObject plug1;
    public GameObject plug2;


    public GameObject wireJoint1;
    public GameObject wireJoint2;

    LineRenderer lineRend;

    public float wireJointAngle;

	// Use this for initialization
	void Start () {
        lineRend = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        lineRend.SetPosition(0, plug1.transform.position);
        lineRend.SetPosition(1, plug2.transform.position);
        
        wireJointAngle = Mathf.Atan((plug2.transform.position.y - plug1.transform.position.y) / (plug2.transform.position.x - plug1.transform.position.x));

        float angleMod = (plug2.transform.position.x - plug1.transform.position.x < 0) ? 180f : 0f;

        wireJoint1.transform.eulerAngles = new Vector3(0f, 0f, (Mathf.Rad2Deg * wireJointAngle) + (180f - angleMod));

        wireJoint2.transform.eulerAngles = new Vector3(0f, 0f, (Mathf.Rad2Deg * wireJointAngle) + angleMod);
    }


    public void TestForMatch()
    {
        // check both PlugControllers from plug1 and plug2
        // compare the names of the speakers in their respective jacks
    }
}
