using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text TextScoreUIP;
    [SerializeField] Text TextScoreUIV;
    public Image LifeBar;
    private int scoreVirus;
    private int scorePerson;
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
}
