using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float timer = 0f;
    private bool incrementing = false;
    private float waitTime = 5.0f;

    private float incrementHeight = 0.3f;
    private float actualYPosition;
    private float maxPlayerYPosition;
    private float topePlayerY = 5.0f;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        timer += Time.deltaTime;
       // Debug.Log("Temporizador: " + timer);

        if (timer >= waitTime && !incrementing)
        {
          actualYPosition = transform.position.y;
          maxPlayerYPosition = actualYPosition + 1.0f;
          incrementing = true;
        }

        if (incrementing)
        {
            if (actualYPosition < topePlayerY) 
            {
                IncrementarAltura(maxPlayerYPosition);
            } else
            {

            }
          }
    }

    void IncrementarAltura(float value)
    {
        float newYPosition = transform.position.y + incrementHeight * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);

        if (newYPosition >= value)
        {
            incrementing = false;
            timer = 0f;
        }
    }
}