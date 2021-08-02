using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public static bool isDead;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (!GameplayController.isPaused)
        {
            rb.gravityScale *= -1;
            AudioManager.instance.PlaySound(AudioManager.JUMP_SOUND);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            AudioManager.instance.PlaySound(AudioManager.GAME_OVER_SOUND);
            gameObject.SetActive(false);            
            isDead = true;
        }
    }
}
