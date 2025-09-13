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
    public GameObject torchImage;
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
        torchImage.SetActive(torch);
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
                torch = false;
            }

            enemy.gameObject.SetActive(true);
            enemy.Teleport(transform);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (pellets != 4 && !torch) enemy.visibility -= 0.5f * Time.deltaTime;
            else enemy.visibility += Time.deltaTime;
        }

        if (other.CompareTag("Exit"))
        {
            Debug.Log("escaping");

            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("WinScene");
            }
        }
    }
}
