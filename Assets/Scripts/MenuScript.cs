using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{

    public GameObject[] Virus;
    public TextMesh[] color;
    int index;
    bool settings;
    // Start is called before the first frame update
    void Start()
    {
        settings = false;
        index = 0;

        for(int i = 0; i < 3; i++) Virus[i].GetComponent<Animator>().SetBool("nothing", true);
        updateMenu();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.DownArrow) && !settings)
        {
            index++;
            updateMenu();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !settings)
        {
            index--;
            updateMenu();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            actuate();
        }

    }


    private void updateMenu()
    {
        if (index < 0) index = 2;
        if (index > 2) index = 0;
        Debug.Log(index);
        for(int i = 0; i < 3; i++)
        {
            if (i == index)
            {
                Virus[i].GetComponent<Animator>().SetBool("nothing", false);
                color[i].color = Color.red;
            }
            else
            {
                Virus[i].GetComponent<Animator>().SetBool("nothing", true);
                color[i].color = Color.yellow;
            }
        }

    }


    private void actuate()
    {
        switch (index)
        {
            case 0: // Play 
                SceneManager.LoadScene("MainScene");
                break;
            case 1: // Settings
                Debug.Log("Settings");
                if (!settings)
                {
                    settings = true;
                    GetComponent<Animator>().SetBool("settings", true);
                }
                else
                {
                    settings = false;
                    GetComponent<Animator>().SetBool("settings", false);
                }    
                break;
            case 2: //Quit

                Application.Quit();
                break;
            default:
                break;
        }

    }
}
