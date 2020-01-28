using UnityEngine;


public class PlayWeb : Movement 
{

    //ATTRIBUTES
    private float Min,Max,Offset = 0.75f,PosX;
    private Vector2 Screen_Dimensions;
    private Rigidbody rb;
    private Animator anim;
    

    //CONSTRUCTOR
    public PlayWeb(GameObject body)
    {
        Screen_Dimensions = Observer.getScreenDimensions()/2;
        Min = -Screen_Dimensions.x + Offset;
        Max = Screen_Dimensions.x - Offset;
        anim = body.GetComponent<Animator>();
    } 

    //Overriden method
    public override void move(GameObject body)
    {
        rb = body.GetComponent<Rigidbody>();
        PosX = rb.position.x + (Input.GetAxis("Horizontal") * Time.deltaTime * Speed);
        anim.SetFloat("Xvalue",Input.GetAxis("Horizontal"));
        rb.position = new Vector3(Mathf.Clamp(PosX,Min,Max), rb.position.y, rb.position.z);

    }

}