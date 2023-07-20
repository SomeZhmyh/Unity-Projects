using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SelectionBase]

public class Monster : MonoBehaviour
{
    [SerializeField] Sprite deadSprite;
    [SerializeField] ParticleSystem particleSystem;
    bool died;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShouldDie(collision))
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        died = true;
        GetComponent<SpriteRenderer>().sprite = deadSprite;
        particleSystem.Play();
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }

    bool ShouldDie(Collision2D collision)
    {
        if (died)
        {
            return false;
        }

        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird != null)
            return true;

        if (collision.contacts[0].normal.y < -0.5) // y < -0.5 = contacts above?
            return true;

        return false;
    }
}
