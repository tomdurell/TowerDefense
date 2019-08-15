using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour {

    public Transform enemy;

    public float waveInterval = 5f;
    public Text waveCountUI;

    private float timer = 3.7f;
    private int waveLevel = 0;
    

    public Transform enemySpawn;
    void Update ()
    {
        
        if (timer <= 0f)
        {
            StartCoroutine(SpawnWave());
            timer = waveInterval;
        }

        timer -= Time.deltaTime;
        waveCountUI.text = ((int)Mathf.Floor(timer)).ToString();
    }

    IEnumerator SpawnWave()
    {
        
        waveLevel++;
        for (int i = 0; i < waveLevel; i++)
        {
            Debug.Log("SPAWNING");
            SpawnEnemy();
            yield return new WaitForSeconds(0.25f);
        }
        

    }

    void SpawnEnemy()
    {
        Instantiate(enemy, enemySpawn.position, enemySpawn.rotation);
    }

}
