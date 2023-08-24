using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefabToSpawn;
    
    private Vector3 spawnOffset;
    private GameObject previouslySpawnedPrefab;
    private bool canSpawnNew = false;

    private void Awake()
    {
        Enemy.OnCollidedWithEnemy += OnCollidedWithEnemy;
        Fruit.OnCollidedWithFruit += OnCollidedWithFruit;
    }

    private void OnCollidedWithEnemy()
    {
        if (!canSpawnNew)
            return;

        SpawnNewPrefab();
    }

    private void OnCollidedWithFruit()
    {
        if (!canSpawnNew)
            return;

        SpawnNewPrefab();
    }

    void Start()
    {
        SpawnNewPrefab();
    }

    private void SpawnNewPrefab()
    {
        if (previouslySpawnedPrefab != null)
        {
            Destroy(previouslySpawnedPrefab);
        }

        //Spawn first prefab
        GameObject newPrefab = Instantiate(prefabToSpawn);
        newPrefab.transform.SetParent(null);
        SetRandomSpawnOffset();
        newPrefab.transform.position = spawnOffset;
        prefabToSpawn = newPrefab;
    }

    private void SetRandomSpawnOffset()
    {
        float xOffset = Random.Range(-3, 3);
        float zOffset = Random.Range(-3, 3);

        spawnOffset = new Vector3(xOffset, 0.5f, zOffset);
    }
}
