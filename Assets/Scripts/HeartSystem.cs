using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component manages the hit points system.
 */

public class HeartSystem : MonoBehaviour {
    [SerializeField] protected GameObject Heart;
    [SerializeField] protected uint MaxNumberOfHeart = 5;
    [SerializeField] protected uint NumberOfHeartAtStart = 3;
    [SerializeField] protected float SpacesBetweenHearts = 1.3f;
    [SerializeField] protected Vector3 PositionOfTheFirstHeart;
    [SerializeField] string DamageTriggeringTag;
    [SerializeField] string HealingTriggeringTag;


    private int NumberOfHeart = 0;
    private  GameObject[] Hearts;
    // Start is called before the first frame update
    void Start() {
        Hearts = new GameObject[MaxNumberOfHeart];
        for (int i = 0; i < NumberOfHeartAtStart; i++) {
            Vector3 positionOfSpawnedObject = new Vector3(PositionOfTheFirstHeart.x + (NumberOfHeart* SpacesBetweenHearts), PositionOfTheFirstHeart.y, PositionOfTheFirstHeart.z);
            Quaternion rotationOfSpawnedObject = Quaternion.identity;  // no rotation.
            GameObject newObject = Instantiate(Heart, positionOfSpawnedObject, rotationOfSpawnedObject);
            Hearts[NumberOfHeart] = newObject;
            NumberOfHeart++;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == DamageTriggeringTag) Damage(other);
        if (other.tag == HealingTriggeringTag) Heal(other);
    }

    private void Damage(Collider2D other)
    { //  A function responsible for damaging the player
        Destroy(Hearts[NumberOfHeart - 1]);
        NumberOfHeart--;
        Destroy(other.gameObject);
        if (NumberOfHeart == 0) Destroy(this.gameObject);
    }


    public int GetNumberOfHeart() {
        return NumberOfHeart;
    }
    private void Heal(Collider2D other)
    {//  A function responsible for healing the player
        if (NumberOfHeart < MaxNumberOfHeart)
        {
            Destroy(other.gameObject);
            Vector3 positionOfSpawnedObject = new Vector3(PositionOfTheFirstHeart.x + (NumberOfHeart * SpacesBetweenHearts), PositionOfTheFirstHeart.y, PositionOfTheFirstHeart.z);
            Quaternion rotationOfSpawnedObject = Quaternion.identity;  // no rotation.
            GameObject newObject = Instantiate(Heart, positionOfSpawnedObject, rotationOfSpawnedObject);
            Hearts[NumberOfHeart] = newObject;
            NumberOfHeart++;
        }

    }
}
