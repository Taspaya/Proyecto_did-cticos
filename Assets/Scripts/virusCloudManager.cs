using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virusCloudManager : MonoBehaviour
{
    public Transform center;
    public int cant = 20;

    public int decreaser;
    public GameObject virus;

    private GameObject[] virusCloud;

    private void Awake()
    {
        decreaser = cant;
        virusCloud = new GameObject[cant];
    }
    private void Start()
    {

        for (int i = 0; i < cant; i++)
        {
            virusCloud[i] = Instantiate(virus, transform);
            virusCloud[i].name = virusCloud[i].name + i;
        }
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.A) && decreaser > 0)
        {
            destroyCant(1);
        }
               
    }

    public void destroyCant(int _cant)
    {
        for(int i = 0; i < _cant; i++)
            Destroy(virusCloud[--decreaser]);
               
    }

}
