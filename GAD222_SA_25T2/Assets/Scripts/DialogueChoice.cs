using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class DialogueChoice : MonoBehaviour
{
    public GameObject choicePanel;
    public TextMeshProUGUI choiceText;
    public Button option1Button;
    public Button option2Button;

    public string scene1Name;
    public string scene2Name;

    private void Start()
    {
        DialogueManager.Instance.OnDialogueEnd += ShowChoices;
        choicePanel.SetActive(false);

        option1Button.onClick.AddListener(() => LoadScene(scene1Name));
        option2Button.onClick.AddListener(() => LoadScene(scene2Name));
    }

    private void ShowChoices()
    {
        choicePanel.SetActive(true);
        Time.timeScale = 0f; // Pause game
    }

    private void LoadScene(string sceneName)
    {
        Time.timeScale = 1f; // Unpause before loading
        SceneManager.LoadScene(sceneName);
    }

    private void OnDestroy()
    {
        if (DialogueManager.Instance != null)
        {
            DialogueManager.Instance.OnDialogueEnd -= ShowChoices;
        }
    }
}
