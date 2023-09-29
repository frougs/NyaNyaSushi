using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Collider spawnArea;

    public GameObject[] sushiPrefabs;

    public float minSpawnDelay = 0.25f;

    public float maxSpawnDelay = 1f;

    public float minAngle = -15f;

    public float maxAngle = 15f;

    public float minForce = 10f;

    public float maxForce = 22f;

    public float maxLifetime = 5f; // Changed from maxlifetime to maxLifetime

    private void Awake()
    {
        spawnArea = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawn()
    {
        while (enabled)
        {
            GameObject sushiPrefab = sushiPrefabs[Random.Range(0, sushiPrefabs.Length)]; // Changed sushi to sushiPrefab

            Vector3 position = new Vector3();
            position.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            position.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
            position.z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);

            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));

            GameObject sushi = Instantiate(sushiPrefab, position, rotation); // Changed prefab to sushiPrefab
            Destroy(sushi, maxLifetime); // Changed maxlifetime to maxLifetime

            float force = Random.Range(minForce, maxForce);
            sushi.GetComponent<Rigidbody>().AddForce(sushi.transform.up * force, ForceMode.Impulse);

            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }
}
