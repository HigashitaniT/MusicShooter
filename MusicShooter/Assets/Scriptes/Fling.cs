using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fling : MonoBehaviour {
	
    public float flySpeed = 1;

    public enum ObjColor
    {
        yellow,
        blue,
        green
    }
    public ObjColor objColor;

    Rigidbody rg;

    ObjController objC;

    void Start ()
    {
        rg = GetComponent<Rigidbody>();
        objC = GameObject.Find("ObjController").GetComponent<ObjController>();
        rg.AddForce(-transform.forward * flySpeed);
    }
	// Update is called once per frame
	void Update () {
        switch(objColor)
        {
            case ObjColor.yellow:
                transform.localScale = new Vector3(objC.Low(),transform.localScale.y, transform.localScale.z);
                break;

            case ObjColor.blue:
                transform.localScale = new Vector3(transform.localScale.x, objC.Mid(), transform.localScale.z);
                break;

            case ObjColor.green:
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, objC.High());
                break;
        }
        
        

	}
}
