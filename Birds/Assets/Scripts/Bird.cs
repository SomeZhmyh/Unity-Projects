using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float launchForce = 500;
    [SerializeField] float maxDragDistance = 5;

    Vector2 startPosition;
    Rigidbody2D rigidbody2D;
    SpriteRenderer spriteRenderer;
    public bool isDragging { get; private set; }

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        rigidbody2D.isKinematic = true;
        startPosition = rigidbody2D.position;

    }

    void OnMouseDown()  // if Rigidbody.simulated != true it doesn't work, why?
    {
        spriteRenderer.color = Color.red;
        isDragging = true;

    }

    void OnMouseUp()
    {
        rigidbody2D.isKinematic = false;
        spriteRenderer.color = Color.white;

        Vector2 currentPosition = rigidbody2D.position;
        Vector2 direction = startPosition - currentPosition;
        direction.Normalize();
        rigidbody2D.AddForce(direction * launchForce);
        isDragging = false;
    }

    void OnMouseDrag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desiredPosition = mousePosition;

        float distance = Vector2.Distance(desiredPosition, startPosition);
        if (distance > maxDragDistance)
        {
            Vector2 direction = desiredPosition - startPosition;
            direction.Normalize();
            desiredPosition = startPosition + (direction * maxDragDistance);
        }

        if (desiredPosition.x > startPosition.x)
            desiredPosition.x = startPosition.x;

        rigidbody2D.position = desiredPosition; //чем отличается transform.position от rigidbody2D.position
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        StartCoroutine(ResetAfterDelay());

    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(2);
        rigidbody2D.isKinematic = true;
        rigidbody2D.position = startPosition;
        rigidbody2D.velocity = Vector2.zero;
    }
}
