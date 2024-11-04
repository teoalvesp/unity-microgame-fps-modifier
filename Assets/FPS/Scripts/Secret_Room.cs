using UnityEngine;

public class Secret_Room : MonoBehaviour
{
    private Renderer cubeRenderer;
    private Color originalColor;

    public GameObject secret_door; // Arraste o GameObject da porta secreta para este campo no Inspector
    public float moveDistance = 1.0f; // Distância para mover a porta
    public AudioSource audioSource; // Arraste o AudioSource para este campo no Inspector

    private void Start()
    {
        // Referência ao Renderer do cubo para mudar a cor
        cubeRenderer = GetComponent<Renderer>();
        originalColor = cubeRenderer.material.color; // Guarda a cor original
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou em contato tem a tag "Player"
        if (other.CompareTag("Player"))
        {
            // Muda a cor para verde ao entrar na área de trigger
            cubeRenderer.material.color = Color.green;
            PerformAction();
        }
    }

    private void PerformAction()
    {
        // Log quando a cor mudar
        Debug.Log("Cube triggered and changed color! Action performed.");

        // Tocar o som
        if (audioSource != null)
        {
            Debug.Log("Playing sound...");
            audioSource.PlayOneShot(audioSource.clip); // Toca o som
        }
        else
        {
            Debug.Log("AudioSource is null!");
        }

        // Obter a posição atual da porta
        Vector3 currentPosition = secret_door.transform.position;

        // Calcular a nova posição (aumentando a coordenada X para mover para a direita)
        Vector3 newPosition = currentPosition + new Vector3(moveDistance, 0f, 0f);

        // Atribuir a nova posição à porta secreta
        secret_door.transform.position = newPosition;
    }
}
