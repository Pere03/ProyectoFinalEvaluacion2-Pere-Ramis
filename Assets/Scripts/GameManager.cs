using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] targetPrefabs;
    private float minX = -3.75f;
    private float minY = -3.75f;
    private float distanceBetweenSquares = 2.5f;
    
    public bool isGameOver;
    private float spawnRate = 2f;
    public List<Vector3> targetPositions;
    private Vector3 randomPos;

    public TextMeshProUGUI pointsTest;

    private int score = 0;

    public GameObject gameOverPanel;

    void Start()
    {
        pointsTest.text = $"Score: {score}";

        gameOverPanel.SetActive(false);

        StartCoroutine(SpawnRandomTarget());
    }

    void Update()
    {

    }

    private Vector3 RandomSpawnPosition()
    {
        int SaltosX = Random.Range(0, 4);
        int SaltosY = Random.Range(0, 4);
        float SpawnPosX = minX + SaltosX * distanceBetweenSquares;
        float SpawnPosY = minY + SaltosY * distanceBetweenSquares;

        return new Vector3(SpawnPosX, SpawnPosY, 0);
    }

    private IEnumerator SpawnRandomTarget()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomIndex = Random.Range(0, targetPrefabs.Length);
            randomPos = RandomSpawnPosition();
            while (targetPositions.Contains(randomPos))
            {
                randomPos = RandomSpawnPosition();
            }

            Instantiate(targetPrefabs[randomIndex], randomPos, targetPrefabs[randomIndex].transform.rotation); 
            targetPositions.Add(randomPos);
        }
    }

    public void UpdateScore(int pointsToAdd)
    {
        score += pointsToAdd;
        pointsTest.text = $"Score: {score}";
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }
}
