using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnTime;
    private float startingSpawnTime;
    private float currentSpawnTime = 0;

    private void Start()
    {
        startingSpawnTime = spawnTime;
        InvokeRepeating(nameof(DecreaseSpawnTime), 10, 10);
    }

    private void Update()
    {
        if (currentSpawnTime <= Time.time)
        {
            SpawnEnemy();
            currentSpawnTime += spawnTime;
        }
    }

    private void SpawnEnemy()
    {
        string tag = RandomizeEnemyTag();
        Vector3 pos = RandomizePosition();

        ObjectPooler.instance.Spawn(tag, pos, Quaternion.identity);
    }

    private Vector3 RandomizePosition()
    {
        float x = Random.Range(0f, 1f);
        float y = Random.Range(0f, 1f);

        int chance = Random.Range(1, 4);
        switch (chance)
        {
            case 1:
                y = 1.1f;
                break;
            case 2:
                x = -0.1f;
                break;
            default:
                x = 1.1f;
                break;
        }

        return Camera.main.ViewportToWorldPoint(new Vector3(x, y));
    }

    private string RandomizeEnemyTag()
    {
        float chance = Random.value;

        return chance switch
        {
            > 0.9f => "Armored",
            > 0.6f => "Veteran",
            _ => "Common",
        };
    }

    private void DecreaseSpawnTime()
    {
        if (spawnTime <= 0.5f)
        {
            return;
        }

        spawnTime -= 0.1f;
    }

    public void ResetSpawnTime()
    {
        spawnTime = startingSpawnTime;
    }
}
