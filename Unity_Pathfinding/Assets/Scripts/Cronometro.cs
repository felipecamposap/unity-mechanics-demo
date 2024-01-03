using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Cronometro : MonoBehaviour
{
    public float tempoInicial = 20.0f; // Tempo inicial em segundos
    private float tempoRestante; // Tempo restante do cron�metro
    public bool cronometroAtivo = true; // Indica se o cron�metro est� ativo
    [SerializeField] private TMP_Text txtVitoria, txtCronometro;
    private string levelAtual;
    [SerializeField] private PlayerMovementNavMesh player;

    void Start()
    {
        levelAtual = SceneManager.GetActiveScene().name;
        tempoRestante = tempoInicial;
    }

    void Update()
    {
        if (cronometroAtivo)
        {
            txtCronometro.text = $"{tempoRestante:F1}";
            tempoRestante -= Time.deltaTime; // Decrementa o tempo restante

            // Verifica se o tempo acabou
            if (tempoRestante <= 0)
            {
                tempoRestante = 0;
                cronometroAtivo = false;
                player.Derrota(); // Chama o m�todo "Derrota"
            }
        }
    }

    public void IniciarCronometro()
    {
        cronometroAtivo = true;
        tempoRestante = tempoInicial;
    }

    public void PausarCronometro()
    {
        cronometroAtivo = false;
    }
}