using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float reloadDelay = 2f;
    public GameObject levelCompleteUI;
    public void Collided()
    {
        Invoke("Reload", reloadDelay);
    }
    public void Reload()
    {
        PlayerCollisions.collisionLeft++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LivesZero()
    {
        Invoke("gameOver", reloadDelay);
    }
    public void gameOver()
    {
        PlayerCollisions.collisionLeft++;
        Lives.lives = 4;
        SceneManager.LoadScene(5);
    }

    public void LevelComplete()
    {
        levelCompleteUI.SetActive(true);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void mainMenu()
    {
        PlayerCollisions.collisionLeft++;
        Score.score = 0;
        SceneManager.LoadScene(0);
    }

}

