using UnityEngine;
using System.Collections;

public class RampSide : MonoBehaviour {

    public GameObject RampBlock;
    public enum RampDirection { North,South,East,West};
    public RampDirection HighSide;
    // Use this for initialization
    void Start () {
        switch (HighSide)
        {
            case RampDirection.North:
                break;
            case RampDirection.South:
                transform.Rotate(0,180,0);
                break;
            case RampDirection.East:
                transform.Rotate(0, 90, 0);
                break;
            case RampDirection.West:
                transform.Rotate(0, 270, 0);
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
