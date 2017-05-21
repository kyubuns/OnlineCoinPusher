using UnityEngine;
using TrueSync;

namespace CoinPusher
{
	public class CoinSpawner : TrueSyncBehaviour
	{
		[SerializeField]
		private GameObject CoinPrefab;

		[AddTracking]
		public int Coin;

		[AddTracking]
		private FP Cooldown = 0;

		public override void OnSyncedStart()
		{
			tsTransform.position = new TSVector(0.0, 3.0, 0.0);
			tsTransform.name = "Player_" + owner.Id;
		}

		public override void OnSyncedInput()
		{
			if (Input.GetMouseButtonDown(0))
			{
				TrueSyncInput.SetByte((byte)InputKey.SpawnCoin, 1);
			}
			else
			{
				TrueSyncInput.SetByte((byte)InputKey.SpawnCoin, 0);
			}
		}

		public override void OnSyncedUpdate()
		{
			Cooldown -= TrueSyncManager.DeltaTime;
			if (TrueSyncInput.GetByte((byte)InputKey.SpawnCoin) == 0 || Cooldown > 0.0 || Coin <= 0) return;

			var position = tsTransform.position;
			position.x = TSRandom.Range(-3.0f, 3.0f);
			TrueSyncManager.SyncedInstantiate(CoinPrefab, position, TSQuaternion.identity);
			Cooldown = 0.2;
			Coin--;
		}
	}

	public enum InputKey
	{
		SpawnCoin,
	}
}