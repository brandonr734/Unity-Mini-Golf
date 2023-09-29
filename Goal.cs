using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject winMessage;
    void OnTriggerEnter(Collider other){
        if (other.CompareTag("GolfBall")){
            Instantiate(winMessage);
            Destroy(other.gameObject);
        }
    }
}
