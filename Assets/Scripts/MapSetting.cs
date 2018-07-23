using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

//https://www.redblobgames.com/grids/hexagons/
//http://www.gisdeveloper.co.kr/?p=217
public class MapSetting : MonoBehaviour {
    //1단계 맵핑 스크립트.
    [Header("base map")]
    private int [,] baseMap;
    private int [,] itemMap;
    private int[,] voidMap;

    [Header("Map info")]
    [Range(1,5)]
    public int level;
    [Range(1, 5)]
    public int playerLevel;

    //---확률분포용
    int RAND_MAX = 0x7fff;
    //--확률분포 테스트용
    int count;
    int now;



    // Use this for initialization
    void Awake() {
        baseMap = new int[12, 10];
        itemMap = new int[12, 10];
        voidMap = new int[12, 10];
        System.Array.Clear(baseMap, 0, baseMap.Length);
        System.Array.Clear(itemMap, 0, itemMap.Length);
        System.Array.Clear(voidMap, 0, voidMap.Length);     //근데 Array.Clear가 있는 마당에 굳이 빈 배열을 만들어야할까?      

        count = 0;
        now = 0;
    }


	void Start () {         //start는 update 직전에 1회
      
	}
	
	// Update is called once per frame
	void Update () {
        //--확률분포 테스트용
        randTest();
        //--테스트 구문 끝
	}


    void copyMap(int[][] origin, int[][] copy)
    {        
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                copy[i][j] = origin[i][j];
            }
        }

    }



    int NDRandom(int start, int end, int level)    //start<=x<=end
    {
        if (level < 1)
            level = 1;
        double result = 0;

        for (int i = 0; i < level; i++)
        {
            result += (double)UnityEngine.Random.Range(start, end) / (double)RAND_MAX;
            result /= (double)level;
        }
        return (int)(result*(end-start)+start);
    }

    private void randTest()
    {
        int rest;
        rest = NDRandom(6, 2200, 15);           //7,2200,20 // 6,2200,15
        now += rest;
        count++;
        Debug.Log("cur=" + rest + " count=" + count + " aver=" + (now / count));
    }
}
