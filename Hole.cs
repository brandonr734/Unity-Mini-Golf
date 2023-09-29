using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hole : MonoBehaviour
{
    [SerializeField] private GameObject winMessage;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject golfBall;
    [SerializeField] private GameManager gameManager;
    void OnTriggerEnter(Collider other){
        if (other.CompareTag("GolfBall")){
            Destroy(other.gameObject);
            GameObject currentWinMessage = Instantiate(winMessage);
            currentWinMessage.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = gameManager.score();
            Destroy(currentWinMessage,1);
            Instantiate(golfBall, spawnPoint.transform.position, Quaternion.identity);
            gameManager.resetHit();
        }
    }
}
