using UnityEngine;
using TrueSync;

namespace CoinPusher
{
	public class CoinSpawner : TrueSyncBehaviour
	{
		[SerializeField]
		private GameObject CoinPrefab;

		[AddTracking]
		private FP cooldown = 0;

		public override void OnSyncedStart()
		{
			tsTransform.position = new TSVector(0.0, 3.0, 0.0);
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
			cooldown -= TrueSyncManager.DeltaTime;
			if (TrueSyncInput.GetByte((byte)InputKey.SpawnCoin) == 0 || cooldown > 0.0) return;
			TrueSyncManager.SyncedInstantiate(CoinPrefab, tsTransform.position, TSQuaternion.identity);
			cooldown = 0.2;
		}
	}

	public enum InputKey
	{
		SpawnCoin,
	}
}