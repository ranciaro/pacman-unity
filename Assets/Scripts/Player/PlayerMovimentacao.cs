using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovimentacao : MonoBehaviour
{
    private IDictionary<Vector3, bool> axisDirection;
    private bool isStuck = false;
    private Vector3 axisStuck = Vector3.zero;
    private Vector3[] directions = new Vector3[4]
    {
    Vector3.forward,
    Vector3.back,
    Vector3.left,
    Vector3.right
    };

    public float rayCastDistance = 1;
    private Rigidbody rigidbody;
    public float velocidade = 2;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        axisDirection = new Dictionary<Vector3, bool>();

        axisDirection.Add(Vector3.forward, false);
        axisDirection.Add(Vector3.back, false);
        axisDirection.Add(Vector3.left, false);
        axisDirection.Add(Vector3.right, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            Movimentar(Vector3.forward);
        else if (Input.GetKeyDown(KeyCode.S))
            Movimentar(Vector3.back);
        else if (Input.GetKeyDown(KeyCode.A))
            Movimentar(Vector3.left);
        else if (Input.GetKeyDown(KeyCode.D))
            Movimentar(Vector3.right);
    }

    private void FixedUpdate()
    {
        //int layerMask = 1 << 8;
        //layerMask = ~layerMask;

        //foreach (var direction in directions)
        //{
        //    if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out RaycastHit hit, rayCastDistance, layerMask))
        //    {
        //        if (!isStuck && axisStuck == Vector3.zero)
        //        {
        //            isStuck = true;
        //            axisStuck = direction;
        //            rigidbody.velocity = Vector3.zero;
        //        }
                    
        //        axisDirection[direction] = true;
        //        Debug.DrawRay(transform.position, transform.TransformDirection(direction) * hit.distance, Color.green, 0.01f);
        //    }
        //    else
        //    {
        //        if (axisStuck == direction)
        //            axisStuck = Vector3.zero;

        //        axisDirection[direction] = false;
        //        Debug.DrawRay(transform.position, transform.TransformDirection(direction) * rayCastDistance, Color.red, 0.01f);
        //    }
        //}
        //Debug.Log(axisDirection);        
    }
    private void Movimentar(Vector3 direction)
    {
        var hit = axisDirection.First(x => x.Key == direction).Value;

        if (!hit)
        {
            rigidbody.velocity = direction * velocidade;
            isStuck = false;            
        }       
    }
}