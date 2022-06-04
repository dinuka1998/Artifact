using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushVisuals : MonoBehaviour
{

    [SerializeField]
    private Sprite[] bushSprites, fruitSprites, drySprites;

    [SerializeField]
    private SpriteRenderer[] fruitsRenderes;
    
    public enum BushVariant { Green, Cyan, Yellow }
    private BushVariant bushVariant;

    public float hideTimePerFruit = 0.2f;
    private SpriteRenderer spriteRenderer;

    private void Awake() {

        spriteRenderer = GetComponent<SpriteRenderer>();
        
        bushVariant = (BushVariant)Random.Range(0, bushSprites.Length);
        spriteRenderer.sprite = bushSprites[(int)bushVariant];

        if(Random.Range(0, 2) == 1) 
            spriteRenderer.flipX = true;

        for (int i = 0; i < fruitsRenderes.Length; i++) {

            fruitsRenderes[i].sprite = fruitSprites[(int)bushVariant];
            fruitsRenderes[i].enabled = false;

        }
 
    }

    public BushVariant GetBushVariant() {

        return bushVariant;

    }

    public void SetToDry() {

        spriteRenderer.sprite = drySprites[(int)bushVariant];

    }

    IEnumerator _HideFruits(float time, int index) {

         yield return new WaitForSeconds(time);
         fruitsRenderes[index].enabled = false;

    }

    public void HideFruits() {

        float waitTimeForFruit =  hideTimePerFruit;
        for (int i = 0; i < fruitsRenderes.Length; i++) {
            
            StartCoroutine(_HideFruits(waitTimeForFruit, i));
            waitTimeForFruit += hideTimePerFruit; 

        }

    }

    public void ShowFruits() {

        for (int i = 0; i < fruitsRenderes.Length; i++) {
            
            fruitsRenderes[i].enabled = true;

        }

    }

 
}// class

