using UnityEngine;
using System.Collections;

public class CloseItemView : MonoBehaviour
{
    public GameObject itemView;
    public GameObject laboSheet;

    private void Update()
    {
        if (Input.GetMouseButton(1) || Input.GetKeyDown(KeyCode.Escape))
        {
            itemView.SetActive(false);
            laboSheet.SetActive(false);
        }
        
    }
}
