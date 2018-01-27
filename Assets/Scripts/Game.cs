using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Game : MonoBehaviour
{
    public static Game instance;
    public GameObject gameOverPanel;   
    private float timeSpent;  
    
    private float timeSpentLayer1;
    private float timeSpentLayer2;

    private float timeSinceSpeedChange;
    public Image black;
    public Text text;

    public List<GameObject> FlowerPrefabs;
    
    public float speed = 1f;
    private float FLOWER_COOLDOWN = 8.0f;
    private float maxSpeed = 50f;
    private float speedIncrement = 0.5f;
    private float speedChangeInterval = 10f;
    
    private List<GameObject> layer1Flowers;
    private List<GameObject> layer2Flowers;
    
    private bool gameOn;

    private bool layer1Active;

    void Start()
    {
        if (string.IsNullOrEmpty("STOP THE FUCKING MUSIC"))
        {
            AudioManager.instance.Play("Flight of the Bumble Bee 8 bit", isLooping:true, vol:0.7f);
        }
        

        gameOverPanel.SetActive(true);
        black.canvasRenderer.SetAlpha(0.0f);
        text.canvasRenderer.SetAlpha(0.0f);


        timeSpent = 5.0f;
        gameOverPanel.SetActive(false);            
        
        timeSpentLayer1 = 4.0f;
        timeSpentLayer2 = 0f;

        
        FLOWER_COOLDOWN /=speed;
        layer1Flowers = new List<GameObject>();
        layer2Flowers = new List<GameObject>();
        instance = this;
        gameOn = true;

    }

    void manageLayer1()
    {
        timeSpentLayer1 += Time.deltaTime;
        
        if (timeSpentLayer1 > FLOWER_COOLDOWN)
        {
            timeSpentLayer1 = 0;
            GameObject newFlower = generateNewFlower();

            if (layer1Active)
            {
                setAlphaAndCollision(newFlower,true);
            }
            else
            {
                setAlphaAndCollision(newFlower,false);
            }
            layer1Flowers.Add(newFlower);
        }

        
        layer1Flowers.ForEach(flower =>
        {
            flower.transform.position -= new Vector3(Time.deltaTime * speed, 0f, 0f);

            if (flower.transform.position.x <= -15)
            {
                layer1Flowers.Remove(flower);
                DestroyImmediate(flower);
            }
        });
        
        
        
        
        
    }

    private void setAlphaAndCollision(GameObject newFlower, bool active)
    {
        var renderers = newFlower.GetComponentsInChildren<Renderer>();
                    
        foreach (var renderer in renderers)
        {
            var materialColor = renderer.material.color;
            
            materialColor.a = active ? 1.0f : 0.3f;
            
            renderer.material.color = materialColor;
        }
                    
        var bColliders = newFlower.GetComponentsInChildren<BoxCollider2D>();
                    
        foreach (var boxCollider2D in bColliders)
        {
            boxCollider2D.enabled = active;
        }
    }

    void manageLayer2()
    {
        timeSpentLayer2 += Time.deltaTime;
        
        if (timeSpentLayer2 > FLOWER_COOLDOWN)
        {
            timeSpentLayer2 = 0;
            GameObject newFlower = generateNewFlower();
            print(newFlower.transform.localScale);
            newFlower.transform.localScale = new Vector3(newFlower.transform.localScale.x-0.2f,newFlower.transform.localScale.y-0.2f,1f);

            foreach (var sr in newFlower.GetComponentsInChildren<SpriteRenderer>())
            {
                sr.sortingLayerName = "Layer_2";
            }
            if (layer1Active)
            {
                setAlphaAndCollision(newFlower,false);
            }
            else
            {
                setAlphaAndCollision(newFlower,true);
            }
            
            layer2Flowers.Add(newFlower);
        }
        
        layer2Flowers.ForEach(flower =>
        {
            flower.transform.position -= new Vector3(Time.deltaTime * speed, 0f, 0f);
            if (flower.transform.position.x <= -15)
            {
                layer2Flowers.Remove(flower);
                DestroyImmediate(flower);
            }
        });
        
        
    }
    void Update()
    {
        
        if (gameOn)
        {
            
            manageLayer1();
            manageLayer2();
            
            timeSinceSpeedChange += Time.deltaTime;
            
            if (timeSinceSpeedChange >= speedChangeInterval && speed < maxSpeed)
            {
                speed += speedIncrement;
                timeSinceSpeedChange = 0f;
            }
            
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                layer1Active = !layer1Active; // flip the active layer
            
                if (layer1Active)
                {
                
                    layer1Flowers.ForEach(flower =>
                    {
                        
                        setAlphaAndCollision(flower, true);

                    });
                    layer2Flowers.ForEach(flower =>
                    {
                      setAlphaAndCollision(flower,false);
                    
                    });
                }
                else // layer 2 active
                {
                
                    layer1Flowers.ForEach(flower =>
                    {
                       setAlphaAndCollision(flower,false);


                    });
                    layer2Flowers.ForEach(flower =>
                    {
                        setAlphaAndCollision(flower,true);
                    
                    });
                }   
            }
        }      

    } 

    GameObject generateNewFlower()
    {
        float multiplier = Random.Range(-5f, 0f);

        GameObject randomFlowerPrefab = FlowerPrefabs[Random.Range(0, FlowerPrefabs.Count)];
        float randomDistance = Random.Range(0, 10);        
        Vector3 fPos =  new Vector3(15 + randomDistance, multiplier, 0f);
        GameObject flower = Instantiate(randomFlowerPrefab, fPos,Quaternion.identity);
        return flower;
        
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        black.CrossFadeAlpha(1.0f, 1, true);
        text.CrossFadeAlpha(1.0f, 1, true);
        yield return new WaitUntil(() =>Input.GetKeyDown("return"));
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Restart()
    {
        
        gameOn = false;
        StartCoroutine(Example());
       /* foreach (GameObject flower in layer1Flowers)
        {
            GameObject.Destroy(flower);
        }*/
        
       
    }


}
