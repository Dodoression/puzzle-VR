using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class PieceSlot : MonoBehaviour
{
    private int slotID;

    [SerializeField]
    private AudioSource audioSnap;

    private void OnEnable()
    {
        slotID = GetComponent<SlotID>().slotID;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<PieceID>())
        {
            return;
        }

        if (other.GetComponent<PieceID>().pieceID == slotID)
        {
            other.GetComponent<XRGrabInteractable>().interactorsSelecting.Clear();
            
            other.GetComponent<PieceID>().refPiece.SetActive(true);
            other.GetComponent<MeshCollider>().enabled = false;
            other.gameObject.SetActive(false);

            audioSnap.Play();

            if (MainManager.Instance.runTimer)
            {
                MainManager.Instance.numOfPutPieces++;
            }
        }
    }
}
