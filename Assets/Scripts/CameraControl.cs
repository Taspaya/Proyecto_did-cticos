using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    public Transform[] Travel;
    private int travelIndex;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        travelIndex = 0;
        rb = gameObject.GetComponent<Rigidbody>();
        direction = Travel[travelIndex].position - transform.position;
        transform.rotation = Quaternion.LookRotation(-Vector3.RotateTowards(Travel[travelIndex].position, transform.position, Time.deltaTime, 0.0f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb.velocity = speed * (direction.normalized);
        FollowTravel();

        DriveVirus();
    }


    private void FollowTravel()
    {
        if (travelIndex < Travel.Length -1 && Vector3.Distance(transform.position, Travel[travelIndex].position) <= 1) { travelIndex++; }
        direction = Travel[travelIndex].position - transform.position; 
    }

    private void DriveVirus()
    {

        float qe = -Input.GetAxis("QandE") * 90 * Time.deltaTime;
        rb.velocity = rb.velocity + new Vector3(qe * speed/3,0,0);
        Debug.Log(qe);
    }


}
