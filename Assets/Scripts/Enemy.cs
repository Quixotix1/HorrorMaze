using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Teleport(Transform player)
    {
        transform.position = player.position;
        transform.position -= player.forward * 3;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }
}
