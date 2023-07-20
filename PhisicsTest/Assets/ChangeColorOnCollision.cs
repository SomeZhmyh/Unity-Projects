using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnCollision : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Color randomColor = GetRandColor();
        GetComponent<Renderer>().material.color = randomColor;
    }

    private Color GetRandColor()
    {
        return new Color(
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f)
        );
    }
     

}
