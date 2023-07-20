using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVertical : MonoBehaviour
{
    public float HeightVariance = 1f;
    void Update()
    {
        transform.position +=  Vector3.up * Mathf.Sin(Time.time * 2) * Time.deltaTime * HeightVariance; 
    }
}
