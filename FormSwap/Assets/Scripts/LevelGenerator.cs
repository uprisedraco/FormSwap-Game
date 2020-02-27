using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject obstacle1;

    [SerializeField]
    private GameObject obstacle2;

    [SerializeField]
    private GameObject obstacle3;

    [SerializeField]
    private Vector3 spawnPoint = new Vector3(15f, 0f, 0f);

    private bool enableSpawn;

    private PlayerControl player;

    void Awake()
    {
        enableSpawn = true;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }

    void Update()
    {
        if (enableSpawn && player.playerAlive)
        {
            StartCoroutine(GenerateLevel());
        }
    }

    IEnumerator GenerateLevel()
    {
        enableSpawn = false;
        for(int i = 0; i < 20; i++)
        {
            int r = Random.Range(1, 4);
            switch (r)
            {
                case 1:
                    Instantiate(obstacle1, spawnPoint, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(obstacle2, spawnPoint, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(obstacle3, spawnPoint, Quaternion.identity);
                    break;
            }
            spawnPoint += new Vector3(19f, 0f, 0f);
        }

        yield return new WaitForSecondsRealtime(10f);
        
        enableSpawn = true;
    }
}
