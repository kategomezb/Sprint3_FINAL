using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class HeartOrKeyLogic : MonoBehaviour
{
    public GameObject choiceMessageUI; 
    public TextMeshProUGUI choiceMessageText;

    public GameObject choiceKeyMessageUI; 
    public TextMeshProUGUI choiceKeyMessageText;

    public static HeartOrKeyLogic Instance;

    public GameObject prince;
    public GameObject bessie;
    public GameObject lamar;
    public GameObject water;
    public GlassRoomDestruction glassRoomDestruction; 

    private void Awake()
    {
        Instance = this;
    }

    public void ChooseHeart()
    {
        if (bessie != null)
        {
            bessie.SetActive(false); 
            Debug.Log("Bessie drowns");
        }

        if (lamar != null)
        {
            lamar.SetActive(false); 
            Debug.Log("Lamar dies");
        }

        if (prince != null)
        {
            prince.SetActive(true); 
            Debug.Log("Prince survives");
        }

        if (choiceMessageUI != null && choiceMessageText != null)
        {
            choiceMessageUI.SetActive(true);
            choiceMessageText.text = "Riven lives, but at a great cost.\nBessie and Lamar are gone...";
            Invoke(nameof(HideMessage), 5f); 
            Invoke(nameof(LoadMainMenu), 5f); 
        }
    }

    public void ChooseKey()
    {
        if (water != null)
        {
            Debug.Log("Water disappears");
            Destroy(water); 
        }

       
        if (glassRoomDestruction != null)
        {
            glassRoomDestruction.DestroyGlassRoom();  
        }
        else
        {
            Debug.LogWarning("GlassRoomDestruction script is not assigned.");
        }

        if (bessie != null)
        {
            bessie.SetActive(true);
            Debug.Log("Bessie survives");
        }

        if (lamar != null)
        {
            lamar.SetActive(true); 
            Debug.Log("Lamar survives");
        }

        if (prince != null)
        {
            prince.SetActive(false); 
            Debug.Log("Prince dies");
        }

        if (choiceKeyMessageUI != null && choiceKeyMessageText != null)
        {
            choiceKeyMessageUI.SetActive(true);
            choiceKeyMessageText.text = "You chose the key.\nRiven is gone, but Bessie and Lamar are safe.";
            Invoke(nameof(HideKeyMessage), 5f);
            Invoke(nameof(LoadMainMenu), 5f); 
        }
    }

    private void HideMessage()
    {
        if (choiceMessageUI != null)
        {
            choiceMessageUI.SetActive(false);
        }
    }

    private void HideKeyMessage()
    {
        if (choiceKeyMessageUI != null)
        {
            choiceKeyMessageUI.SetActive(false);
        }
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}