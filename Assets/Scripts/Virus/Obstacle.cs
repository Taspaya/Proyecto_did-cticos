using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Obstacle : MonoBehaviour
{
    public AudioSource hitSound;

    public int damage;


    public ScoreManager scoreManager;
    public CameraControl cameraControl;
    public int myPosition; // It will progress between 1, 2 3 and 4, then return to 1. When it is 1, it will move up. When it is 2 it will move left. When it is 3, it will move down. When it is 4, it will move right.
    public float speedControl;

    // Start is called before the first frame update
    void Start()
    {
        hitSound = GetComponent<AudioSource>();
        scoreManager = FindObjectOfType<ScoreManager>();
        cameraControl = FindObjectOfType<CameraControl>();
        

        
        damage = 10;
        //knockback = 1;
        //impactRange = 1;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLISON CON OBSTACULO " + this.gameObject.name);
        hitSound.Play();
        scoreManager.ScoreVLife -= damage;
        cameraControl.speed = -50; //A method in the CameraControl sript will reset the speed back to normal after a few seconds have passed since the collision.
        collision.gameObject.GetComponentInChildren<virusCloudManager>().DestroyCant(damage);

        if (scoreManager.ScoreVLife <= 0)
        {
            Debug.Log("Game Over! Show the game over screen.");
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);
        }

        //Destroy(this.gameObject);
    }

    public void movement()
    {
        

        //Debug.Log("Myposition: " + myPosition + "....." + transform.position);

        if (myPosition == 1)
        {
            transform.Translate(0, 1 * speedControl, 0);
            if (transform.position.y > 20) { myPosition = 2; }
            return;
        }

        if (myPosition == 2)
        {
            transform.Translate(1 * speedControl, 0, 0);
            if (transform.position.x > 20) { myPosition = 3; }
            
            return;
        }

        if (myPosition == 3)
        {
            transform.Translate(0, -1 * speedControl, 0);
            if (transform.position.y < 0) { myPosition = 4; }
            return;
        }
        if (myPosition == 4)
        {
            transform.Translate(-1 * speedControl, 0, 0);
            if (transform.position.x < 0) { myPosition = 1; }
            return;
        }

    }

}
