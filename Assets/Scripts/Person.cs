using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{

    public enum State   { infected, healty, dead }
    public State curState;

    public GameObject mask;
    [SerializeField]
    private bool isMasked;

    private Transform myPlace;
    private Transform[] mapGraph;

    // Start is called before the first frame update
    void Start()
    {
        UnitsManager.Instance.IncreasePersonCount();
        CheckMask();
        mapGraph = UnitsManager.Instance.mapGraph;
        myPlace = mapGraph[Random.Range(0,mapGraph.Length)];
        UpdateColor();
        if (curState == State.infected) UnitsManager.Instance.SetInfected(gameObject.GetComponent<Person>());
        if (curState == State.healty)  UnitsManager.Instance.SetHealthy(gameObject.GetComponent<Person>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(UnitsManager.Instance.GetPlaying())RandomPatrol();
    }


    private void ChangeColor(Color color)
    {
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }

    private void UpdateColor()
    {
        switch (curState)
        {
            case State.infected:
                ChangeColor(Color.red);
                break;
           case State.healty:
                ChangeColor(Color.green);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Person")
        {
            State otherState = other.GetComponent<Person>().GetState();
            
            if (curState != State.infected && (otherState == State.infected && !other.GetComponent<Person>().GetIsMasked()))
            {
                curState = State.infected;
                UpdateColor();
                UnitsManager.Instance.GotInfected(gameObject.GetComponent<Person>());
                UImanager.Instance.UpdateTexts();
            }
        }
        else if(other.tag == "Place")
        {
            SelectRandomPlace();
        }
    }

   private void RandomPatrol()
    {
        Vector2 direction = (myPlace.position - transform.position);
        GetComponent<Rigidbody2D>().velocity = direction.normalized * 5;
    }

    private void SelectRandomPlace()
    {
        if (mapGraph.Length <= 1) 
        {
            Debug.Log("Graph is too small");
            return;
        }
        else
        {
            int rd = Random.Range(0, mapGraph.Length);
            Transform myNewPlace = mapGraph[rd];
            Debug.Log("i'm: " + name + "and my new place is: " + myNewPlace.name);
            while (myNewPlace == myPlace)
            {
                rd = Random.Range(0, mapGraph.Length);
                myNewPlace = mapGraph[rd];
            }
            myPlace = myNewPlace;
        }

    }

    private void CheckMask()
    {
        if (isMasked) mask.SetActive(true);
        else mask.SetActive(false);
    }

    public State GetState() { return curState; }
    public void SetState(State value) { curState = value; }

    public bool GetIsMasked() { return isMasked;    }
    // CHEKCS AND CHANGES THE MASK;
    public void SetIsMasked(bool value) { isMasked = value; CheckMask(); }    

}
