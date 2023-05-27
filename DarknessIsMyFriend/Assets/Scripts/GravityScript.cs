using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript: MonoBehaviour
{
    [SerializeField] float g = 1f;
    static float G;

    public static List<Rigidbody> attractors = new List<Rigidbody>();
    public static List<Rigidbody> attractees = new List<Rigidbody>();
    public static bool isSimulatingLive = true;

    private void FixedUpdate()
    {
        G = g;
        if (isSimulatingLive)
        {
            SimulateGravities();
        }
    }

    public static void SimulateGravities()
    {
        foreach (Rigidbody attractor in attractors)
        {
            foreach (Rigidbody attractee in attractees)
            {
                if (attractor != attractee)
                {
                    AddGravityForce(attractor, attractee);
                }
            }
        }
    }

    public static void AddGravityForce (Rigidbody attractor, Rigidbody target)
    {
        float massProduct = attractor.mass * target.mass * G;

        Vector3 difference = attractor.position - target.position;
        float distance = difference.magnitude;

        float unScaledForceMagnitude = massProduct / Mathf.Pow(distance, 2);
        float forceMagnitude = G * unScaledForceMagnitude;

        Vector3 forceDirection = difference.normalized;

        Vector3 forceVector = forceDirection * forceMagnitude;
        target.AddForce(forceVector);
    }
}

