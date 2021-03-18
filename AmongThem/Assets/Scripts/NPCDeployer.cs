using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDeployer : MonoBehaviour
{
    public GameObject NPCPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(NPCWave());
    }

    private void spawnEnemy(float x, int value)
    {
        GameObject n = Instantiate(NPCPrefab) as GameObject;
        n.transform.position = new Vector2(x, screenBounds.y * 2);
        GameObject childText = n.transform.GetChild(0).gameObject;
        textHandler script = childText.GetComponent<textHandler>();
        script.InitValue(value);
    }

    IEnumerator NPCWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy(-6.0f, Random.Range(1, 11));
            spawnEnemy(0.0f, Random.Range(1, 11));
            spawnEnemy(6.0f, Random.Range(1, 11));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
