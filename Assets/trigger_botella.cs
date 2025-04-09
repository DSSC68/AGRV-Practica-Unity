using UnityEngine;
using TMPro;

public class trigger_botella : MonoBehaviour
{
    public GameObject infoPanel;
    public GameObject interactUI;
    public TextMeshProUGUI infoText;
    [TextArea]
    public string description;

    private bool playerInRange = false;

    void Start()
    {
        infoPanel.SetActive(false);
        interactUI.SetActive(false);
        infoText.text = "";
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            bool isActive = infoPanel.activeSelf;
            infoPanel.SetActive(!isActive);

            if (!isActive)
            {
                infoText.text = description;
                interactUI.SetActive(false); // ocultar el mensaje cuando se abre el panel
            }
            else
            {
                infoText.text = "";
                interactUI.SetActive(true);  // volver a mostrar si se cierra
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador entró al trigger.");  // DEBUG
            playerInRange = true;
            interactUI.SetActive(true); // mostrar mensaje al acercarse
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador salió del trigger.");  // DEBUG
            playerInRange = false;
            interactUI.SetActive(false);
            infoPanel.SetActive(false);
            infoText.text = "";
        }
    }
}
