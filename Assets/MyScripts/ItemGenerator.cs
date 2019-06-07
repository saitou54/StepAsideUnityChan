using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
	//carPrefabを入れる
	public GameObject carPrefab;
	//coinPrefabを入れる
	public GameObject coinPrefab;
	//cornPrefabを入れる
	public GameObject conePrefab;
	//スタート地点
	private int startPos = -160;
	//ゴール地点
	private int goalPos = 120;
	//アイテムを出すx方向の範囲
	private float posRange = 3.4f;

	//発展課題
	private GameObject unitychan;
	private float UnityChanPos = 0;
	private float GeneratePos = 0;

	// Use this for initialization
	void Start()
	{
		//発展課題
		this.unitychan = GameObject.Find("unitychan");
		this.GeneratePos = startPos;

		/*
		//一定の距離ごとにアイテムを生成
		for (int i = startPos; i < goalPos; i += 15)
		{
			//どのアイテムを出すのかをランダムに設定
			int num = Random.Range(1, 11);
			if (num <= 2)
			{
				//コーンをx軸方向に一直線に生成
				for (float j = -1; j <= 1; j += 0.4f)
				{
					GameObject cone = Instantiate(conePrefab) as GameObject;
					cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
				}
			}
			else
			{

				//レーンごとにアイテムを生成
				for (int j = -1; j <= 1; j++)
				{
					//アイテムの種類を決める
					int item = Random.Range(1, 11);
					//アイテムを置くZ座標のオフセットをランダムに設定
					int offsetZ = Random.Range(-5, 6);
					//60%コイン配置:30%車配置:10%何もなし
					if (1 <= item && item <= 6)
					{
						//コインを生成
						GameObject coin = Instantiate(coinPrefab) as GameObject;
						coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
					}
					else if (7 <= item && item <= 9)
					{
						//車を生成
						GameObject car = Instantiate(carPrefab) as GameObject;
						car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
					}
				}
			}
		}
		*/
	}

	//発展課題
	// Update is called once per frame
	void Update()
	{
		//Unityちゃんの位置を取得
		UnityChanPos = unitychan.transform.position.z;

		//Unityちゃんの進行方向40-50m先の範囲、かつゴールより手前でオブジェクトを生成する
		if (UnityChanPos + 40 < GeneratePos && UnityChanPos + 50 > GeneratePos && GeneratePos < goalPos)
		{
			//どのアイテムを出すのかをランダムに設定
			int num = Random.Range(1, 11);
			if (num <= 2)
			{
				//コーンをx軸方向に一直線に生成
				for (float j = -1; j <= 1; j += 0.4f)
				{
					GameObject cone = Instantiate(conePrefab) as GameObject;
					cone.transform.position = new Vector3(4 * j, cone.transform.position.y, GeneratePos);
				}
			}
			else
			{

				//レーンごとにアイテムを生成
				for (int j = -1; j <= 1; j++)
				{
					//アイテムの種類を決める
					int item = Random.Range(1, 11);
					//アイテムを置くZ座標のオフセットをランダムに設定
					int offsetZ = Random.Range(-5, 6);
					//60%コイン配置:30%車配置:10%何もなし
					if (1 <= item && item <= 6)
					{
						//コインを生成
						GameObject coin = Instantiate(coinPrefab) as GameObject;
						coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, GeneratePos + offsetZ);
					}
					else if (7 <= item && item <= 9)
					{
						//車を生成
						GameObject car = Instantiate(carPrefab) as GameObject;
						car.transform.position = new Vector3(posRange * j, car.transform.position.y, GeneratePos + offsetZ);
					}
				}
			}
			GeneratePos += 15;
		}
	}
}