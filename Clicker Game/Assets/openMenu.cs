using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openMenu : MonoBehaviour
{
    public GameObject Panel;

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
