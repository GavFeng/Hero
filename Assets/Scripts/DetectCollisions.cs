using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private int eggHits = 0;
    private float health = 100f;
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Overides OnTrigger to check and remove objects that collided 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.UpdateEnemyCount(-1);
            GameManager.Instance.IncreaseEnemiesTouched();
            GameManager.Instance.IncreaseEnemiesDestroyed();
            Destroy(gameObject); 
        }
        else if (other.CompareTag("Projectile"))
        {
            HandleEggCollision();
            Destroy(other.gameObject);
        }
    }

    private void HandleEggCollision()
    {
        eggHits++;
        health *= 0.8f;
        GameManager.Instance.DecreaseEggCount();
        Color color = spriteRenderer.color;
        color.a *= 0.8f;
        spriteRenderer.color = color;

        if (eggHits >= 4)
        {
            GameManager.Instance.IncreaseEnemiesDestroyed();
            GameManager.Instance.UpdateEnemyCount(-1);
            Destroy(gameObject);
        }
    }
}
