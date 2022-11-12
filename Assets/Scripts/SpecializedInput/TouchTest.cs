using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour
{
    public Sprite BeganSprite;
    public Sprite MovedSprite;
    public Sprite StationarySprite;
    public Sprite EndedSprite;

    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        int touchCount = Input.touchCount;

        if (touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            Debug.Log($"Finger state: {t.phase}");
            
            if (t.phase != TouchPhase.Ended)
            {
                Ray r = Camera.main.ScreenPointToRay(t.position);
                RaycastHit hit = new RaycastHit();

                if (Physics.Raycast(r, out hit, Mathf.Infinity))
                {
                    Debug.Log($"Hit: { hit.collider.name }");
                    _spriteRenderer.sprite = MovedSprite;
                }
                else
                {
                    _spriteRenderer.sprite = StationarySprite;
                }
            }
            else
            {
                _spriteRenderer.sprite = BeganSprite;
            }
        }
        else
        {
            _spriteRenderer.sprite = EndedSprite;
        }
    }

    private void OnDrawGizmos()
    {
        int touchCount = Input.touchCount;

        if (touchCount > 0)
        {
            for (int i = 0; i < Input.touches.Length; i++)
            {
                Touch t = Input.GetTouch(i);

                Ray r = Camera.main.ScreenPointToRay(t.position);

                switch (t.fingerId)
                {
                    case 0: Gizmos.DrawIcon(r.GetPoint(10), "Orbs/Airless"); break;
                    case 1: Gizmos.DrawIcon(r.GetPoint(10), "Orbs/Curseless"); break;
                    case 2: Gizmos.DrawIcon(r.GetPoint(10), "Orbs/Blless"); break;
                    case 3: Gizmos.DrawIcon(r.GetPoint(10), "Orbs/Flameless"); break;
                    case 4: Gizmos.DrawIcon(r.GetPoint(10), "Orbs/Orb of Venom"); break;
                    default: Gizmos.DrawIcon(r.GetPoint(10), "Orbs/Emptyless"); break;
                }
            }
            
            
        }
    }
}
