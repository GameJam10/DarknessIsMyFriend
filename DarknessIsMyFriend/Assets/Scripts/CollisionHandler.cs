using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            ScoreHandler.hit();
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag.Equals("Finish"))
        {
            // Get points
            ScoreHandler.addScore();
            Destroy(gameObject);
        }
    }
}
