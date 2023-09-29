using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int hitCount;
    [SerializeField] private int par;
    [SerializeField] private Text hitCountText;

    public void increaseHit(){
        hitCount++;
        hitCountText.text = hitCount.ToString();
    }

    public void resetHit(){
        hitCount = 0;
        hitCountText.text = hitCount.ToString();
    }

    public int getHitCount(){
        return hitCount;
    }

    public int getPar(){
        return par;
    }

    public string score(){
        if(hitCount == 1){
            return "Hole-in-one!";
        }
        if(hitCount == par){
            return "Par!";
        }
        if(hitCount == par-1){
            return "Birdie!";
        }
        if(hitCount == par-2){
            return "Eagle!";
        }
        if(hitCount == par-3){
            return "Double Eagle!";
        }
        if(hitCount == par+1){
            return "Bogey";
        }
        if(hitCount >= par+2){
            return "Double Bogey";
        }
        if(hitCount <= -4){
            return "Ace!";
        }
        return null;
    }
}
