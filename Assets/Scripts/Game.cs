using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game instance;
    public GameObject gameOverPanel;    
    private float timeSpent;
    private float timeSinceSpeedChange;

    public List<GameObject> FlowerPrefabs;
    
    public float speed = 1f;
    private float FLOWER_COOLDOWN = 8.0f;
    private float maxSpeed = 50f;
    private float speedIncrement = 0.5f;
    private float speedChangeInterval = 10f;
    private List<GameObject> flowers;
    private bool gameOn;

    void Start()
    {
        gameOverPanel.SetActive(false);            
        
        timeSpent = 5.0f;
        Example();

        FLOWER_COOLDOWN /=speed;
        flowers = new List<GameObject>();
        instance = this;
        gameOn = true;

    }

    void Update()
    {
        if (gameOn)
        {
            timeSpent += Time.deltaTime;
            timeSinceSpeedChange += Time.deltaTime;
            if (timeSinceSpeedChange >= speedChangeInterval && speed < maxSpeed)
            {
                speed += speedIncrement;
                timeSinceSpeedChange = 0f;
            }

            if (timeSpent > FLOWER_COOLDOWN)
            {
                timeSpent = 0;

                GameObject newFlower = generateNewFlower();
                flowers.Add(newFlower);
            }
            flowers.ForEach(flower =>
            {
                flower.transform.position -= new Vector3(Time.deltaTime * speed, 0f, 0f);
            //      flower.transform.Translate(Time.deltaTime * speed, 0,0, Space.World);
            //      flower.transform.velocity = new Vector2(bee_speed * move_x, bee_speed * move_y);
            if (flower.transform.position.x <= -15)
                {
                    flowers.Remove(flower);
                    DestroyImmediate(flower);
                }
            });
        }
        else
        {

        }
        
        

    }

    GameObject generateNewFlower()
    {
        float multiplier = Random.Range(-5f, 0f);
            
        GameObject randomFlowerPrefab = FlowerPrefabs[Random.Range(0, FlowerPrefabs.Count)];

        float randomDistance = Random.Range(5, 15);
        
        Vector3 fPos =  new Vector3(15 + randomDistance, multiplier, 0f);
        GameObject flower = Instantiate(randomFlowerPrefab, fPos,Quaternion.identity);

        return flower;
        
    }
    IEnumerator Example()
    {
        yield return new WaitUntil(() =>Input.GetKeyDown("return"));
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);

    }
    public void Restart()
    {
        Time.timeScale = 0;
        gameOn = false;
        foreach (GameObject flower in flowers)
        {
            GameObject.Destroy(flower);
        }
        StartCoroutine(Example());
        gameOverPanel.SetActive(true);
    }


}
