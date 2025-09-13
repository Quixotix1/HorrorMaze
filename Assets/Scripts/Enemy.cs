using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    bool isMoving;
    [HideInInspector] public float visibility = 0f;

    public void Teleport(Transform player)
    {
        transform.position = player.position;
        transform.position -= player.forward * 3;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {

        if (isMoving)
        {
            Debug.Log(visibility);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 2f * Time.deltaTime);
        }

        if (visibility <= 0f)
        {
            isMoving = false;
            gameObject.SetActive(false);
        }

        if (visibility > 1f) visibility = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            isMoving = true;
        }
    }
}
