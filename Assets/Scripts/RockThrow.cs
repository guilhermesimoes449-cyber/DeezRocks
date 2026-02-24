using UnityEngine;
using UnityEngine.InputSystem;

public class RockThrow : MonoBehaviour
{
    private PlayerController player;

    [SerializeField]
    private GameObject throwPoint;
    [SerializeField] 
    private Transform throwDirection;
    [SerializeField]
    private GameObject rock;
    private GameObject rockInst;


    private void Start()
    {
        player = GetComponent<PlayerController>();
    }
    private void Update()
    {
        HandleRockDirection();
    }

    private void HandleRockDirection()
    {
       throwPoint.transform.right = player.direction;
    }

    public void OnThrow(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rockInst = Instantiate(rock, throwDirection.position, throwPoint.transform.rotation);
        }
    }  
}
