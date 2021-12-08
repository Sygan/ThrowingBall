using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [DisabledField(Disable = true)]
    public Transform GrabParent;
    
    public float ThrowForce = 10f;
    public PlayerBoxController PlayerBoxController;
    
    private BallController highlightedBall;
    private BallController grabbedBall;

    // Update is called once per frame
    void Update()
    {
        RaycastHit outHit;
        var wasHit = Physics.Raycast(transform.position, transform.forward, out outHit, 100f);

        if (wasHit && grabbedBall == null)
        {
            var ballController = outHit.transform.GetComponent<BallController>();

            if (ballController != null && ballController != highlightedBall)
            {
                if (highlightedBall != null)
                    highlightedBall.Highlight(false);
                
                highlightedBall = ballController;
                highlightedBall.Highlight(true);
            }
            else if (ballController == null && highlightedBall != null)
            {
                highlightedBall.Highlight(false);
                highlightedBall = null;
            }

            Debug.Log(outHit.transform.gameObject.name);
        }

        Debug.DrawRay(transform.position, transform.forward * 100f, Color.blue);

        if (highlightedBall != null && grabbedBall == null && Input.GetButtonDown("Fire1"))
        {
            highlightedBall.transform.SetParent(GrabParent);
            highlightedBall.transform.localPosition = Vector3.zero;
            grabbedBall = highlightedBall;
            grabbedBall.Rigidbody.isKinematic = true;
            grabbedBall.Highlight(false);
            PlayerBoxController.RemoveBall();
            highlightedBall = null;
        }
        else if (grabbedBall != null && Input.GetButtonDown("Fire1"))
        {
            grabbedBall.Throw(ThrowForce, transform.forward);
            grabbedBall = null;
        }
        
        
    }
}
