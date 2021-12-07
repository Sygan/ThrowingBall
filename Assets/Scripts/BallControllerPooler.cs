using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControllerPooler : MonoBehaviour
{
    public List<BallController> AvailableBalls;
    
    public BallController BallPrefab;
    public int StartingAmount = 5;

    private void Start()
    {
        for (int i = 0; i < StartingAmount; i++)
        {
            var ballController = Instantiate(BallPrefab);
            ballController.gameObject.SetActive(false);
            AvailableBalls.Add(ballController);
        }
    }
    
    public BallController GetBall()
    {
        if (AvailableBalls.Count > 0)
        {
            var ballController = AvailableBalls[AvailableBalls.Count - 1];
            AvailableBalls.RemoveAt(AvailableBalls.Count - 1);
            return ballController;
        }

        return Instantiate(BallPrefab);
    }

    public void ReturnBall(BallController ballController)
    {
        ballController.gameObject.SetActive(false);
        AvailableBalls.Add(ballController);
    }
}
