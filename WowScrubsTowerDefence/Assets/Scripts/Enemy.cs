using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyHealth health;

    //public float moveSpeed = 2f; 

    private Transform[] pathWayPoints;
    private int wayPointIndex = 0;

    

    public void SetPath(Transform[] waypoints)
    {
        pathWayPoints = waypoints;
    }
    

    // Update is called once per frame
    void Update()
    {
        MoveAlongPath();
    }

    void MoveAlongPath()
    {
        if (wayPointIndex < pathWayPoints.Length)
        {
            Transform targetWayPoint = pathWayPoints[wayPointIndex];
            Vector3 direction = targetWayPoint.position - transform.position;
            transform.Translate(direction.normalized * health.moveSpeed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, targetWayPoint.position) < 0.1f)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
