using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MaterialCommand
{
    [SerializeField] private Renderer Object;


    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            Object.material.color = Color.red;
        }
    }

    public override void ChangeColor()
    {
       // throw new System.NotImplementedException();

        Object.material.color = Color.green;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ChangeColor();
        }
    }

}

public abstract class MaterialCommand : MonoBehaviour
{
    public abstract void ChangeColor();
}

