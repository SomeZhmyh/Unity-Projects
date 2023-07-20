using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider) 
    {
        Color randomColor = GetRandColorWithAlpha();
        GetComponent<Renderer>().material.color = randomColor;
    }

    private Color GetRandColorWithAlpha()
    {
        return new Color(
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f),
            0.25f
        );
    }
}
