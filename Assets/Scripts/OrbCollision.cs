using UnityEngine;

public class OrbCollision : MonoBehaviour
{
    public float jumpBoostAmount = 3f;  
    public float boostDuration = 3f;   
    public float cooldownTime = 30f;    

    private bool canCollect = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canCollect)
        {
            Debug.Log("Orb collected!");

            FPSController playerController = other.GetComponent<FPSController>();
            if (playerController != null)
            {
                playerController.ApplyJumpBoost(jumpBoostAmount, boostDuration);
                playerController.OnGrabOrb();
            }

            canCollect = false;
            Destroy(gameObject);

           
        }
    }
}
