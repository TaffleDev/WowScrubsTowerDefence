using UnityEngine;

[CreateAssetMenu(fileName = "SpawnManagerScriptableObject", menuName = "Scriptable Objects/SpawnManagerScriptableObject")]
public class SpawnManagerScriptableObject : ScriptableObject
{
    public GameObject spawnPrefab;

    public int numberOfPrefabsToCreate;
    public Vector3[] spawnPoints;
}
