using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLine : MonoBehaviour
{
    LineRenderer lineRenderer;
    Bird bird;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        bird = FindObjectOfType<Bird>();
        //Vector3 lineZeroPosition = new Vector3(bird.transform.position.x, bird.transform.position.y, -0.1f);
        lineRenderer.SetPosition(0, bird.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.isDragging)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(1, bird.transform.position);
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
}
