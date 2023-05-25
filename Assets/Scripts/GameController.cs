using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Bridge _bridge;
    [SerializeField] private Chest _chest;
    [SerializeField] private GameObject _torches;

    private bool _isPotionSelected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bridge") && _isPotionSelected == false)
        {
            _bridge.OnBreak.Invoke();
        }

        if (other.CompareTag("Chest"))
        {
            _chest.OnOpenChest.Invoke();
        }

        if (other.CompareTag("Potion"))
        {
            other.gameObject.SetActive(false);

            var outline = gameObject.GetComponent<Outline>();
            outline.OutlineWidth = 4;

            _isPotionSelected = true;
        }

        if (other.CompareTag("turnTorches"))
        {
            _torches.SetActive(true);
        }
    }
}