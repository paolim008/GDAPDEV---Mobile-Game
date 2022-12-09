using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject BlueSpawn;
    [SerializeField] private GameObject GreenSpawn;
    [SerializeField] private GameObject RedSpawn;
    [SerializeField] private GameObject YellowSpawn;

    [SerializeField] private Transform BlueT;
    [SerializeField] private Transform GreenT;
    [SerializeField] private Transform RedT;
    [SerializeField] private Transform YellowT;

    private bool spawnCooldown;
    private IEnumerator spawnCouroutine;
    private float waitTime = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnMinionsCondition();
    }

    void SpawnMinionsCondition()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 1 && GameObject.Find("BossEnemy"))
        {
            StartCoroutine(SpawningTime(waitTime));
        }
        else
        {
            StopCoroutine(SpawningTime(waitTime));
        }

    }

    private void Spawn()
    {
        GameObject Blue = Instantiate(BlueSpawn, BlueT);
        Blue.transform.position = BlueT.transform.position;
        GameObject Green = Instantiate(GreenSpawn, GreenT);
        Green.transform.position = GreenT.transform.position;
        GameObject Red = Instantiate(RedSpawn, RedT);
        Red.transform.position = RedT.transform.position;
        GameObject Yellow = Instantiate(YellowSpawn, YellowT);
        Yellow.transform.position = YellowT.transform.position;
    }

    IEnumerator SpawningTime(float waitTime)
    {
        Debug.Log("Spawning!");
        yield return new WaitForSeconds(waitTime);
        Spawn();
        StopAllCoroutines();
    }
}