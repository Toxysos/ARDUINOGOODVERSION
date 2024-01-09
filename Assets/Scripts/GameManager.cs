using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject bird;
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private GameObject groundPrefab;

    private float startSpeed;
    private float gameSpeed;
    private float lastBuild;
    private float gameStart;
    
    // Start is called before the first frame update
    void Start()
    {
        startSpeed = 10f;
        lastBuild = 0f;
        gameStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        gameSpeed = startSpeed + (Time.time - gameStart) / 20f;
        var position = bird.transform.position;
        position = new Vector3(position.x+gameSpeed*Time.deltaTime, position.y, position.z);
        bird.transform.position = position;
        
        position = cam.transform.position;
        position = new Vector3(position.x+gameSpeed*Time.deltaTime, position.y, position.z);
        cam.transform.position = position;

        if (lastBuild < bird.transform.position.x - 15f)
        {
            Build();
            lastBuild = bird.transform.position.x;
        }
    }

    private void Build()
    {
        var pos = bird.transform.position.x;
        Instantiate(obstaclePrefabs[Random.Range(0,obstaclePrefabs.Length)], new Vector3(pos+20f, 0f, 0f), Quaternion.identity);
        Instantiate(groundPrefab, new Vector3(pos+20f, -5f, 0f), Quaternion.identity);
    }
}
