using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    public float fragility = 1f;
    public int player;
    private GameObject[] players;
	// Use this for initialization
	void Awake () {

        players = new GameObject[2];

        players = GameObject.FindGameObjectsWithTag("PlayerSet");

        int temp;

        for(int i = 0; i< players.Length; i++)
        {
            temp = i + 1;
            players[i].tag = ("Player"+temp.ToString());
        }
        if(tag == "Player1")
        {
            this.GetComponentInChildren<Camera>().tag = "MainCamera";
            player = 1;
        }
        if(tag == "Player2")
        {
            this.GetComponentInChildren<Camera>().tag = "Camera2";
            player = 2;
        }
	}
	
	// Update is called once per frame
	void Update () {

	}

    void controlAssign()
    {
    }
}
