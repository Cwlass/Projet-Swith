using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

    
    private CharacterController cControler;
    public float speed = 3.0f;
    public float rotSpeed = 3.0f;
	// Use this for initialization
	void Start () {
        cControler = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

        //Rotations
        //ransform.Rotate(0, Input.GetAxis("Horizontal") * rotSpeed, 0);

        //Movements
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        cControler.SimpleMove(forward * curSpeed);
	}
}
