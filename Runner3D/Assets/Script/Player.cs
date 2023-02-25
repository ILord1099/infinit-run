using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{       
    
    private CharacterController controller;
    public LayerMask layer;
    public LayerMask coinLayer;
    private float jumpVelocity;
    public float speed;
    public float jumpHeight;
    public float gravity;
    public float horizontalSpeed;
    private bool isMovingLeft;
    private bool isMovingRight;
    public float rayRadius;
    public Animator anim;
    public  bool isDead;
    private GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        
        controller = GetComponent<CharacterController>();// pega o componente character controler que esta anexado ao script    
        gc = FindObjectOfType<GameController>();    
    }

    // Update is called once per frame
    void Update()
    {
        OnCollision();
        Vector3 direction = Vector3.forward * speed;// adiciona "1" no Eixo Z de profundidade 

        if(controller.isGrounded)
        {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    jumpVelocity=jumpHeight;
                }

                if(Input.GetKeyDown(KeyCode.RightArrow)&& transform.position.x <3f && !isMovingRight)
                {
                    isMovingRight = true;
                    StartCoroutine(RightMove()); 
                }
                if(Input.GetKeyDown(KeyCode.LeftArrow)&& transform.position.x > -3f && !isMovingLeft)
                {
                    isMovingLeft = true;
                    StartCoroutine(LeftMove());
                }
        }
        else
        {
            jumpVelocity -=gravity;
        }

        direction.y = jumpVelocity;

        controller.Move(direction*Time.deltaTime);

        
    }

    IEnumerator LeftMove()// courrotine pode ser pausada e controlada por tempo
    {
        for (float i = 0; i < 10; i+= 0.1f)
        {
            controller.Move(Vector3.left *Time.deltaTime * horizontalSpeed);
            yield return null;
        }
        isMovingLeft = false;
    }
    IEnumerator RightMove()
    {
        for(float i = 0; i < 10; i+= 0.1f)
        {
            controller.Move(Vector3.right * Time.deltaTime * horizontalSpeed);
            yield return null;

        }
        isMovingRight = false;
    }

    void OnCollision()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit, rayRadius,layer)&&!isDead)
        {
            //chama gameover
            anim.SetTrigger("die");
             speed = 0;
            jumpHeight = 0;
            jumpVelocity = 0;
            horizontalSpeed = 0; 
            isDead = true;
        Invoke("GameOver",2f);
            
        }
        RaycastHit coinHit;

        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward + new Vector3(0,1f,0)), out coinHit, rayRadius,coinLayer))
        {
            gc.AddCoin();
            Destroy(coinHit.transform.gameObject);
        }
    }
    void GameOver()
    {
        gc.ShowGameOver();
    }
}
