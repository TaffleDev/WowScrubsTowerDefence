using Unity.Hierarchy;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerDamage", menuName = "Scriptable Objects/TowerDamage")]
public class TowerData : ScriptableObject
{
    public string towerName;
    public GameObject towerPrefab;
    public int cost;
    public float range;
    public float fireRate;
    public int damage;
}
