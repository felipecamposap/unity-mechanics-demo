using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PuzzleController : MonoBehaviour
{
    [SerializeField] private TMP_Text txtVictory;
    [SerializeField]private GameObject cubo1;
    [SerializeField]private GameObject cubo2;
    [SerializeField]private GameObject cubo3;

    [SerializeField]private GameObject cont1;
    [SerializeField]private GameObject cont2;
    [SerializeField]private GameObject cont3;

    protected byte puzzleCount = 0;

    private string sceneName;

    public byte PuzzleCount
    {
        get {return puzzleCount;}
        set 
        {
            puzzleCount = value;
            if(puzzleCount == 3)
                Victory(); 
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }

    void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    private void Victory()
    {
        txtVictory.text = "VITÓRIA";
        Invoke("Reset", 3f);
    }

    public void Defeat()
    {
        txtVictory.color = Color.red;
        txtVictory.text = "DERROTA";
        Invoke("Reset", 3f);
    }

    private void Reset()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
