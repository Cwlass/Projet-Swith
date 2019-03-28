using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace gunMecanics
{
    public class Shooter : MonoBehaviour
    {
        public GameObject bullet;
        public GameObject barrel;
        public GameObject chainLink;
        private GameObject currentBullet;
        private bool isCharging = false;
        private string tagFlying;
        private string tagAttached;
        // Use this for initialization
        void Start()
        {
            if (this.tag == ("Player1"))
            {
                tagFlying = "bFlying";
                tagAttached = "bAttached";
            }
            if (this.tag == "Player2")
            {
                tagFlying = "bFlying2";
                tagAttached = "bAttached2";
            }
        }
        

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("escape"))
            {
                SceneManager.LoadScene(0);
            }
            if (this.tag == "Player1")
            {
                /*if (Input.GetKeyDown("r"))
                {
                    Instantiate(chainLink, barrel.transform.position,barrel.transform.rotation);
                }*/
                if (currentBullet == null)
                {
                    isCharging = false;
                }
                Vector3 position = barrel.transform.localPosition;
                if (Input.GetButtonDown("Fire1") && !isCharging)
                {
                    currentBullet = Instantiate(bullet, barrel.transform);
                    currentBullet.tag = tagAttached;
                    currentBullet.GetComponent<bulletFlight>().parent = 1;
                    isCharging = true;
                }
                if (Input.GetButtonUp("Fire1"))
                {
                    if (currentBullet != null)
                    {
                        currentBullet.transform.rotation = GameObject.FindGameObjectWithTag("MainCamera").transform.rotation;
                        currentBullet.GetComponent<bulletFlight>().isFlying = true;
                        currentBullet.GetComponent<bulletFlight>().isCharging = false;
                        isCharging = false;
                        currentBullet.transform.parent = null;
                        GameObject.FindGameObjectWithTag(tagAttached).GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward);
                        currentBullet.tag = tagFlying;
                        currentBullet = null;
                    }
                }
                if (isCharging)
                {
                    if (currentBullet.transform.localScale.x < 0.7f)
                    {
                        currentBullet.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f*0.3f);
                    }
                    else
                    {
                        currentBullet.GetComponent<bulletFlight>().canGetBigger = false;
                    }

                    currentBullet.transform.position = barrel.transform.position;
                }
            }
            if(this.tag == "Player2")
            {

                if (currentBullet == null)
                {
                    isCharging = false;
                }
                Vector3 position = barrel.transform.localPosition;
                if (Input.GetButtonDown("Fire1Joy") && !isCharging)
                {
                    currentBullet = Instantiate(bullet, barrel.transform);
                    currentBullet.tag = tagAttached;
                    currentBullet.GetComponent<bulletFlight>().parent = 2;
                    isCharging = true;
                }
                if (Input.GetButtonUp("Fire1Joy"))
                {
                    if (currentBullet != null)
                    {
                        currentBullet.transform.rotation = GameObject.FindGameObjectWithTag("Camera2").transform.rotation;
                        currentBullet.GetComponent<bulletFlight>().isFlying = true;
                        currentBullet.GetComponent<bulletFlight>().isCharging = true;
                        isCharging = false;
                        currentBullet.transform.parent = null;
                        GameObject.FindGameObjectWithTag(tagAttached).GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward);
                        currentBullet.tag = tagFlying;
                        currentBullet = null;
                    }
                }
                if (isCharging)
                {
                    if (currentBullet.transform.localScale.x < 0.7f)
                    {
                            currentBullet.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f*0.3f);   
                    }

                    currentBullet.transform.position = barrel.transform.position;
                }
            }
        }
    }
}
