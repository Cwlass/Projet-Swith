using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeathZone : MonoBehaviour {

    private GameObject player1;
    private GameObject player2;
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    private bool playersSet=false;
    public Text winText;
    private bool deadPlayer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        if(deadPlayer)
        {
            winText.enabled = true;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            if (other.CompareTag("Player1"))
            {
                other.transform.position = spawnPoint1.transform.position;
            }
            if (other.CompareTag("Player2"))
            {
                other.transform.position = spawnPoint2.transform.position;
            }
        }
    }
}
