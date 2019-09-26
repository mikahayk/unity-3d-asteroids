using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    private AudioSource audioSource;


    public Text scoreText;
    public Text gameOverText;
    public Text restartGameText;

    public int score;

    public bool isGameOver;
    public bool restart;

    public GameObject hazard;
    public int hazardCount;
    public Vector3 spawnValues;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if(isGameOver)
            {
                GameOver();
                break;

            }
        }

    }


    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(SpawnWaves());
        isGameOver = false;
        restart = false;
    }

    public void UpdateScore()
    {
        if (isGameOver)
            return;

        scoreText.text = "SCORE: " + score.ToString();
    }

    public void GameOver()
    {
        gameOverText.text = "GAME OVER";
        restartGameText.text = "Press `R` to restart the game";
        isGameOver = true;
        restart = true;
    }

    public void AddScore(int newScoreValue)
    {
        audioSource.Play();
        score += newScoreValue;
        UpdateScore();
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
