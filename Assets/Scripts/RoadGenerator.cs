using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoadGenerator : MonoBehaviour
{   
    public GameObject player;
    public PlayerManager pm;

    public GameObject[] rps;
    private List<GameObject> roads = new List<GameObject>();
    private int tileIndex;
    public int maxRoadCount = 5;

    public float maxSpeed = 10;
    public float speed = 0;
    public float accelerationCoefficient = 0.2f;
    public float currentSpeed;
    
    
    
    
    void Start()
    {
        ResetLevel();
    }

    void Update()
    {
        if (speed == 0) return;

        foreach (GameObject road in roads)
        {
            road.transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        }

        if (roads[0].transform.position.z < -65)
        {
            Destroy(roads[0]);
            roads.RemoveAt(0);

            CreateNextRoad();
        }
        if (speed < maxSpeed)
        {
            speed +=accelerationCoefficient * Time.deltaTime;
        }
              
    }

    private void CreateNextRoad()
    {
        tileIndex = Random.Range(0, rps.Length);
        Vector3 pos = Vector3.zero;
        if(roads.Count>0) { pos = roads[roads.Count - 1].transform.position + new Vector3(0, 0, 65); }
       GameObject go = Instantiate(rps[tileIndex], pos, Quaternion.identity);
        go.transform.SetParent(transform);
        roads.Add(go);
        Debug.Log("I create road #" + tileIndex);
    }

    public void StartLevel()
    {
        speed = 10;
        SwipeManager.instance.enabled = true;
    }

    public void ResumeLevel()
    {
        speed = currentSpeed;
        SwipeManager.instance.enabled = false;
    }
    public void PauseLevel()
    {
        currentSpeed = speed;
        speed = 0;
        SwipeManager.instance.enabled = false;
    }
    public void ResetLevel()
    {
        speed = 0;
        while(roads.Count > 0)
        {
            Destroy(roads[0]);
            roads.RemoveAt(0);

            player.transform.position = new Vector3(0, 0.5f, 0);
            pm.coinsCounter.text = ("0");
            pm.coinsCount = 0;
        }
        for(int i=0;i<maxRoadCount;i++)
        {
            CreateNextRoad();
        }
        SwipeManager.instance.enabled = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
