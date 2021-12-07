using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerBoxController : MonoBehaviour
{
    public Transform SpawnPosition;
    public int BallsAmount = 1;
    
    public void Start()
    {
        for (int i = 0; i < BallsAmount; i++)
        {
            var ball = GameManager.Instance.BallPooler.GetBall();
            
            ball.Create(SpawnPosition.position);
        }
    }

    public void RemoveBall()
    {
        BallsAmount--;

        if (BallsAmount == 0)
        {
            var ball = GameManager.Instance.BallPooler.GetBall();
            
            ball.Create(SpawnPosition.position);

            BallsAmount++;
        }
    }
}
