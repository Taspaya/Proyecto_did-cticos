using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{

    [SerializeField]
    public bool X;

    private float x;
    [SerializeField]
    public bool Y;

    private float y;
    [SerializeField]
    public bool Z;

    private float z;

    [SerializeField]
    public float speed = 20;
    Material m_Material;



    // Start is called before the first frame update

    // Update is called once per frame
    private void Awake()
    {
        x = y = z = 0;
        if (X) x = 1f;
        if (Y) y = 1f;
        if (Z) z = 1f;
    }

    void Update()
    {
        transform.Rotate(Time.deltaTime * speed * x, Time.deltaTime * speed * y, Time.deltaTime * speed * z, Space.Self);

    }
}