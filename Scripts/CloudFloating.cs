using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudFloating : MonoBehaviour
{
    private float Speed = 1f;
    private float EndPosX;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * Speed);

        if (transform.position.x > EndPosX)
        {
            Destroy(gameObject);
        }
    }

    public void StartFloating(float speed, float endPosX)
    {
        Speed = speed;
        EndPosX = endPosX;
    }
}
