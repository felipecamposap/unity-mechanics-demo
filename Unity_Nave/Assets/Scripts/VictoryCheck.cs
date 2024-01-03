using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class VictoryCheck : MonoBehaviour
{
    private bool gameFinished = false;
    private byte sceneIndex;
    [SerializeField] private TMP_Text txtVictory;

    void Start()
    {
        sceneIndex = (byte)SceneManager.GetActiveScene().buildIndex;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!gameFinished)
        {
            if (other.CompareTag("Vitoria"))
            {
                gameFinished = true;
                txtVictory.text = "VITORIA";

                Invoke("Reset", 3f);
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<Rigidbody>().isKinematic = true;
            }
            else if (other.CompareTag("Derrota"))
            {
                gameFinished = true;
                txtVictory.color = Color.red;
                txtVictory.text = "DERROTA";

                Invoke("Reset", 3f);
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<Rigidbody>().isKinematic = true;
            }
            else if (other.CompareTag("Coletavel"))
            {
                Destroy(other.gameObject);
            }
        }
    }

    void Reset()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
