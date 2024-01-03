using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovementNavMesh : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private TMP_Text txtVitoria;
    private string levelAtual;
    [SerializeField] private Cronometro cronometro;
    void Start()
    {
        levelAtual = SceneManager.GetActiveScene().name;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        /* Para alterar o custo de uma area dinamicamente */
        //float valorAtual = NavMesh.GetAreaCost(NavMesh.GetAreaFromName("Lama"));
        //float novoValor = 20;
        //NavMesh.SetAreaCost(NavMesh.GetAreaFromName("Lama"), novoValor);

        if (Input.GetMouseButtonDown(0))
        {
            MoveToClickPoint();
        }
    }

    void MoveToClickPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Derrota"))
        {
            Derrota();
        }
    }
    
    private void OnCollisionEnter(Collision col)
    {
        if(col.collider.CompareTag("Inimigo"))
        {
            Derrota();
        }
    }

    public void Vitoria()
    {
        cronometro.cronometroAtivo = false;
        txtVitoria.text = "VITÓRIA";
        Invoke("Reset", 3f);
    }

    public void Derrota()
    {
        txtVitoria.color = Color.red;
        txtVitoria.text = "DERROTA";
        Invoke("Reset", 3f);
    }

    private void Reset()
    {
        SceneManager.LoadScene(levelAtual);
    }
}
