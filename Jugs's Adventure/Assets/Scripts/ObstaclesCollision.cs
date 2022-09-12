using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesCollision : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject player;
    public GameObject gameOverText;
    public GameObject finalScoreText;
    public GameObject button;
    public GameObject background;
    public Transform playerT;
    
    public GameObject[] hearts;
    private int playerLife;
    public Transform respawn_point;
    private bool killed = false;
    private float timePassed = 0f;
    private void Start() {
        playerLife = hearts.Length;
    }
    private void Update()
    {
        if (killed == true)
        {
            timePassed += Time.deltaTime;
            if (timePassed > 0.5f)
            {
                //if(playerLife!=0)
                //{
                    playerT.transform.position = respawn_point.transform.position;
                //}
                killed=false;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {

        playerLife--;
        hearts[playerLife].SetActive(false);
        killed = true;
        audioSource.Play();
        if (playerLife == 0)
        {
            button.SetActive(true);
            gameOverText.SetActive(true);
            finalScoreText.SetActive(true);
            background.SetActive(true);
            player.gameObject.SetActive(false);
            
        }
    }
}
