using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{

    public Text infectedText;

    public Text healthyText;

    public Text percentText;

    private static UImanager instance;
    public static UImanager Instance
    {
        get
        {
            return instance;
        }
    }

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateTexts();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTexts();
    }

    public void UpdateTexts()
    {
        infectedText.text = UnitsManager.Instance.GetInfectedsCount().ToString();
        healthyText.text = UnitsManager.Instance.GetHealtiesCount().ToString() ;

        percentText.text = Mathf.Round(UnitsManager.Instance.GetHealtiesCount() / (UnitsManager.Instance.GetPersonCount() + 0.0001f)*100).ToString() + " %";
    } 

    public void PutMask() { }
}
