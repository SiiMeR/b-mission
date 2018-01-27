using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game instance;
    private float timeSpent;
    private float timeSinceSpeedChange;

    public List<GameObject> FlowerPrefabs;
    
    public float flowerDistance = 1f;
    public float speed = 1f;
    private float FLOWER_COOLDOWN = 5.0f;
    private float maxSpeed = 50f;
    private float speedIncrement = 0.5f;
    private float speedChangeInterval = 10f;
    private List<GameObject> flowers;

    void Start()
    {
        FLOWER_COOLDOWN /=speed;
        flowers = new List<GameObject>();
        instance = this;
        for (int i = 0; i < 3; i++)
        {
            float multiplier = Random.Range(-5f, 0f);
            
            GameObject randomFlowerPrefab = FlowerPrefabs[Random.Range(0, FlowerPrefabs.Count)];
            Vector3 pos =  new Vector3(5 + flowerDistance *  i, multiplier, 0f);
            
            GameObject flower = Instantiate(randomFlowerPrefab, pos,Quaternion.identity); 
            flowers.Add(flower);
           
            
        }
    }

    void Update()
    {
        timeSpent += Time.deltaTime;
        timeSinceSpeedChange += Time.deltaTime;
        if (timeSinceSpeedChange >= speedChangeInterval && speed < maxSpeed)
        {
            speed += speedIncrement;
            timeSinceSpeedChange = 0f;
        }
        foreach (GameObject flower in flowers)
        {
            flower.transform.position -= new Vector3(Time.deltaTime * speed, 0f, 0f);
            if (flower.transform.position.x <= -15 && timeSpent > FLOWER_COOLDOWN)
            {   
                timeSpent = 0;
                float multiplier = Random.Range(-5f, 0f);
                flower.transform.position = new Vector3(16f, multiplier, 0f);
            }
        }

    }
    private void OnBecameInvisible()
    {
        
    }
    public void Restart()
    {
        foreach (GameObject flower in flowers)
        {
            GameObject.Destroy(flower);
        }
        Start();
    }


}
