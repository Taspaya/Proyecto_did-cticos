using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TintController : MonoBehaviour
{
    // Start is called before the first frame update

    public float tintAmount;
    public Material tintMat;
    public float blinkSpeed = 5f;
    public bool rojoVa = true; // Controla si se aumenta o disminuye el tinte rojo del modelo.

    // Update is called once per frame
    void Update()
    {
        if (!rojoVa)
        {
            //Debug.Log("RojoVa es " + rojoVa);

            if (tintAmount >= 0.9f)
            {
                rojoVa = true;
            }
            else
            {
                tintAmount = Mathf.Lerp(tintAmount, 1, Time.deltaTime * blinkSpeed);
                tintAmount = Mathf.Clamp(tintAmount, 0, 1); 
            }
        }
        else
        {
            //Debug.Log("RojoVa es " + rojoVa);
            if (tintAmount <= 0.1f)
            {
                rojoVa = false;
            }
            else
            {
                tintAmount = Mathf.Lerp(tintAmount, 0, Time.deltaTime * blinkSpeed);
                tintAmount = Mathf.Clamp(tintAmount, 0, 1); 
            }

        }

        tintMat.SetFloat("_TintAmount", tintAmount); 
        //Debug.Log("TintAmount es " + tintAmount);
    }
}
