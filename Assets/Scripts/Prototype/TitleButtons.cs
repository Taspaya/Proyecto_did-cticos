using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButtons : MonoBehaviour
{

    public bool instructions = false;
    public bool settings = false;
    public GameObject MainButtons;
    public GameObject instructionScreen;
    public GameObject settingsScreen;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtInstructions()
    {
        instructions = true;
        MainButtons.SetActive(false);
        instructionScreen.SetActive(true);
        
    }

    public void ButtSettings()
    {
        settings = true;
        MainButtons.SetActive(false);
        settingsScreen.SetActive(true);
    }


    public void ButtQuit()
    {
        Application.Quit();
    }

    public void ButtReturn()
    {
        instructionScreen.SetActive(false);
        settingsScreen.SetActive(false);
        MainButtons.SetActive(true);
        instructions = false;
        settings = false;
    }


}
