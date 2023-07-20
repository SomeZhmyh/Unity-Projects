using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var position = new Vector2 (transform.position.x + 2, transform.position.y); 
            var projectile = Instantiate(projectilePrefab, position, projectilePrefab.transform.rotation);
        }
    }
}
