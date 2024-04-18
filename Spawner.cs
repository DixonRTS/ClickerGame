
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject spawnObject;
        [Range(0f, 1f)] 
        public float spawnChance;
    }

    public SpawnableObject[] objects;

    public float minSpawnRange = 1f;
    public float maxSpawnRange = 2f;

    private void OnEnable()
    {
        Invoke(nameof(Spawn),Random.Range(minSpawnRange,maxSpawnRange));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
        float spawnChance = Random.value;
        foreach (var obj in objects)
        {
            if(spawnChance < obj.spawnChance)
            {
                GameObject obstacle = Instantiate(obj.spawnObject);
                obstacle.transform.position += transform.position;
                break;
            }

            spawnChance -= obj.spawnChance;
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnRange,maxSpawnRange));
    }
}
