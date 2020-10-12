using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsManager : MonoBehaviour
{

    private int personCount = 0;

    private List<Person> infecteds = new List<Person>();

    private List<Person> healthies = new List<Person>();

    public Transform[] mapGraph;

    private bool playing = false;
    // Start is called before the first frame update

       
    private static UnitsManager instance;
    public static UnitsManager Instance
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

    public int SetInfected(Person value)
    {
        infecteds.Add(value);
        return infecteds.Count;
    }
    public int SetHealthy(Person value)
    {
        healthies.Add(value);
        return healthies.Count;
    }

    public void GotInfected(Person person)
    {
        healthies.Remove(person);
        infecteds.Add(person);
    }
    

    public int GetInfectedsCount() { return infecteds.Count; }
    public int GetHealtiesCount() { return healthies.Count; }

    public bool GetPlaying() { return playing; }
    public void SetPlaying(bool value) { playing = value; }

    public int GetPersonCount() { return personCount; }
    public void IncreasePersonCount() { personCount++; }
}
