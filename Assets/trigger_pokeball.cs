using UnityEngine;
using TMPro;

public class trigger_pokeball : MonoBehaviour
{
    public GameObject infoPanel;          // Panel con la información
    public GameObject interactUI;         // Texto: "Presionar E para más detalles"
    public TextMeshProUGUI infoText;      // Texto dentro del panel
    [TextArea]
    public string description;            // Descripción personalizada del objeto

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
                infoText.text = description;
            else
                infoText.text = "";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            interactUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactUI.SetActive(false);
            infoPanel.SetActive(false);
            infoText.text = "";
        }
    }
}
