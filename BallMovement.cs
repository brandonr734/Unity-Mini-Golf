using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private LineRenderer shotPathRenderer;
    [SerializeField] private GameManager gameManager;

    void Awake(){
        shotPathRenderer = GameObject.Find("ShotPathRenderer").GetComponent<LineRenderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameObject.Find("Main Camera").GetComponent<CameraFollow>().target = transform;
    }

    void Update(){
        if(Input.GetMouseButton(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            shotPathRenderer.positionCount = 2;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)){
                Vector3 clickPosition = hit.point;
                clickPosition.y = transform.position.y;
                Vector3 aimingDirection = ((clickPosition - transform.position).normalized)*-1;
                float maxDistance = 5.0f;
                float clickDistance = Vector3.Distance(clickPosition, transform.position);
                float normalizedDistance = Mathf.Clamp01(clickDistance / maxDistance);
                float maxPathLength = 2f;
                float distance = Mathf.Min(clickDistance, maxPathLength);
                shotPathRenderer.SetPosition(0, transform.position);
                Vector3 endPoint = transform.position + (aimingDirection * distance);
                shotPathRenderer.SetPosition(1, endPoint);

            }
        }
        if(Input.GetMouseButtonUp(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)){
                Vector3 clickPosition = hit.point;
                clickPosition.y = transform.position.y;
                shotPathRenderer.positionCount = 0;
                Vector3 aimingDirection = (clickPosition - transform.position).normalized;
                aimingDirection = aimingDirection*-1;
                float maxDistance = 5.0f;
                float minVelocity = 2.0f;
                float maxVelocity = 30.0f;
                float clickDistance = Vector3.Distance(clickPosition, transform.position);
                float normalizedDistance = Mathf.Clamp01(clickDistance / maxDistance);
                float shotVelocity = Mathf.Lerp(minVelocity, maxVelocity, normalizedDistance*2);
                transform.GetComponent<Rigidbody>().AddForce(aimingDirection * shotVelocity, ForceMode.Impulse);
                gameManager.increaseHit();
            }
        }
    }
}
