using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource attackSFX;
    private GameManager gameManager;
    public float _cooldown, timer = 0;
    private bool _canAttack = false;


    void Start()
    {
        gameManager = GameManager.Instance;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !_canAttack)
        {
            Attack();
        }
        if (_canAttack)
        {
            timer += Time.deltaTime;
            if (timer >= _cooldown)
            {
                _canAttack = false;
                animator.SetBool("Attack", false);
                timer = 0;
                gameManager.PlayerAttack = false;
            }
        }
    }
    private void Attack()
    {
        if (!_canAttack)
        {
            _canAttack = true;
            animator.SetBool("Attack", true);
            attackSFX.Play();
            gameManager.PlayerAttack = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(StringConstant.ObjectTags.DEADZONE))
        {
            animator.SetBool("Dead", true);
            gameManager.UpdateHealth(100);
        }
    }
}
