using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemsCollector : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI ui;
    private Animator anim;
    int count = 0;

    void Start()
    {
        anim = ui.GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            ui.GetComponent<Animator>().SetBool("isTriggered", false);
            count++;
            Debug.Log("oui");
            ui.SetText(count.ToString());
            anim.Play("Base Layer.BumpAnim", 0, 0);
            Destroy(other.gameObject);
        }
    }
}
