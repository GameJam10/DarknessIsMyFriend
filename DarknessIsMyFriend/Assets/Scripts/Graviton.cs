using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Graviton : MonoBehaviour
{
    Rigidbody rigidBody;

    public bool IsAttractee
    {
        get
        {
            return isAttractee;
        }

        set
        {
            if (value == true)
            {
                if (!GravityScript.attractees.Contains(this.GetComponent<Rigidbody>()))
                {
                    GravityScript.attractees.Add(rigidBody);
                }
            }
            else
            {
                GravityScript.attractees.Remove(rigidBody);
            }
            isAttractee = value;
        }
    }
    public bool IsAttractor
    {
        get
        {
            return isAttractor;
        }

        set
        {
            if (value == true)
            {
                if (!GravityScript.attractors.Contains(this.GetComponent<Rigidbody>()))
                {
                    GravityScript.attractors.Add(rigidBody);
                }
            }
            else
            {
                GravityScript.attractors.Remove(rigidBody);
            }
            isAttractor = value;
        }
    }

    [SerializeField] bool isAttractee;
    [SerializeField] bool isAttractor;

    [SerializeField] Vector3 initialVelocity;
    [SerializeField] bool applyInitialVelocityOnStart;

    private void Awake()
    {
        rigidBody = this.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        IsAttractor = isAttractor;
        IsAttractee = isAttractee;
    }

    //private void Start()
    //{
    //    if(applyInitialVelocityOnStart)
    //    {
    //        ApplyVelocity(initialVelocity);
    //    }
    //}

    private void OnDisable()
    {
        GravityScript.attractors.Remove(rigidBody);
        GravityScript.attractees.Remove(rigidBody);
    }

    public void ApplyVelocity (Vector3 velocity)
    {
        rigidBody.AddForce(initialVelocity, ForceMode.Impulse);
    }
}
