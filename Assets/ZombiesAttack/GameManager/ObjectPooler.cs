using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler instance;

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    [SerializeField] private List<Pool> pools;
    private Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        instance = this;
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject Spawn(string tag, Vector2 pos, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist!");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.SetPositionAndRotation(pos, rotation);

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    public void DisableObjects()
    {
        foreach (var pool in poolDictionary)
        {
            foreach (var obj in pool.Value)
            {
                obj.gameObject.SetActive(false);
            }
        }
    }
}
