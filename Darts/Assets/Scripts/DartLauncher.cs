using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartLauncher : MonoBehaviour
{
    [SerializeField] Dart dartPrefab;
    Dart currentDart;

    void Start()
    {
        SpawnDart();
    }

    private void SpawnDart()
    {
        currentDart = Instantiate(dartPrefab, dartPrefab.transform.position, dartPrefab.transform.rotation);
    }


    void Update()
    {
        if (currentDart != null && Input.GetButtonDown("Fire1"))
           {
             currentDart.Fire();
             currentDart = null;
             Invoke (nameof(SpawnDart), 1);
           }
    }
}
