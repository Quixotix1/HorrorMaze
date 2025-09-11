using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    bool canUseTorch = true;
    bool torch = false;
    int pellets = 0;

    public GameObject torchObject;
    public GameObject exit;
    public Enemy enemy;
    public TMP_Text objectiveText;

    private void Start()
    {
        exit.SetActive(false);
    }

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
                exit.SetActive(true);

                canUseTorch = false;
            }

            enemy.gameObject.SetActive(true);
            enemy.Teleport(transform);
        }

        if (other.CompareTag("Exit"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("WinScene");
            }
        }
    }
}
