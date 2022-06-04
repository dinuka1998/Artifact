using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBackPack : MonoBehaviour
{
    
    public int maxNumberOfFruitsToStore = 50;
    public int currentNumberOfFruits;

    public void AddFruits(int amount) {

        currentNumberOfFruits += amount;

        if(currentNumberOfFruits > maxNumberOfFruitsToStore)
            currentNumberOfFruits = maxNumberOfFruitsToStore;
    
    }

    public int TakeFruits() {

        int takenFruits = currentNumberOfFruits;
        currentNumberOfFruits = 0;

        return takenFruits;

    }

} // class
