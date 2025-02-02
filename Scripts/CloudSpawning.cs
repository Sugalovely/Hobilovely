using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawning : MonoBehaviour
{
    [SerializeField] GameObject[] clouds;

    [SerializeField] float spawnInterval;

    [SerializeField] GameObject endPoint;

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        Prewarm();
        Invoke("AttempSpawn", spawnInterval);
    }

    void SpawnCloud(Vector3 startPos)
    {
        int randomIndex = Random.Range(0, clouds.Length);
        GameObject cloud = Instantiate(clouds[randomIndex]);

        float startY = Random.Range(startPos.y - 2f, startPos.y + 1f);
        cloud.transform.position = new Vector3(startPos.x, startY, startPos.z);

        float scale = Random.Range(.8f, 1.2f);
        cloud.transform.localScale = new Vector2(scale, scale);

        float speed = Random.Range(.5f, 1.5f);
        cloud.GetComponent<CloudFloating>().StartFloating(speed, endPoint.transform.position.x);
    }

    void AttempSpawn()
    {
        SpawnCloud(startPos);
        Invoke("AttempSpawn", spawnInterval);
    }

    void Prewarm()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 spawnPos = startPos + Vector3.right * (1 * 2);
            SpawnCloud(spawnPos);
        }
    }
}
