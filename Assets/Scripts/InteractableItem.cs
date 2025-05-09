using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    public enum ItemType { Heart, Key }

    public ItemType itemType;  
    public KeyCode interactKey = KeyCode.R;  

    public GameObject heartObject; 
    public GameObject keyObject; 

    private bool isPlayerNear = false; 

    private void Update()
    {
        
        if (isPlayerNear && Input.GetKeyDown(interactKey))
        {
            InteractWithItem();
        }
    }

    private void InteractWithItem()
    {
        switch (itemType)
        {
            case ItemType.Heart:
                HeartOrKeyLogic.Instance.ChooseHeart();
                break;
            case ItemType.Key:
                HeartOrKeyLogic.Instance.ChooseKey();
                break;
        }

        Destroy(gameObject);

        
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
