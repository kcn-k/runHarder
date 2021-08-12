using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public GameObject platform;
    public Transform generationPoint;
    public float platformDistance;
    public float platformWidth;
    public float distanceMin;
    public float distancemax;
    
    //public GameObject[] platforms;
    private int platformSelector;
    private float[] platformWidths;

    public ObjectPool[] theObjectPools;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    private CoinGenerator coinGen;
    public float randomCoinLimit;

    public float randomSpikeLimit;
    public ObjectPool spikePool;

    // Start is called before the first frame update
    void Start()
    {
        //platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
        platformWidths= new float[theObjectPools.Length];
        for(int i = 0; i< theObjectPools.Length; i++){
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
        
        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        coinGen = FindObjectOfType<CoinGenerator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.x< generationPoint.position.x){
            platformDistance = Random.Range(distanceMin, distancemax);
            platformSelector = Random.Range(0, theObjectPools.Length);
            
            heightChange = transform.position.y +Random.Range(maxHeightChange, -maxHeightChange);
            if (heightChange> maxHeight){
                heightChange=maxHeight;
            }else if(heightChange<minHeight){
                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + platformDistance, heightChange, transform.position.z);
            
            

            //Instantiate(platform, transform.position, transform.rotation);
            /**instead of instatiating i created an object pool where platforms are stored - uses less resources **/
            GameObject newPlatform = theObjectPools[platformSelector].getPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
            if(Random.Range(0f,100f)<randomCoinLimit){
                coinGen.spawnCoins(new Vector3(transform.position.x, transform.position.y+1f, transform.position.z));
            }
            if(Random.Range(0f,100f)<randomSpikeLimit){
                GameObject newSpike = spikePool.getPooledObject();

                float spikeXPosition = Random.Range(-platformWidths[platformSelector] / 2f + 1f, platformWidths[platformSelector] / 2f -1f);

                Vector3 spikePosition = new Vector3(spikeXPosition, 0.5f, 0f);

                newSpike.transform.position = transform.position + spikePosition;
                newSpike.transform.rotation = transform.rotation;
                newSpike.SetActive(true);
            }
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);

        }

    }
}
