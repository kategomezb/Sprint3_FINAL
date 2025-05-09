using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarCounter : MonoBehaviour
{
    public static StarCounter Instance;

    public int starsCollected = 0;
    public int totalStarsRequired = 12;

    public GameObject glassHeartRoom;
    public GameObject glassKeyRoom;
    public AudioClip breakClip;

    public TextMeshProUGUI starText; 

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateStarUI();
    }

    public void CollectStar()
    {
        starsCollected++;
        UpdateStarUI();

        if (starsCollected >= totalStarsRequired)
        {
            BreakGlassRooms();
        }
    }

    void UpdateStarUI()
    {
        if (starText != null)
        {
            starText.text = "   : " + starsCollected.ToString();
        }
    }
    void BreakGlassRooms()
    {
        Destroy(glassHeartRoom);
        Destroy(glassKeyRoom);
    }
}
