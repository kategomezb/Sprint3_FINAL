using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    public enum ItemType { Heart, Key }

    public ItemType itemType;  // Type of the item (Heart or Key)
    public KeyCode interactKey = KeyCode.R;  // Key to interact with the item

    public GameObject heartObject; // Reference to the Heart object
    public GameObject keyObject;   // Reference to the Key object

    private bool isPlayerNear = false;  // Is the player near the item?

    private void Update()
    {
        // Check if the player presses the interact key when near the item
        if (isPlayerNear && Input.GetKeyDown(interactKey))
        {
            InteractWithItem();
        }
    }

    private void InteractWithItem()
    {
        // Run logic based on what was chosen
        switch (itemType)
        {
            case ItemType.Heart:
                HeartOrKeyLogic.Instance.ChooseHeart();
                break;
            case ItemType.Key:
                HeartOrKeyLogic.Instance.ChooseKey();
                break;
        }

        // Destroy this object
        Destroy(gameObject);

        // Destroy the other object if it's assigned and not this object
        if (heartObject != null && heartObject != gameObject)
        {
            Destroy(heartObject);
        }

        if (keyObject != null && keyObject != gameObject)
        {
            Destroy(keyObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}
