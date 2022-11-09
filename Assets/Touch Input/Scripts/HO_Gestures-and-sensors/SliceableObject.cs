using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceableObject : MonoBehaviour, ITappable
{
    [SerializeField] private GameObject[] sliceParts;
    [SerializeField] private GameObject whole;
    public float explodeForce = 1f;

    public void OnTap()
    {
        Slice();
        GameManager.Instance.IncrementScore(2);
    }

    public void OnSliced()
    {
        Slice();
        GameManager.Instance.IncrementScore(1);
    }

    private void Slice()
    {
        Vector3 centroid = Vector3.zero;

        sliceParts[0].transform.parent.gameObject.SetActive(true);
        
        whole.SetActive(false);

        foreach (GameObject obj in sliceParts)
        {
            centroid += obj.transform.position;
        }

        centroid /= sliceParts.Length;

        foreach (GameObject obj in sliceParts)
        {
            obj.transform.SetParent(null);
            obj.GetComponent<Rigidbody>().AddForce((obj.transform.position - centroid).normalized * explodeForce, ForceMode.Impulse);
        }

        // Set the container's layer to ignore raycast so it wont get hit by slicehandler anymore
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }
}
