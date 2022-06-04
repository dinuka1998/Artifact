using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushFruits : MonoBehaviour
{
    
    [SerializeField]
    private int[] amountPerBushType;

     [SerializeField]
    private float[] respwanTime;

    private BushVisuals bushVisual;

    private bool hasFruits;
    private float timer;

    private void Start() {

        bushVisual =  GetComponent<BushVisuals>();

        //randomly intialize Some bushes and fruits
        if (Random.Range(0, 2) == 0) {

            hasFruits = false;
            timer = Time.time + respwanTime[(int)bushVisual.GetBushVariant()]; 

        }
        else {

            hasFruits = true;
            bushVisual.ShowFruits();
            
        }

    }

     private void Update() {

         if(Time.time > timer) {

             hasFruits = true;
             bushVisual.ShowFruits();

         }
            
    }

    public int HarvestFruit() {

        if (hasFruits) {

            hasFruits = false;
            bushVisual.HideFruits();
            timer = Time.time + respwanTime[(int)bushVisual.GetBushVariant()];
            return amountPerBushType[(int)bushVisual.GetBushVariant()];

        }
        else {

            return 0;

        }

    }

    public bool HasFruits() {

        return hasFruits;

    }

    //when enemy attaks the bush and eat it
    public void EatBushFruits() {

        enabled = false;
        bushVisual.SetToDry();

    }

}// class
