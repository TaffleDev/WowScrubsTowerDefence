using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tower : MonoBehaviour
{
    public TowerData towerData;
    public GameObject projectilePrefab; // Reference to the projectile prefab
    private float fireCooldown;
    private Transform target;

    void Start()
    {
        fireCooldown = 1f / towerData.fireRate;
    }

    void Update()
    {
        FindClosestTarget();

        if (target != null)
        {
            fireCooldown -= Time.deltaTime;

            if (fireCooldown <= 0f)
            {
                FireProjectile();
                fireCooldown = 1f / towerData.fireRate;
            }
        }
    }

    void FindClosestTarget()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, towerData.range, LayerMask.GetMask("Enemy"));

        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (Collider2D enemyCollider in enemiesInRange)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemyCollider.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemyCollider.transform;
            }
        }

        target = closestEnemy;
    }

    void FireProjectile()
    {
        if (target == null) return;

        // Instantiate the projectile
        GameObject projectileInstance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Initialize the projectile with the target and damage
        Projectile projectileScript = projectileInstance.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.Initialize(target, towerData.damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, towerData.range);
    }
}
