using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnimation : MonoBehaviour
{

    [SerializeField]
    private Sprite[] wolfAnimationSprites;

    [SerializeField]
    private float animationTimeTreshold = 0.15f;

    private WolfAI wolfAI;

    private SpriteRenderer spriteRenderer;
    private int state = 0;
    private float animationTimer;

    private void Awake() {
        
        wolfAI = GetComponent<WolfAI>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Update() {
        
        if(wolfAI.isMoving) {

            if(Time.time > animationTimer) {

                spriteRenderer.sprite =  wolfAnimationSprites[state];

                state++;
                if(state == wolfAnimationSprites.Length)
                    state = 0;
                    
                animationTimer = Time.time + animationTimeTreshold;

            }

        }
        else { 

            spriteRenderer.sprite = wolfAnimationSprites[0];

        }

        spriteRenderer.flipX = wolfAI.left;

    }

    
}// class
