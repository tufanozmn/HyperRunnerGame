using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    ParticleSystem collectParticle = null;

    public int health;
    public Text MyscoreText;
    [SerializeField]
    private int elmas;
    public float moveSpeed = 1;
    public float leftRightSpeed = 4;
    public float limitX;

    private float sens = 5f;
    private float distX;

    bool move;
    
    public Scrollbar healthBar;
    private Animator anim;

    public Transform camTransform;
     void Awake()
    {
        anim = GetComponent<Animator>();
        elmas = PlayerPrefs.GetInt("Elmas: ",0);
    }

   
    void OnCollisionEnter(Collision hedef)
    {
        if(hedef.transform.CompareTag("Engel"))
        {
            move = false;
            anim.SetFloat("Blend",0);
            health--;
            healthBar.size = healthBar.size - 0.333333333f;
            if(health<=0)
            {
                Die();
            }

            
        }
        /*if(hedef.transform.CompareTag("Engel"))
        {
            var healthComponent = Collision.GetComponent<Health>();
        
            if(healthComponent != null)
            {
                healthComponent.Health(1);
            }

        }*/

        
    }

    public void Die(){
        GamePlay.gamePlay.RestartGame();
        move=false;
        GamePlay.gamePlay.isGameStarted=false;
    }


    void OnCollisionExit(Collision hedef)
    {
        if(hedef.transform.CompareTag("Engel"))
        {
            move = true;
            anim.SetFloat("Blend",1);
        }
    }


    void Start()
   {
        MyscoreText.text = "Elmas: " + elmas;
   }

    void Update()
    {
        if(GamePlay.gamePlay.isGameStarted){

            if (Input.GetMouseButton(0))
                distX = Input.GetAxis("Mouse X") * sens;
            else
                distX = 0;
            
            float newX = transform.position.x + leftRightSpeed * distX * Time.deltaTime;
            newX = Mathf.Clamp(newX, -limitX, limitX);
            Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z);
            if(move){
                newPosition += transform.forward * moveSpeed * Time.deltaTime;
            }
            transform.position = newPosition;

            
        }
        
        
    }

    public void StartRunning(){
        GamePlay.gamePlay.isGameStarted=true;
        move=true;
        anim.SetFloat("Blend",1);
    }


    private void OnTriggerEnter(Collider other)
   {
       if(other.CompareTag("Diamond"))
       {
           elmas ++;
           PlayerPrefs.SetInt("geciciElmas", PlayerPrefs.GetInt("geciciElmas") + 1);

           Destroy(other.gameObject);
           MyscoreText.text = "Elmas: " + elmas;

           other.transform.parent.gameObject.transform.Find("Particle System").GetComponent<ParticleSystem>().Play();
       }

       if(other.CompareTag("Finish")){
            move=false;
            anim.SetFloat("Blend",2);
            PlayerPrefs.SetInt("Elmas: ",elmas);
            GamePlay.gamePlay.NextLevel();
            StartCoroutine(camRotate());
        }
   }
   IEnumerator camRotate()
   {
       for(int i = 0; i< 60;i++)
       {
            camTransform.eulerAngles = new Vector3(
    camTransform.eulerAngles.x,
    camTransform.eulerAngles.y + 1,
    camTransform.eulerAngles.z
);
yield return new WaitForSeconds(0.05f);
       }
      
   }
}

/*
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if(this.gameObject.transform.position.x > LevelBoundary.leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime*leftRightSpeed);
                }
            
            }
            

            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if(this.gameObject.transform.position.x < LevelBoundary.rightSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime*leftRightSpeed * -1);
                }
                
            }*/
