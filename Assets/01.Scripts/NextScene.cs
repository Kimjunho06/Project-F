using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextScene : MonoBehaviour
{
    public Image image;
    bool isClick;

    private void Start()
    {
        isClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isClick)
            {
                isClick = true;
                StartCoroutine(Fade());
            }
        }
    }

    private IEnumerator Fade()
    {
        while (image.color.a < 1)
        {
            Color color = image.color;
            color.a += 0.1f;
            image.color = color;
            yield return new WaitForSeconds(0.05f);
        }
        SceneManager.LoadScene("Main");
    }
}
