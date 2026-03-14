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

    [SerializeField] private float health;
    public float woof;

    [SerializeField] private MovementKakak movementKakak;
    
    public void Woof(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Debug.Log("jalan oi");
            //SoundManager.instance.PlaySFX(SoundManager.instance.bark);
            movementKakak.DontPanic();
        }
    }
    public void TakeDamage(float damage)
    {
        health-=damage;
        if(health <= 0)
            SceneController.instance.RestartLevel();
    }
}
