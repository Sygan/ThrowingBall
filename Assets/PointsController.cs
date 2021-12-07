using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsController : MonoBehaviour
{
    public Text TextField;
    
    void Start()
    {
        GameManager.Instance.OnBallEnteredBox += OnBallEnteredBox;        
    }

    private void OnBallEnteredBox()
    {
        Debug.Log("On Ball Enter");
        TextField.text = GameManager.Instance.Points.ToString();
    }
}
