using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{

    [SerializeField] GameObject Player;

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
    [SerializeField] float waitTime = 10;

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
        Shield PlayerShield = Player.GetComponent<Shield>();
        GameObject Blue = Instantiate(BlueSpawn, BlueT);
        GameObject Green = Instantiate(GreenSpawn, GreenT);
        GameObject Red = Instantiate(RedSpawn, RedT);
        GameObject Yellow = Instantiate(YellowSpawn, YellowT);

        EnemyAi BlueAi = Blue.GetComponent<EnemyAi>();
        BlueAi.player = Player;
        BlueAi.playerShield = PlayerShield;
        EnemyAi GreenAi = Green.GetComponent<EnemyAi>();
        GreenAi.player = Player;
        GreenAi.playerShield = PlayerShield;
        EnemyAi RedAi = Red.GetComponent<EnemyAi>();
        RedAi.player = Player;
        RedAi.playerShield = PlayerShield;
        EnemyAi YellowAi = Yellow.GetComponent<EnemyAi>();
        YellowAi.player = Player;
        YellowAi.playerShield = PlayerShield;

        Blue.transform.position = BlueT.transform.position;
        Green.transform.position = GreenT.transform.position;
        Red.transform.position = RedT.transform.position;
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
