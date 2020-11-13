using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{

    public int damage;


    public ScoreManager scoreManager;
    public CameraControl cameraControl;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        cameraControl = FindObjectOfType<CameraControl>();

        //damage = 10;
        //knockback = 1;
        //impactRange = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        scoreManager.ScoreVLife -= damage;
        cameraControl.speed = -20; //A method in the CameraControl sript will reset the speed back to normal after a few seconds have passed since the collision.

        if (scoreManager.ScoreVLife <= 0)
        {
            Debug.Log("Game Over! Show the game over screen.");
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }

        //Destroy(this.gameObject);
    }

}
