using UnityEngine;

public class HeartOrKeyLogic : MonoBehaviour
{
    public static HeartOrKeyLogic Instance;

    public GameObject prince;
    public GameObject bessie;
    public GameObject lamar;
    public GameObject water;
    public GlassRoomDestruction glassRoomDestruction;  // Reference to the GlassRoomDestruction script

    private void Awake()
    {
        Instance = this;
    }

    public void ChooseHeart()
    {
        // Bessie drowns and Prince survives
        if (bessie != null)
        {
            bessie.SetActive(false); // Deactivate Bessie (she drowns)
            Debug.Log("Bessie drowns");
        }

        if (lamar != null)
        {
            lamar.SetActive(false); // Lamar dies
            Debug.Log("Lamar dies");
        }

        if (prince != null)
        {
            prince.SetActive(true); // Prince survives
            Debug.Log("Prince survives");
        }

        // Additional logic here, such as adding effects
    }

    public void ChooseKey()
    {
        // Water disappears (and other outcomes)
        if (water != null)
        {
            Debug.Log("Water disappears");
            Destroy(water); // Destroy water (disappear)
        }

        // Destroy Bessie's glass room using the GlassRoomDestruction script
        if (glassRoomDestruction != null)
        {
            glassRoomDestruction.DestroyGlassRoom();  // Destroy the glass room
        }
        else
        {
            Debug.LogWarning("GlassRoomDestruction script is not assigned.");
        }

        if (bessie != null)
        {
            bessie.SetActive(true); // Bessie survives
            Debug.Log("Bessie survives");
        }

        if (lamar != null)
        {
            lamar.SetActive(true); // Lamar survives
            Debug.Log("Lamar survives");
        }

        if (prince != null)
        {
            prince.SetActive(false); // Prince dies
            Debug.Log("Prince dies");
        }
    }
}