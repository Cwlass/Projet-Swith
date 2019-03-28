using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkSpawner : MonoBehaviour {

    public GameObject chainSpawn;
    public GameObject ChainBody;
    bool wallHit = false;
    bool spawned = false;
    bool collCheck = false;

    // Update is called once per frame
    void Update () {

            if (!wallHit)
            {
                if (!spawned)
                {
                    Instantiate(ChainBody, chainSpawn.transform.position,chainSpawn.transform.rotation);
                    spawned = true;
                }
            }
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ChainLink"))
        {
            wallHit = true;
            collCheck = true;
        }
    }
}
