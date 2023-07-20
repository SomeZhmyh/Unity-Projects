using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dart : MonoBehaviour
{
    [SerializeField] float launchSpeed = 1;

    public void Fire()
    {
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * launchSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Dart>() != null)
        {
            SceneManager.LoadScene(0);
        }

        transform.SetParent(collision.transform);
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.isKinematic = true;

        var scoreCounter = FindObjectOfType<ScoreCounter>();
        scoreCounter.AddPoint();
    }
}
