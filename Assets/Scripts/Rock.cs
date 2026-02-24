using UnityEngine;

public class Rock : MonoBehaviour
{
    [Header("General Rock Stats")]
    [SerializeField] private LayerMask whatDestroysRock;

    [Header("General Rock Stats")]
    [SerializeField] private float normalRockSpeed;
    [SerializeField] private float normalRockGravity;
    [SerializeField] private float normalRockDamage;

    [Header("General Rock Stats")]
    [SerializeField] private float boulderRockSpeed;
    [SerializeField] private float boulderRockGravity;
    [SerializeField] private float boulderRockDamage;

    private Rigidbody2D rockRB;
    private float rockDamage;
    public enum RockType
    {
        Normal,
        Boulder
    }
    public RockType rockType;

    void Start()
    {
        rockRB = GetComponent<Rigidbody2D>();

        InitializeRockStats();
    }

    private void InitializeRockStats()
    {
        if(rockType == RockType.Normal)
        {
            SetVelocity(normalRockSpeed);
            SetRBStats(normalRockGravity);
            SetDamage(normalRockDamage);
        }
        if(rockType == RockType.Boulder)
        {
            SetVelocity(boulderRockSpeed);
            SetRBStats(boulderRockGravity);
            SetDamage(boulderRockDamage);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //will check if the collision is within the layermask
        if ((whatDestroysRock.value & (1 << collision.gameObject.layer)) > 0)
        {
            //add particles, SFX, scrrenshake, damage, destroy the rock

            IDamageable iDamageable = collision.gameObject.GetComponent<IDamageable>();
            if (iDamageable != null)
            {
                iDamageable.Damage(rockDamage);
            }

            Destroy(gameObject);
        }
    }

    private void SetVelocity(float rockSpeed)
    {
        rockRB.linearVelocity = transform.right * rockSpeed;
    }

    private void SetRBStats(float RBStats)
    {
       rockRB.gravityScale = RBStats;
    }
    
    private void SetDamage(float Damage)
    {
        rockDamage = Damage;
    } 
}
