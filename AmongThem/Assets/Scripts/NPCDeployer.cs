using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDeployer : MonoBehaviour
{
    public GameObject NPCPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(NPCWave());
    }

    private void spawnEnemy(float x)
    {
        GameObject npc = Instantiate(NPCPrefab) as GameObject;
        npc.transform.position = new Vector2(x, screenBounds.y * 2);

        // Selects sprite (team) and rank and calls initialization function
        SpriteRenderer sr = npc.GetComponent<SpriteRenderer>();
        int team = Random.Range(0, 4);
        int rank = Random.Range(1, 11);
        sr.sprite = sprites[team];
        npc.GetComponent<NPC>().InitNPC(team, rank);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
