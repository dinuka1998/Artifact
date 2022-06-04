using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfHelth : MonoBehaviour
{

    [SerializeField]
    private GameObject helthUI;

    private float scale;

    [SerializeField]
    private int maxhelth = 100;

    private int currrentHelth;
    

    private void Awake() {
        
        currrentHelth = maxhelth;

    }

    public void TakeDamage(int amount) {

        currrentHelth -= amount;

        scale = (float)currrentHelth / maxhelth;

        helthUI.transform.localScale = new Vector3(scale, helthUI.transform.localScale.y, 1f);

        if(currrentHelth <= 0)
            Destroy(gameObject);

    }

   
} //class
