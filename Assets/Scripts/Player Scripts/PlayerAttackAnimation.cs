using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackAnimation : MonoBehaviour
{

    [SerializeField]
    private Sprite[] slashSprits;

    [SerializeField]
    private float timeTreshlod = 0.06f;

    [SerializeField]
    private int damage = 35;

    private float timer;
    private int state = 0;

    private SpriteRenderer spriteRenderer;
    private string WOLF_TAG = "Wolf";

    private void Awake() {
        
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Update() {
        
        if (Time.time > timer) {

            if(state == slashSprits.Length) {

                Destroy(gameObject);
                return;

            }
            else {

                spriteRenderer.sprite = slashSprits[state];
                state++;

                timer = Time.time + timeTreshlod;

            }

        }

    }
    
    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.CompareTag(WOLF_TAG)) {

                collision.GetComponent<WolfHelth>().TakeDamage(damage);

        }
        
    }


    
}

//class
