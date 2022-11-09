using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceableSpawner : MonoBehaviour
{
    public float spawnerLength = 3f;
    public float spawnInterval = 3f;

    [SerializeField] private GameObject sliceableObjectPrefab;

    private bool isSpawning = false;
    private float timeElapsed = 0f;

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning)
            return;

        if (timeElapsed >= spawnInterval)
        {
            Spawn();
            timeElapsed = 0f;
        }
        else
            timeElapsed += Time.deltaTime;
    }

    public void StartSpawning()
    {
        isSpawning = true;
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }

    private void Spawn()
    {
        float x_offset = Random.Range(transform.position.x - spawnerLength / 2, transform.position.x + spawnerLength / 2);

        GameObject spawned = Instantiate(sliceableObjectPrefab, null, true);
        Vector3 spawnPos = transform.position;
        spawnPos.x += x_offset;
        spawned.transform.position = spawnPos;
        spawned.transform.rotation = Random.rotation;
    }

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        Gizmos.color = Color.green;

        Gizmos.DrawWireCube(transform.position, new Vector3(spawnerLength, 1f, 1f));
#endif
    }
}
