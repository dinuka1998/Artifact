using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float movementSpeed = 3f;
    private Rigidbody2D playerBody;
    private Vector2 moveVector;
    private SpriteRenderer playerSpritRenderer;

    private Animator playerAnimator;
    private string WALK_ANIMATION = "Walk";


    private float harvestTimer;
    private bool isHarvesting;

    private GameObject artifact;

    private string MOVEMENT_AXIS_X = "Horizontal";
    private string MOVEMENT_AXIS_Y = "Vertical";



    private void Awake() {

        playerBody = GetComponent<Rigidbody2D>();
        playerSpritRenderer =GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();

    }

    private void FixedUpdate() {
        
        if (isHarvesting) {
            playerBody.velocity = Vector2.zero;
        }
            
        else {

            moveVector = new Vector2(Input.GetAxis(MOVEMENT_AXIS_X), Input.GetAxis(MOVEMENT_AXIS_Y));

            if (moveVector.sqrMagnitude > 1) {

                 moveVector = moveVector.normalized;

            }


            playerBody.velocity =  new Vector2(moveVector.x *movementSpeed, moveVector.y * movementSpeed);
            

        }

    }

    private void Update() {

        if(Time.time > harvestTimer)
            isHarvesting = false;

        FlipSprite();
        AnimatePlayer();
        
    }

    void FlipSprite() {

        if (Input.GetAxisRaw(MOVEMENT_AXIS_X) == 1) {
            
            playerSpritRenderer.flipX = false;

        }
        else if (Input.GetAxisRaw(MOVEMENT_AXIS_X) == -1) {

            playerSpritRenderer.flipX = true;

        }

    }

    void AnimatePlayer() {

        if (Input.GetAxisRaw(MOVEMENT_AXIS_X) > 0 || Input.GetAxisRaw(MOVEMENT_AXIS_X) < 0 ||Input.GetAxisRaw(MOVEMENT_AXIS_Y) > 0 || Input.GetAxisRaw(MOVEMENT_AXIS_Y) < 0) {
        
            playerAnimator.SetBool(WALK_ANIMATION, true);
        
        }
        else {

            playerAnimator.SetBool(WALK_ANIMATION, false);

        }
    }

    public void HarvestStopMovement(float time) {

        isHarvesting = true;
        harvestTimer = Time.time + time;

    }

    public bool IsHarvesting() {

        return isHarvesting;

    }

   

} // class
