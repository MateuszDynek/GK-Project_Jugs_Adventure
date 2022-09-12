using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rb;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public GameObject gameOverText;
    public GameObject finalScoreText;
    public GameObject button;
    public GameObject background;
    private Animator animator;
    private Player player;
    public float jumpHeight = 4;
    private bool grounded;
    private int maxJumpCount = 2;
    private int jumpsRemaining = 0;
    private Transform playerT;
    public GameObject[] hearts;
    private int playerLife;
    public Transform respawn_point;
    private bool killed = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
        playerT = player.transform;
        playerLife = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space)) && (jumpsRemaining>0))
        {
            
            rb.AddForce(Vector3.up * jumpHeight,ForceMode.Impulse);
            jumpsRemaining-=1;
            if(jumpsRemaining==0)
            {
                animator.SetBool("isDoubleJump",true);
            }
        }
        if (killed == true)
        {
            if(playerLife!=0)
            {
                playerT.transform.position = respawn_point.transform.position;
            }
            killed=false;
        }
    }
    
    public void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Platform" || collision.gameObject.tag=="Finish")
        {
            animator.SetBool("isFallen",true);
            animator.SetBool("isDoubleJump",false);
            animator.SetBool("isJump",false);
            grounded=true;
            jumpsRemaining = maxJumpCount;
        }
        
        
    }
    public void OnCollisionExit (Collision collision) 
    {
        if(collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Platform" || collision.gameObject.tag=="Finish")
        {
            animator.SetBool("isFallen",false);
            animator.SetBool("isJump",true);
            grounded=false;
        }
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Spikes") //sprawdzamy czy dotkniętą powierczhnią były kolce
        {
            playerLife--; //odjęcie życia graczowi
            hearts[playerLife].SetActive(false); //zmiana wyświetlanego życia
            killed = true; //smierć postacie =  true
            audioSource.clip = audioClip; //dodanie odpowiedniego dźwięku do źródła dźwięku
            audioSource.Play(); //odtworzenie dźwięku śmierci
            if (playerLife == 0) //jeżeli życie postaci spadnie do 0 wtedy wyświetlamy UI z wyborem poziomu
            {
                button.SetActive(true);
                gameOverText.SetActive(true);
                finalScoreText.SetActive(true);
                background.SetActive(true);
                player.gameObject.SetActive(false);
                
            }
        }
        
    }
}
