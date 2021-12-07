using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private BallController currentBall;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.Instance.AddScore(1);
            currentBall = other.GetComponent<BallController>();
            
            Invoke(nameof(ReturnBall), 1f);
        }
    }

    private void ReturnBall()
    {
        GameManager.Instance.BallPooler.ReturnBall(currentBall);
    }
}
