using UnityEngine;
using System.Collections;

public class EggScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _animator;
    void Start()
    {
        StartCoroutine(CheckEggPosition());
    }

    IEnumerator CheckEggPosition()
    {
        while (true)
        {

            Vector3 viewPort = Camera.main.WorldToViewportPoint(transform.position);

            if (viewPort.y < 0.05)
            {
                _animator.SetTrigger("break");
                _rb.bodyType =RigidbodyType2D.Static;
                Destroy(gameObject, 1);
                break;
            }
            yield return null;
        }
    }
}
