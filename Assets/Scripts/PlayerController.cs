using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerNumber;

    public float speed;

    public float atkDelay;
    
    public float countAtkDelay;

    Rigidbody2D rigidbody2D;

    Animator animator;

    float lastX, lastY;
    float hAxis, vAxis;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxis("HorizontalP" + playerNumber);
        vAxis = Input.GetAxis("VerticalP" + playerNumber);

        if (Mathf.Abs(hAxis) >= 0.000000001) {
            lastX = hAxis;
            lastY = 0;
        }
        if (Mathf.Abs(vAxis) >= 0.000000001)
        {
            lastY = vAxis;
            lastX = 0;
        }

        if (countAtkDelay > atkDelay)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                countAtkDelay = 0;
                if (lastX > 0)
                {
                    PlayAnimation("atk-right");
                }
                else if (lastX < 0)
                {
                    PlayAnimation("atk-left");
                }
                else if (lastY > 0)
                {
                    PlayAnimation("atk-up");
                }
                else if (lastY < 0)
                {
                    PlayAnimation("atk-down");
                }
            }
        }
        else {
            countAtkDelay += Time.fixedDeltaTime;
        }

    }

    private void FixedUpdate()
    {
        Vector2 newPos = new Vector2(hAxis, vAxis).normalized * speed * Time.fixedDeltaTime;

        rigidbody2D.velocity = newPos;
        
        animator.SetFloat("Y", lastY);

        animator.SetFloat("X", lastX);

    }

    string currentAnimation;
    void PlayAnimation(string animation) {
        if (currentAnimation == animation)
            return;
        currentAnimation = animation;
        animator.Play(currentAnimation);
    }

    public void PlayMovimentoAnimation() {
        PlayAnimation("Movimento");
    }

}
