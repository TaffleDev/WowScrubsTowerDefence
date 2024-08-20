using UnityEngine;

[CreateAssetMenu(fileName = "EnemyHealth", menuName = "Scriptable Objects/EnemyHealth")]
public class EnemyHealth : ScriptableObject
{

    public string enemyName;
    public int health;
    public float moveSpeed;

}
