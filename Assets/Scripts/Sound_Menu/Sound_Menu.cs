using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Menu : MonoBehaviour
{
    public AudioSource click;

    public void PlayClick()
    {
        click.Play();
    }
}
