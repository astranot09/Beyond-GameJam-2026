using UnityEngine;
using UnityEngine.InputSystem;

public class DogScript : MonoBehaviour
{
    public static DogScript instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public float health;
    public float woof;
    
    public void Woof(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            woof++;
        }
    }
    private void FixedUpdate()
    {
        
    }
}
