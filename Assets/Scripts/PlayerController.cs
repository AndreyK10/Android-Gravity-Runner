using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public static bool isDead;
    private bool touchedLastFrame = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
        if (touchedLastFrame && Input.touchCount == 0)
        {
            touchedLastFrame = false;
        }
        else if (!touchedLastFrame && Input.touchCount > 0)
        {
            Jump();            
            touchedLastFrame = true;
        }
    }

    private void Jump()
    {
        rb.gravityScale *= -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            gameObject.SetActive(false);            
            isDead = true;
        }
    }
}
