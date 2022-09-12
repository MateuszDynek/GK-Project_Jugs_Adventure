using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 12f;

    private Animator animator;
    public GameObject player;
    private bool clickedRight = false;
    private int tick = 0;
    private float previousDirection = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            clickedRight = true;
            tick = 2;
        }
        if (tick == 0 || tick > 1)
        {
            if (!clickedRight)
            {
                tick = 1;
            }
            var direction = Input.GetAxis("Horizontal");

            Vector3 velocity = new Vector3(0, 0, 0);

            if (direction > 0)
            {
                velocity = Vector3.forward * direction * speed;
            }
            else if (direction < 0)
            {
                velocity = Vector3.back * direction * speed;
            }

            // rotate player around if it moved the other direction
            if (direction > 0 && previousDirection < 0 || direction < 0 && previousDirection > 0)
            {
                transform.RotateAround(transform.position, new Vector3(0, 1, 0), 180);
            }

            // save previous moving direction
            if (direction != 0)
            {
                previousDirection = direction;
            }

            // change position
            transform.Translate(velocity * Time.deltaTime);

            // animate
            animator.SetFloat("Speed", velocity.z);

        }

    }
}
