using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetUp : MonoBehaviour {
    bool setupComplete = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!setupComplete)
            if(tag == "MainCamera")
            {
                this.GetComponent<Camera>().rect = new Rect(0f, 0f, 1f, 0.5f);
                setupComplete = true;
            }
            if(tag == "Camera2")
            {
                this.GetComponent<Camera>().rect = new Rect(0f,0.5f,1f,0.5f);
                    setupComplete = true;
            }

	}
}
