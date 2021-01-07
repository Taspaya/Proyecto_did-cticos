using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentilacionControl : MonoBehaviour
{
    /*   
       public CameraControl cameraControl;
       private Vector3 direction;
       private Rigidbody rb;
   
   
       // Start is called before the first frame update
       void Start()
       {
           rb = cameraControl.GetComponent<Rigidbody>();
           direction = new Vector3(1f, -100f, 1);
       }
   
       // Update is called once per frame
       void Update()
       {
           
       }
   
       private void OnTriggerStay(Collider other)
       {
           //Debug.Log("Colison con VENTILACION");
           //cameraControl.speed = rb.velocity.normalized * direction.normalized;
           //A method in the CameraControl sript will reset the speed back to normal after a few seconds have passed since the collision.
           //rb.AddForce(direction.normalized, ForceMode.VelocityChange);
           rb.velocity = cameraControl.speed * direction.normalized;
           Debug.Log("VELOCIDAD es " + rb.velocity);
       }
       
   */

    public float strength;
    public Vector3 direction;
}
