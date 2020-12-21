using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text TextScoreUIP;
    [SerializeField] Text TextScoreUIV;
    public Image LifeBar;
    private int scoreVirus;
    private int scorePerson;



    public GameObject Player;
    public GameObject Target;



    void Update()
    {
        if (Vector3.Distance(Player.transform.position, Target.transform.position) < 20)
        {
            StageClear();
        }
    }

    public int ScoreVLife
    {
        get { return scoreVirus; }
        set
        {
            scoreVirus = value;

            TextScoreUIV.text = ScoreVLife.ToString();

            LifeBar.rectTransform.localScale = new Vector3((float)value /100,1,1);

            PlayerPrefs.SetInt("ScoreVLife", ScoreVLife);
        }
    }

    public int ScorePLife
    {
        get { return scorePerson; }
        set
        {
            scorePerson = value;

            TextScoreUIP.text = ScorePLife.ToString();

            PlayerPrefs.SetInt("ScorePLife", ScorePLife);
        }
    }

    public void StageClear()
    {
        Debug.Log("YOU WIN!");
        int currentStage = SceneManager.GetActiveScene().buildIndex;
        if (currentStage == SceneManager.sceneCountInBuildSettings-1)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentStage + 1);

        }
    }
}
