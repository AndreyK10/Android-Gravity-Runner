using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] private float obstacleSpeed;

    private void Start()
    {
        obstacleSpeed = Random.Range(20f, 30f);
    }

    private void Update()
    {
        transform.position += Vector3.left * obstacleSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destroyer") Destroy(gameObject);        
    }
}
