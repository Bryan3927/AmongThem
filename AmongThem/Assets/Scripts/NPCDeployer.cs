using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDeployer : MonoBehaviour
{
    public GameObject NPCPrefab;
    public GameObject FloorPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    public Sprite[] sprites;
    //public Animation[] animations;
    public GameObject player;
    private List<List<int>> people = new List<List<int>>();
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        int[] identity = player.GetComponent<PlayerMovement>().identity;
        int team = identity[0];
        int rank = identity[1];
        for (int i = 0; i < 4; ++i)
        {
            for (int j = 1; j < 11; ++j)
            {
                if (!(i == team && j == rank))
                {
                    people.Add(new List<int>() { i, j });
                }
            }
        }
        StartCoroutine(NPCWave());
    }

    private void spawnEnemy(float x)
    {
        GameObject npc = Instantiate(NPCPrefab) as GameObject;
        npc.transform.position = new Vector2(x, screenBounds.y * 2);

        // Selects sprite (team) and rank and calls initialization function
        SpriteRenderer sr = npc.GetComponent<SpriteRenderer>();
        int range = people.Count;
        Debug.Log(range);
        List<int> person = people[Random.Range(0, range)];
        people.Remove(person);
        int team = person[0];
        int rank = person[1];
        sr.sprite = sprites[team];
        //npc.AddComponent(typeof(Animation));
        //Animation ani = npc.GetComponent<Animation>();
        npc.GetComponent<NPC>().InitNPC(team, rank);
    }

    private void spawnFloor()
    {
        GameObject floor = Instantiate(FloorPrefab) as GameObject;
        floor.transform.position = new Vector2(0, screenBounds.y * 2);
    }
    
    private void spawnDecoration()
    {
        // TODO spawn random decorations at random intervals
    }

    IEnumerator NPCWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy(-6.0f);
            spawnEnemy(0.0f);
            spawnEnemy(6.0f);
            spawnFloor();
            spawnDecoration();
        }
    }

    public void returnPerson(List<int> person)
    {
        people.Add(person);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
