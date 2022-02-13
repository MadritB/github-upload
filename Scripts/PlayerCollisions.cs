using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{
    public Text score;
    public int scoreInc = 5;
    public Text livesText;
    public PlayerMovement playerMove;
    public GameObject BGMusic;
    public GameObject Crash;

    public static int collisionLeft = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "" + Lives.lives;
        score.text = "" + Score.score;
    }

    private void OnCollisionEnter(Collision other) 
    {
        if((Lives.lives > 0) && (collisionLeft > 0))
        {
            if(other.gameObject.tag == "Obstacles")
            {
                playerMove.enabled = false;
                Lives.lives--;
                collisionLeft = 0;
                Crash.SetActive(true);
                
                scoreInc = 0;
                if(Lives.lives == 0)
                {
                    FindObjectOfType<GameManager>().LivesZero();
                }
                else{
                    FindObjectOfType<GameManager>().Collided();
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Point")
        {
            Destroy(other.gameObject);
            Score.score = Score.score + scoreInc;
            score.text = "" + Score.score;
        }

        if(other.gameObject.tag == "PowerUp100")
        {
            Destroy(other.gameObject);
            Score.score += 100;
            score.text = "" + Score.score;
        }

        if(other.gameObject.tag == "PowerUpHighJump")
        {
            Destroy(other.gameObject);
            playerMove.numOfHighJumps = 1;
        }

        if(other.gameObject.tag == "EndTrigger")
        {
            Destroy(BGMusic);
            FindObjectOfType<GameManager>().LevelComplete();
        }
    }
}
