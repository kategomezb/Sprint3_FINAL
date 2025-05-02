using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject spherePrefab; // Reference to the orb prefab
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;

    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;

    private bool hasSpawnedJumpOrb = false; // Flag to allow only one spawn

    CharacterController characterController;

    private float originalWalkSpeed;
    private float originalRunSpeed;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        originalWalkSpeed = walkSpeed;
        originalRunSpeed = runSpeed;
    }

    void Update()
    {
        // Movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // Jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the character
        characterController.Move(moveDirection * Time.deltaTime);

        // Rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        // Left Click to Spawn Orb (Only Once)
        if (Input.GetMouseButtonDown(0) && !hasSpawnedJumpOrb)
        {
            SpawnSphere();
            hasSpawnedJumpOrb = true;
        }
    }

    private void SpawnSphere()
    {
        if (spherePrefab != null)
        {
            Vector3 spawnPosition = playerCamera.transform.position + playerCamera.transform.forward * 2;
            GameObject sphere = Instantiate(spherePrefab, spawnPosition, Quaternion.identity);

            // Ensure it has a collider
            SphereCollider sphereCollider = sphere.GetComponent<SphereCollider>();
            if (sphereCollider == null)
            {
                sphereCollider = sphere.AddComponent<SphereCollider>();
            }
            sphereCollider.isTrigger = true;

            // Attach OrbCollision script
            if (sphere.GetComponent<OrbCollision>() == null)
            {
                sphere.AddComponent<OrbCollision>();
            }
        }
        else
        {
            Debug.LogWarning("Sphere prefab is not assigned!");
        }
    }

    public void ApplySpeedBoost(float boostAmount, float duration)
    {
        walkSpeed = originalWalkSpeed * boostAmount;
        runSpeed = originalRunSpeed * boostAmount;
        StartCoroutine(ResetSpeedAfterBoost(duration));
    }

    private IEnumerator ResetSpeedAfterBoost(float duration)
    {
        yield return new WaitForSeconds(duration);
        walkSpeed = originalWalkSpeed;
        runSpeed = originalRunSpeed;
    }

    public void ApplyJumpBoost(float boostAmount, float duration)
    {
        StartCoroutine(JumpBoostCoroutine(boostAmount, duration));
    }

    private IEnumerator JumpBoostCoroutine(float boostAmount, float duration)
    {
        float originalJumpPower = jumpPower;
        jumpPower = boostAmount;


        yield return new WaitForSeconds(duration);

        jumpPower = originalJumpPower;
    }
}
