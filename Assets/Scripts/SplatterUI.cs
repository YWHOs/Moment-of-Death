using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplatterUI : MonoBehaviour
{
    [SerializeField] Image splatter;
    [SerializeField] float delay;
    // Start is called before the first frame update
    void Start()
    {
        splatter.enabled = false;
    }

    public void ShowImage()
    {
        StartCoroutine(SplatterCoroutine());
    }
    IEnumerator SplatterCoroutine()
    {
        splatter.enabled = true;
        yield return new WaitForSeconds(delay);
        splatter.enabled = false;
    }
}
