using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBook : MonoBehaviour
{
    public ImageShow ImageShow;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ImageShow.Show();
            gameObject.SetActive(false);
        }
    }
}
