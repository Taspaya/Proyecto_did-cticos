using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(UnitsManager.Instance.GetPlaying())
        {
            if(UnitsManager.Instance.GetInfectedsCount() == UnitsManager.Instance.GetPersonCount()) { SceneManager.LoadScene("prototype"); }
        }
    }
}
