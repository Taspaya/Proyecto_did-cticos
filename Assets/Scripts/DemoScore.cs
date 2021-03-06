﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScore : MonoBehaviour
{
    
    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        
        scoreManager.ScorePLife = PlayerPrefs.GetInt("ScorePLife", 0);
        scoreManager.ScoreVLife = PlayerPrefs.GetInt("ScoreVLife", 0);

        scoreManager.ScoreVLife = 100;
        scoreManager.ScorePLife = 0;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonUp(0))
        {

            scoreManager.ScorePLife = scoreManager.ScorePLife + 1;
        }
       /* if (scoreManager.ScoreVLife >= 1) { 

            if (Input.GetKey(KeyCode.DownArrow))
            {
            scoreManager.ScoreVLife = scoreManager.ScoreVLife - 1;
            } 
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Contagiable")
        {
            Debug.Log("COLISON CON PERSONA " + this.gameObject.name);

            scoreManager.ScorePLife = scoreManager.ScorePLife + 1;

            //collision.gameObject.GetComponentInChildren<virusCloudManager>().DestroyCant(damage);

            Destroy(this.gameObject);
        }
    }
}
