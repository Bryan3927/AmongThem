using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDeployer : MonoBehaviour
{
    public GameObject NPCPrefab;
    public GameObject FloorPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    private float nextleft;
    private float nextright;
    private float spawnrate = 4.0f;
    public Sprite[] sprites;
    public GameObject[] decorations;
    public float maxSpawnRate = 6.0f; 

    float floorspawnrate = 6.0f;
    float nextfloor;
    float nextIncrement;
    float incrementrate = 5.0f; //sec

    public GameObject player;
    private List<List<int>> people = new List<List<int>>();
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        int[] identity = player.GetComponent<PlayerMovement>().identity;
        int team = identity[0];
        int rank = identity[1];
        for (int i = 1; i < 5; ++i)
        {
            for (int j = 1; j < 11; ++j)
            {
                if (!(i == team && j == rank))
                {
                    people.Add(new List<int>() { i, j });
                }
            }
        }
        nextleft = Time.time;
        nextright = Time.time;
        nextfloor = Time.time;
        nextIncrement = Time.time;

        StartCoroutine(NPCWave());
    }

    private void spawnEnemy(float x)
    {
        GameObject npc = Instantiate(NPCPrefab) as GameObject;
        npc.transform.position = new Vector2(x, screenBounds.y * 2);

        // Selects sprite (team) and rank and calls initialization function
        SpriteRenderer sr = npc.GetComponent<SpriteRenderer>();
        int range = people.Count;
        //Debug.Log(range);
        List<int> person = people[Random.Range(0, range)];
        people.Remove(person);
        int team = person[0];
        int rank = person[1];
        // if (team < 1 || team > 4)
        // {
        //     Debug.Log(team);
        // }
        sr.sprite = sprites[team-1];
        //npc.AddComponent(typeof(Animation));
        //Animation ani = npc.GetComponent<Animation>();
        npc.GetComponent<NPC>().InitNPC(team, rank);
    }

    private void spawnFloor()
    {
        if (Time.time > nextfloor){
            GameObject floor = Instantiate(FloorPrefab) as GameObject;
            floor.transform.position = new Vector2(0, screenBounds.y * 2);
            nextfloor = Time.time + floorspawnrate;
        }
    }
    
    private void spawnDecoration()
    {
        // TODO spawn random decorations at random intervals
        if (Time.time > nextleft)
        {
            GameObject leftPlant = Instantiate(decorations[Random.Range(0, decorations.Length)]) as GameObject;
            leftPlant.transform.position = new Vector2(-10, screenBounds.y * 2);
            nextleft = Time.time + spawnrate + Random.Range(0, 5);
        }
        if (Time.time > nextright)
        {
            GameObject rightPlant = Instantiate(decorations[Random.Range(0, decorations.Length)]) as GameObject;
            rightPlant.transform.position = new Vector2(10, screenBounds.y * 2);
            nextright = Time.time + spawnrate + Random.Range(0, 5);
        }
    }

    IEnumerator NPCWave()
    {
        while(true)
        {
            
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy(-6.0f);
            spawnEnemy(0.0f);
            spawnEnemy(6.0f);
        }
    }

    public void returnPerson(List<int> person)
    {
        people.Add(person);
    }

    // Update is called once per frame
    void Update()
    {
        spawnDecoration();
        spawnFloor();
        
        if (Time.time>nextIncrement){
            spawnrate += 0.1f*(maxSpawnRate - spawnrate);
            nextIncrement = Time.time + incrementrate;
        }

    }
}
