using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Material NormalMaterial;
    public Material SelectedMaterial;

    public Renderer MeshRenderer;
    public Rigidbody Rigidbody;
    
    public void Highlight(bool highlighted)
    {
        MeshRenderer.material = highlighted ? SelectedMaterial : NormalMaterial;
    }

    public void Throw(float force, Vector3 throwVector)
    {
        transform.SetParent(null);
        Rigidbody.isKinematic = false;
        Rigidbody.AddForce(throwVector * force, ForceMode.Impulse);
    }
    
}
