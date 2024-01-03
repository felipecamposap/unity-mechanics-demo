using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{

    private Scene currentScene;
    private GameObject vitoria;
    private bool hasWon;
    [SerializeField] private GameObject? victoryPlatform;

    [SerializeField] private TMP_Text txtVitoria;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Coletavel"))
        {
            victoryPlatform.SetActive(true);
            Destroy(col.gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Derrota") || col.CompareTag("Inimigo"))
            Defeat();
        else
            Victory();
    }

    void Victory()
    {
        if (!hasWon)
        {
            hasWon = true;
            txtVitoria.text = "VITÓRIA";
            Invoke("Reset", 3f);
        }
    }

    void Defeat()
    {
        if (!hasWon)
        {
            hasWon = true;
            txtVitoria.color = Color.red;
            txtVitoria.text = "DERROTA";
            Invoke("Reset", 2f);
        }
    }

    void Reset()
    {
        SceneManager.LoadScene(currentScene.name);
    }
}
