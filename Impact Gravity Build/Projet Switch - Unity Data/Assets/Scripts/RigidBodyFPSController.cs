using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]

public class RigidBodyFPSController : MonoBehaviour
{

    public float speed = 10.0f;
    public float gravity = 10.0f;
    public float maxVelocityChange = 10.0f;
    public bool canJump = true;
    public float jumpHeight = 2.0f;
    private bool grounded = false;
    public Rigidbody rBody;
    public Vector3 targetVelocity;
    public bool gotShot = false;


    void Awake()
    {
        rBody.freezeRotation = true;
        rBody.useGravity = false;
    }

    void FixedUpdate()
    {
        if (tag == "Player1")
        {

            // Calculate how fast we should be moving
                if (!gotShot)
                {
                    targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    targetVelocity = transform.TransformDirection(targetVelocity);
                    targetVelocity *= speed;
                }
                Debug.Log(targetVelocity);
                // Apply a force that attempts to reach our target velocity
                Vector3 velocity = rBody.velocity;
                Vector3 velocityChange = (targetVelocity - velocity);
                velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
                velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
                velocityChange.y = 0;
                rBody.AddForce(velocityChange, ForceMode.VelocityChange);

            // Jump
            if (grounded)
            {
                if (canJump && Input.GetButton("Jump"))
                {
                    rBody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
                }
                gotShot = false;
            }

            // We apply gravity manually for more tuning control
            rBody.AddForce(new Vector3(0, -gravity * rBody.mass, 0));

            grounded = false;
        }
        if (tag == "Player2")
        {
            if (!gotShot)
            {
                targetVelocity = new Vector3(Input.GetAxis("Horizontal2"), 0, Input.GetAxis("Vertical2"));
                targetVelocity = transform.TransformDirection(targetVelocity);
                targetVelocity *= speed;
            }
                // Apply a force that attempts to reach our target velocity
                Vector3 velocity = rBody.velocity;
                Vector3 velocityChange = (targetVelocity - velocity);
                velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
                velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
                velocityChange.y = 0;
                rBody.AddForce(velocityChange, ForceMode.VelocityChange);
            if (grounded)
            {
                // Jump
                if (canJump && Input.GetButton("JumpJoy"))
                {
                    rBody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
                }
                gotShot = false;
            }


            // We apply gravity manually for more tuning control
            rBody.AddForce(new Vector3(0, -gravity * rBody.mass, 0));

            grounded = false;
        }
    }

    void OnCollisionStay()
    {
        grounded = true;
    }

    float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }
}