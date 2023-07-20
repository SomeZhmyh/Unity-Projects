using UnityEngine;

public class MoveStump : MonoBehaviour
{
    public float Speed = 1;
    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * Speed, Space.World);

        if(transform.position.x < -15)
        {
            transform.position += new Vector3 (28, 0, 0);
            ShowRandomSprite();
            //enemy?.Respawn();
        }
    }

    private void ShowRandomSprite()
    {
        int index = UnityEngine.Random.Range(0, 3);
        int childCount = transform.childCount; //почему метод childCount содeржится в transform?

        for (int i = 0; i < childCount; i ++ )
        {
            Transform child = transform.GetChild(i);
            child.gameObject.SetActive(index == i);
        }
    }

    private void OnEnable()
    {
        ShowRandomSprite();
    }
}
