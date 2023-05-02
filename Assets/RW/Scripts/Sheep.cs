using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    //For the Sheep GameObjects
    public float runSpeed;
    public float gotHayDestroyDelay;
    private bool hitByHay;

    //For the Sheep dropper GameObject
    public float dropDestroyDelay; // 1
    private Collider myCollider; // 2
    private Rigidbody myRigidbody;

    //For the SheepSpawner
    private SheepSpawner sheepSpawner;

    //For the heart GameObject
    public float heartOffset; // 1
    public GameObject heartPrefab; // 2

    // Start is called before the first frame update
    void Start()
    {
        //For the Sheep dropper GameObject
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }

    private void HitByHay()
    {
        sheepSpawner.RemoveSheepFromList(gameObject); //Bc we have added the SheepSpawner

        hitByHay = true; // 1
        runSpeed = 0; // 2
        Destroy(gameObject, gotHayDestroyDelay); // 3

        //For the heart GameObject
        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity);

        //Animating the sheep
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>(); ; // 1
        tweenScale.targetScale = 0; // 2
        tweenScale.timeToReachTarget = gotHayDestroyDelay; // 3

        //For playing sounds
        SoundManager.Instance.PlaySheepHitClip();

        //For GameStateManager: increment saved sheep counter
        GameStateManager.Instance.SavedSheep();
    }

    private void OnTriggerEnter(Collider other) // 1
    {
        if (other.CompareTag("Hay bale") && !hitByHay) // 2
        {
            Destroy(other.gameObject); // 3
            HitByHay(); // 4
        }
        else if (other.CompareTag("DropSheep")) //For Sheep Dropper object / funcitonalities
        {
            Drop();
        }
    }

    //For the Sheep Dropper GameObject (in order to drop the sheeps)
    private void Drop()
    {
        //For GaneStateManager: increment dropeed sheep counter
        GameStateManager.Instance.DroppedSheep();

        //Do the drop
        sheepSpawner.RemoveSheepFromList(gameObject); //Bc we have added the SheepSpawner
        myRigidbody.isKinematic = false; // 1
        myCollider.isTrigger = false; // 2
        Destroy(gameObject, dropDestroyDelay); // 3

        //For playing sounds
        SoundManager.Instance.PlaySheepDroppedClip();
    }

    //Gets a reference to a SheepSpawner and caches it for later use
    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }
}
