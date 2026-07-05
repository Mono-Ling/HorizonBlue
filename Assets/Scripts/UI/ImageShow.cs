using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageShow : MonoBehaviour
{
    public Sprite[] sprites;
    public Image Image;
    private int _index = 0;

    private bool _canInput = false;
    public void Show()
    {
        if (_index >= sprites.Length)
        {
            return;
        }
        Image.sprite = sprites[_index];
        Image.gameObject.SetActive(true);
        _canInput = true;
        _index++;
    }

    private void Update()
    {
        if (_canInput && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        {
            _canInput = false;
            Image.gameObject.SetActive(false);
        }
    }
}
