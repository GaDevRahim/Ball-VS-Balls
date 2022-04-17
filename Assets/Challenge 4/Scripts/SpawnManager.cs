using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject player, enemyObj, powerObj;

    int enemyCount = 0;
    int powerCount = 0;

    Vector3 posiPlayer;

    float randomX;
    float minX = 13.0f;
    float maxX = -13.0f;

    float posiY = 0.0f;

    float randomZ;
    float minZ = 22.0f;
    float maxZ = 28.5f;

    // Start is called before the first frame update
    void Start()
    {
        posiPlayer = new Vector3(0, 0, -7);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerController.gameOver)
            return;

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        powerCount = GameObject.FindGameObjectsWithTag("Powerup").Length;

        if (PlayerController.gameOver)   return;

        else if (enemyCount == 0)
        {
            CreateEnemyObject();
            ResetPlayerPosi();
        }     
        else if (powerCount == 0)
        {
            CreatePowerObject();
        }
    }

    Vector3 CreateRandomPosi()
    {
        randomX = Random.Range(minX, maxX);
        randomZ = Random.Range(minZ, maxZ);

        return new Vector3(randomX, posiY, randomZ);
    }

    void CreateEnemyObject()
    {
        Instantiate(enemyObj, CreateRandomPosi(), enemyObj.transform.rotation);
    }

    void CreatePowerObject()
    {
        Instantiate(powerObj, CreateRandomPosi(), powerObj.transform.rotation);
    }

    void ResetPlayerPosi()
    {
        player.transform.position = posiPlayer;
    }
}
