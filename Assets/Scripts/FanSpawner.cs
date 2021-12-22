using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSpawner : MonoBehaviour
{
    public GameObject fanPrefab;
    public int numberOfRows;
    public int numberOfColumns;
    //int[,] array = new int[4, 2];
    private AnimationInstancing.AnimationInstancing[,] fans;

    public float zDisplacement = 1;
    public float xDisplacement = 1;

    private void Awake()
    {
        fans = new AnimationInstancing.AnimationInstancing[numberOfRows, numberOfColumns];

        for (int i = 0; i < numberOfRows; i++)
        {
            for (int j = 0; j < numberOfColumns; j++)
            {
                GameObject fan = Instantiate(fanPrefab);
                fan.name = "BasicMotionsDummy";
                //fan.GetComponentInChildren<MeshRenderer>().material.color = new Color(numberOfColumns/j, numberOfRows,i, 1);
                fan.transform.position = new Vector3(i * xDisplacement, 0, j * zDisplacement);
                fans[i, j] = fan.GetComponent<AnimationInstancing.AnimationInstancing>();
                
            }
        }
    }

    private void Start()
    {
        PauseAllAnimations();

    }



    private void PauseAllAnimations()
    {
        for (int i = 0; i < numberOfRows; i++)
        {
            for (int j = 0; j < numberOfColumns; j++)
            {
                fans[i, j].Pause();

            }
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha3))
        {
            StartCoroutine(PlayAllWithDelay());
        }
    }

    private IEnumerator PlayAllWithDelay()
    {
        for (int i = 0; i < numberOfRows; i++)
        {
            for (int j = 0; j < numberOfColumns; j++)
            {

                fans[i, j].PlayAnimation(1);

            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    //private IEnumerator PlayWithDelayCoroutine()
    //{
    //    yield retun
    //}
}
