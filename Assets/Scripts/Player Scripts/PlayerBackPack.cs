using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBackPack : MonoBehaviour
{
    
    public int maxNumberOfFruitsToStore = 50;
    public int currentNumberOfFruits;

    [SerializeField]
    private Text backpackInfo;

    private void Start() {

        SetBackpackInfoText(0);

    }

    public void AddFruits(int amount) {

        currentNumberOfFruits += amount;

        if(currentNumberOfFruits > maxNumberOfFruitsToStore)
            currentNumberOfFruits = maxNumberOfFruitsToStore;

        SetBackpackInfoText(currentNumberOfFruits);
    
    }

    public int TakeFruits() {

        int takenFruits = currentNumberOfFruits;
        currentNumberOfFruits = 0;

        SetBackpackInfoText(currentNumberOfFruits);

        return takenFruits;

    }

    void SetBackpackInfoText(int amount) {

        backpackInfo.text = "Backpack : " + amount + "/" + maxNumberOfFruitsToStore;

    }

} // class
