using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public Box BoxData;
    
    private BallController currentBall;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Adding " + BoxData.Points + " points");
            GameManager.Instance.AddScore(BoxData.Points);
            currentBall = other.GetComponent<BallController>();
            
            Invoke(nameof(ReturnBall), 1f);
        }
    }

    private void ReturnBall()
    {
        GameManager.Instance.BallPooler.ReturnBall(currentBall);
    }
}
