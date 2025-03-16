using System.Collections;
using UnityEngine;

public class EggScript : MonoBehaviour
{
    // 2 var to take 2 component
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // run start corotine to continue check position
        StartCoroutine(CheckEggPosition());
    }

    // Make enumerator to check height status to break
    IEnumerator CheckEggPosition ()
    {


        while (true)
        {
            // logic check position and break when satisfy height

            Vector3 viewPort = Camera.main.WorldToViewportPoint(transform.position);

            if (viewPort.y < 0.05)
            {
                _animator.SetTrigger("break");
                _rb.bodyType = RigidbodyType2D.Static; //??
                Destroy(gameObject, 1);
                break;
            }

            yield return null;
        }
    }
}
