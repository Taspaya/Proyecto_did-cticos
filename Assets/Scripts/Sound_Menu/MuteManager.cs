using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteManager : MonoBehaviour
{

    public AudioSource Awake;
    public AudioSource Slow;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Awake.mute =!Awake.mute;
            Debug.Log("música lenta");
            Slow.Play();
        }
    }
  
}
