using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool canUseTorch = true;
    bool torch = false;
    int pellets = 0;

    public GameObject torchObject;
    public TMP_Text objectiveText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canUseTorch)
        {
            torch = !torch;
        }

        torchObject.SetActive(torch);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pellet"))
        {
            Destroy(other.gameObject);
            pellets++;

            if (pellets == 4)
            {
                objectiveText.SetText("CURRENT OBJECTIVE: Escape");
                canUseTorch = false;
            }
        }
    }
}
