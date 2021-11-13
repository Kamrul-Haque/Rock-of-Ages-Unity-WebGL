using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines behaviour of the rocks
/// </summary>
public class Rock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Give the rock Impulse Force to move
        const float minForce = 2f;
        const float maxForce = 3f;
        float angle = Random.Range(0, 2 * Mathf.PI);

        float magnitude = Random.Range(minForce, maxForce);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(magnitude * direction, ForceMode2D.Impulse);
    }

    //Destroy out of scene rock
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
