using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusMovement : MonoBehaviour
{
    const float MAXDISTANCE = 5;
    const float FLYVELOCITY = 100;

    private Transform center;

    private Transform newPos;



    private void Start()
    {
        newPos = transform;
        center = transform;

        center = GameObject.Find("Center").transform;
    }

    private void FixedUpdate()
    {
        RandomFly();
        GoToCenter();
        transform.position = newPos.position;
    }

    private void RandomFly()
    {
        float x, y, z;

        x = Random.Range(FLYVELOCITY, -FLYVELOCITY);
        y = Random.Range(FLYVELOCITY, -FLYVELOCITY);
        z = Random.Range(FLYVELOCITY, -FLYVELOCITY);

        newPos.position = Vector3.MoveTowards(transform.position, new Vector3(x, y, z), Time.deltaTime * FLYVELOCITY/4);

    }

    private void GoToCenter()
    {
        if (Vector3.Distance(center.transform.position, transform.position) > MAXDISTANCE)
            newPos.position = Vector3.MoveTowards(transform.position, center.position, 1f);
    }

    public void SetCenter(Transform pos) { center = pos; }
}
