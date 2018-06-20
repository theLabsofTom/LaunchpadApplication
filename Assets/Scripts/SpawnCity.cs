using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCity : MonoBehaviour
{
    [Tooltip("The buildings used to populate the city")]
    public GameObject[] Buildings;
    [Tooltip("The number of buildings along the width of a block")]
    public int BlockWidth;
    [Tooltip("The number of buildings along the depth of a block")]
    public int BlockDepth;
    [Tooltip("How far apart the building meshes should be, root transform to root transform.")]
    public float IntraBlockSpacing;
    [Tooltip("How far apart all the blocks should be, edge to edge")]
    public float MainStreetWidth;
    [Tooltip("The city will be this number of blocks across.")]
    public int CitySize;

    public bool IncludeCoins;
    [Header("Coin Settings")]
    public GameObject Coin;
    [Tooltip("The distance between coins")]
    public float CoinSpacing;

    // Use this for initialization
    private void Start()
    {
        for (int i = 0; i < CitySize; i++)
        {
            for (int j = 0; j < CitySize; j++)
            {
                // Calculate the offset from the transform's origin to start placing buildings
                Vector3 blockStartingPoint = new Vector3((MainStreetWidth + (BlockDepth * IntraBlockSpacing)) * j, 0, (MainStreetWidth + (BlockWidth * IntraBlockSpacing)) * i);
                // Place a block at that start point.
                MakeBlock(blockStartingPoint);
                // One the block exists, place the coins in the middle of the street.
                Vector3 coinStartPoint = blockStartingPoint - new Vector3(MainStreetWidth, 0, MainStreetWidth);
                // Go along one edge of the block, then the other.
                PlaceCoins(coinStartPoint, coinStartPoint - new Vector3(IntraBlockSpacing * BlockDepth + MainStreetWidth, 0, 0));
                PlaceCoins(coinStartPoint, coinStartPoint - new Vector3(0, 0, IntraBlockSpacing * BlockDepth + MainStreetWidth));
            }
        }
        float totalDepth = ((BlockDepth * IntraBlockSpacing)) * CitySize;
        float totalWidth = ((BlockWidth * IntraBlockSpacing)) * CitySize;
        // Once all the blocks have been placed, the outer edge of the city will not have any coins along it so add them now.
        Vector3 outerCorner = new Vector3(totalDepth + MainStreetWidth, 0, totalWidth + MainStreetWidth);
        PlaceCoins(outerCorner, outerCorner + new Vector3(totalDepth + MainStreetWidth * 2, 0, 0));
        PlaceCoins(outerCorner, outerCorner + new Vector3(0, 0, totalDepth + MainStreetWidth * 2));
        // Move the city back so that the middle of the city is at (0,0,0)
        transform.position = new Vector3(-totalDepth / 2, 0, -totalWidth / 2);
    }

    private void PlaceCoins(Vector3 startPoint, Vector3 endPoint)
    {
        var alongLine = startPoint - endPoint;
        int numberOfCoins = Mathf.FloorToInt(alongLine.magnitude / CoinSpacing);
        Vector3 distanceBetweenCoins = alongLine / numberOfCoins; // Divide the line up into segments so that a coin can be placed at the end of each segment.
        for (int i = 0; i < numberOfCoins; i++)
        {
            Instantiate(Coin, startPoint + (distanceBetweenCoins * i), Coin.transform.rotation, transform);
        }
    }

    private void MakeBlock(Vector3 startingPoint)
    {
        for (int d = 0; d < BlockDepth; d++)
        {
            for (int i = 0; i < BlockWidth; i++)
            {
                Vector3 position = new Vector3(IntraBlockSpacing * d + startingPoint.x, startingPoint.y, IntraBlockSpacing * i + startingPoint.z);
                Instantiate(Buildings[UnityEngine.Random.Range(0, Buildings.Length - 1)], position, Quaternion.identity, transform);
            }
        }
    }
}
