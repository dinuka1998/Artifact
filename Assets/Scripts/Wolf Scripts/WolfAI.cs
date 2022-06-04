using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAI : MonoBehaviour
{
    [SerializeField]
    private bool isEater;

    [SerializeField]
    private float mvoementSpeed = 1f;

    [SerializeField]
    private int attackDamge = 5;

    [SerializeField]
    private float attackTimeTreshold = 1f;

    [SerializeField]
    private float eatTimeTreshlod = 2f;

    [SerializeField]
    private LayerMask bushMask;

    [HideInInspector]
    public bool isMoving, left;

    private Artifact artifact;
    private BushFruits bushFruitsTarget;

    private float attackTimer;
    private float eatTimer;

    private bool killingBush;
    private bool isAttacking;

    private string ARTIFACT_TAG = "Artifact";



    // Start is called before the first frame update
    void Start() {

        if (isEater) {

            SearchForTarget();
            killingBush = false;

        }else {

            isAttacking = false;

        }

        artifact = GameObject.FindWithTag(ARTIFACT_TAG).GetComponent<Artifact>();
        
    }

    // Update is called once per frame
    void Update() {

        if(!artifact)
            return;

        if(isEater) {

            if(bushFruitsTarget && bushFruitsTarget.enabled && bushFruitsTarget.HasFruits() && !killingBush) {

                if(Vector2.Distance(transform.position, bushFruitsTarget.transform.position) > 0.5f) {

                    float step = mvoementSpeed * Time.deltaTime;

                    transform.position = Vector2.MoveTowards(transform.position, bushFruitsTarget.transform.position, step);

                    isMoving = true;

                } 
                else {

                    isMoving = false;
                    bushFruitsTarget.HarvestFruit();
                    eatTimer = Time.time + eatTimeTreshlod;
                    killingBush = true;

                }

            }
            else if (killingBush) {

                if(Time.time > eatTimer) {

                    bushFruitsTarget.EatBushFruits();
                    killingBush = false;

                    SearchForTarget();

                }

            }
            else {

                SearchForTarget();

            }

            if(bushFruitsTarget) {

                if(bushFruitsTarget.transform.position.x < transform.position.x)
                    left = true;
                else
                    left = false;

            }

            if(!bushFruitsTarget)
                SearchForTarget();

        }
        else {

            if(Vector2.Distance(transform.position, artifact.transform.position) > 1.5f) {

                float step = mvoementSpeed * Time.deltaTime;

                transform.position = Vector2.MoveTowards(transform.position, artifact.transform.position, step);

                isMoving = true;

            }
            else if(!isAttacking) {

                isAttacking = true;
                attackTimer = Time.time + attackTimeTreshold;

                isMoving = false;

            }

            if(isAttacking) {

                if(Time.time > attackTimer) {

                    Attack();
                    attackTimer = Time.time + attackTimeTreshold;

                }

            }

            if (artifact.transform.position.x < transform.position.x)
                left = true;
            else
                left = false;

        }


    }

    void SearchForTarget() {

        bushFruitsTarget = null;

        Collider2D[] hits;

        for (int i = 0; i < 50; i++) {
            
            hits = Physics2D.OverlapCircleAll(transform.position, Mathf.Exp(i), bushMask);

            foreach (Collider2D hit in hits) {

                if(hit && (hit.GetComponent<BushFruits>().HasFruits() && hit.GetComponent<BushFruits>().enabled)) {

                    bushFruitsTarget = hit.GetComponent<BushFruits>();
                    break;
                }
                
            }

            if (bushFruitsTarget)
                break;

        }

    }// serach for target

    void Attack() {

        artifact.TakeDamage(attackDamge);

    }

} //class
