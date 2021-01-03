using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virusCloudManager : MonoBehaviour
{
    public Transform center;
    public int cant = 20;

    public float offset;

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
            Vector3 randomOffset = new Vector3(Random.Range(-offset, offset), Random.Range(-offset, offset), Random.Range(-offset, offset));
            virusCloud[i].transform.position = virusCloud[i].transform.position + randomOffset;


            //virusCloud[i].transform.rotation = Random.rotation;

            Quaternion targetRotation = Quaternion.Euler(Random.Range(-35, 35), Random.Range(145, 215), 0);
            virusCloud[i].transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 15.0f);

            float scale = Random.Range(0, 30);
            float scalef = scale / 100;
            virusCloud[i].transform.localScale *= (scale/100);

            StartCoroutine(PlayAnim(virusCloud[i],Random.Range(0,2)));
        }
    }

    IEnumerator PlayAnim(GameObject go, int time)
    {
        Animator anim = go.GetComponent<Animator>();

        yield return new WaitForSeconds(time);

        anim.SetBool("start",true);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(GetVirusLength());

            DestroyCant(6);
        }

    }

    private int GetVirusLength()
    {
        int length = 0;

        for (int i = 0; i < virusCloud.Length; i++)
            if (virusCloud[i] != null) length++;

        return length;
    }

    public void DestroyCant(int _cant)
    {
        int cant = _cant;
        if (cant > GetVirusLength()) cant = GetVirusLength();

        for(int i = 0; i < cant; i++)
            Destroy(virusCloud[--decreaser]);
    }

}
