using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openMenu : MonoBehaviour
{
    public GameObject Panel;

    public float TotalClicks;

    private void Start()
    {
        Panel.SetActive(false);
    }

    public void OpenPanel() {
        if (Panel != null) {
            bool isOpen = Panel.activeSelf;

            Panel.SetActive(!isOpen);
        }
    }
}
