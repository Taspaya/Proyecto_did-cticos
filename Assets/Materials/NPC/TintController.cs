using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TintController : MonoBehaviour
{
    // Start is called before the first frame update

    public float tintAmount;
    public Material tintMat;
    public float blinkSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        tintAmount = Mathf.Lerp(tintAmount, 0, Time.deltaTime * blinkSpeed);
        tintAmount = Mathf.Clamp(tintAmount, 0, 1);
        tintMat.SetFloat("_TintAmount", tintAmount);
    }
}
