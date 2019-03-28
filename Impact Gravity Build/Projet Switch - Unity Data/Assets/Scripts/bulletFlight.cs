using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace gunMecanics
{
    public class bulletFlight : MonoBehaviour
    {

        [HideInInspector]
        public bool isFlying;
        [HideInInspector]
        public bool isCharging = true;

        public float speed = 20f;

        public float impactStrength = 1f;

        public int parent;

        public float impactStrengthMod = 0.5f;

        public bool canGetBigger = true;
        // Use this for initialization
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
            if (isCharging)
            {
                Debug.Log("Impact strength debut " + impactStrength);
                Debug.Log(this.transform.localScale.x);
                if (canGetBigger)
                {
                    impactStrength = impactStrength + (this.transform.localScale.x);
                }
                //isCharging = false;
                Debug.Log("Impact strength fin " + impactStrength);
                
            }

            if (isFlying)
            {
                this.GetComponent<Rigidbody>().AddForce(this.transform.forward * speed);

            }
            if (Vector3.Distance(GameObject.FindGameObjectWithTag("WorldCenter").transform.position, gameObject.transform.position) > 500)
            {
                Destroy(gameObject);
            }

        }
        private void OnTriggerEnter(Collider other)
        {
            int targetParent = 0;
            if (isFlying)
            {
                if (other.tag == "bFlying")
                {
                    if (other.transform.localScale == gameObject.transform.localScale)
                    {
                        this.GetComponent<Rigidbody>().AddForce(-this.transform.forward * speed);
                    }
                    if (other.transform.localScale.x > gameObject.transform.localScale.x)
                    {
                        Destroy(gameObject);
                    }
                    if (other.transform.localScale.x < gameObject.transform.localScale.x)
                    {
                        Destroy(other.gameObject);
                    }

                }
                if (other.GetComponent<bulletFlight>())
                {
                    if (other.GetComponent<bulletFlight>().isCharging)
                    {
                        Destroy(gameObject);
                    }
                }
                if (other.GetComponent<Rigidbody>() != null || other.tag == "Gun" && targetParent == parent)
                {
                    if (other.tag == "Gun")
                    {
                        targetParent = other.transform.parent.transform.parent.GetComponent<PlayerManager>().player;
                    }
                    if (other.GetComponent<PlayerManager>())
                    {
                        targetParent = other.GetComponent<PlayerManager>().player;
                    }
                    if (other.GetComponent<PlayerManager>() || other.tag == "Gun")
                    {
                        if (other.tag == "Gun")
                        {
                            other.transform.parent.transform.parent.GetComponent<Rigidbody>().AddForce(transform.up*5, ForceMode.Impulse);
                            other.transform.parent.transform.parent.GetComponent<Rigidbody>().AddForce(
                                  transform.forward * (impactStrength + other.transform.parent.transform.parent.GetComponent<PlayerManager>().fragility), ForceMode.Impulse);
                            other.transform.parent.transform.parent.GetComponent<PlayerManager>().fragility =
                                  other.transform.parent.transform.parent.GetComponent<PlayerManager>().fragility + (Mathf.Round(impactStrength / 1.5f));
                            Debug.Log("target Fragility = " + other.transform.parent.transform.parent.GetComponent<PlayerManager>().fragility);
                            other.transform.parent.transform.parent.GetComponent<RigidBodyFPSController>().gotShot = true;
                            other.transform.parent.transform.parent.GetComponent<RigidBodyFPSController>().targetVelocity = this.transform.forward;
                        }
                        else
                        {
                            Rigidbody rb = other.GetComponent<Rigidbody>();
                            rb.AddForce(transform.up*5, ForceMode.Impulse);
                            rb.AddForce(transform.forward * (impactStrength + other.GetComponent<PlayerManager>().fragility), ForceMode.Impulse);
                            other.GetComponent<PlayerManager>().fragility =
                                  other.GetComponent<PlayerManager>().fragility + (Mathf.Round(impactStrength / 1.5f));
                            //Debug.Log("target Fragility = " + other.transform.parent.transform.parent.GetComponent<PlayerManager>().fragility);
                            other.GetComponent<RigidBodyFPSController>().gotShot = true;
                            other.GetComponent<RigidBodyFPSController>().targetVelocity = this.transform.forward;
                        }
                    }
                    else
                    {
                        other.GetComponent<Rigidbody>().AddForce(transform.forward * impactStrength);
                    }
                    Destroy(gameObject);

                }
            }
        }
         
        }
    }
