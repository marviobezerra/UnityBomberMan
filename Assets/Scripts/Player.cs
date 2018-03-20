using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool canCreateBomb = true;
    public PlayerPowersUps powerUps = new PlayerPowersUps();
    public GameObject bomb;
    private Animator animator;
    private Rigidbody2D body;

    const string Position = "Position";
    const string Walk = "Walk";


    private void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!Constants.canMove)
        {

            if (Input.GetKey("space"))
            {
                SceneManager.LoadScene("GameScene");
            }

            return;
        }

        var horizontal = Input.GetAxis(powerUps.HorizontalAxis);
        var vertical = Input.GetAxis(powerUps.VerticalAxis);
        var fire = Input.GetAxis(powerUps.FireAxis);

        if (vertical > 0)
        {
            body.velocity = new Vector2(0, powerUps.moveSpeed);

            animator.SetBool(Walk, true);
            animator.SetInteger(Position, 0);
        }
        else if (horizontal > 0)
        {
            body.velocity = new Vector2(powerUps.moveSpeed, 0);

            animator.SetBool(Walk, true);
            animator.SetInteger(Position, 1);

        }
        else if (vertical < 0)
        {
            body.velocity = new Vector2(0, -powerUps.moveSpeed);

            animator.SetBool(Walk, true);
            animator.SetInteger(Position, 2);
        }
        else if (horizontal < 0)
        {
            body.velocity = new Vector2(-powerUps.moveSpeed, 0);

            animator.SetBool(Walk, true);
            animator.SetInteger(Position, 3);
        }
        else
        {
            animator.SetBool(Walk, false);
            body.velocity = Vector2.zero;
        }

        if (fire > 0 && canCreateBomb && powerUps.canCreateBomb)
        {
            var bombX = Mathf.RoundToInt(transform.position.x);
            var bombY = Mathf.RoundToInt(transform.position.y);

            if (bombX > Constants.WorldBeginX && bombY < Constants.WorldBeginY)
            {
                var newBomb = Instantiate(bomb, new Vector3(bombX, bombY, 0), Quaternion.identity);
                newBomb.GetComponent<Bomb>().setPlayer(this);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            canCreateBomb = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            canCreateBomb = true;
            collision.gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }
}
