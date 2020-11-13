using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;



    //public Transform[] Travel;
    private int travelIndex;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody>();
        speed = 20;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb.velocity = speed * (direction.normalized);
        //FollowTravel();

        //DriveVirus();
        advance();
        speedRecoveryAfterBump();
    }


    private void FollowTravel()
    {
        //if (travelIndex < Travel.Length -1 && Vector3.Distance(transform.position, Travel[travelIndex].position) <= 1) { travelIndex++; }
        //direction = Travel[travelIndex].position - transform.position; 
    }

    private void DriveVirus()
    {

        float qe = -Input.GetAxis("QandE") * 90 * Time.deltaTime;
        rb.velocity = rb.velocity + new Vector3(qe * speed/3,0,0);
        //Debug.Log(qe);
    }

    private void advance()
    {
        //transform.Translate(new Vector3(0, 0, 1));
        GetComponent<Rigidbody>().AddRelativeForce(0, 0, speed);
    }

    void speedRecoveryAfterBump()
    {
        if (speed < 20) { speed++;}
    }


}
