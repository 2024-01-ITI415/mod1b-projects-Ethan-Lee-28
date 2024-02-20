using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        ResetPosition();
    }

    void Update()
    {
        MoveCube();
    }

    void MoveCube()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (transform.position.z > 20f)
        {
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        float randomX = Random.Range(-5f, 5f);
        float randomY = -5f;
        float randomZ = Random.Range(0f, 10f);

        transform.position = new Vector3(randomX, randomY, randomZ);

        ClampPositionToBounds();
    }

    void ClampPositionToBounds()
    {
        float xBound = 0.5f;
        float zBoundMin = 0f;
        float zBoundMax = 10f;

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -xBound, xBound);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, zBoundMin, zBoundMax);

        transform.position = clampedPosition;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            gameManager.CubeCollected();
        }
    }
}
