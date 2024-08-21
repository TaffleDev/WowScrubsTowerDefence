using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1;
    private Transform target;

    public void Initialize(Transform enemyTarget, int projectileDamage)
    {
        target = enemyTarget;
        damage = projectileDamage;
    }

    void Update()
    {
        if (target == null)
        {
            // Destroy the projectile if the target is lost or destroyed
            Destroy(gameObject);
            return;
        }

        // Move the projectile towards the target
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Optional: Rotate the projectile to face the target
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == target)
        {
            // Deal damage to the target
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // Destroy the projectile after hitting the target
            Destroy(gameObject);
        }
    }
}
