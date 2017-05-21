using UnityEngine;
using TrueSync;

namespace CoinPusher
{
	public class CoinCatcher : TrueSyncBehaviour
	{
		public void OnSyncedTriggerEnter(TSCollision other)
		{
			if (other.gameObject.tag != "Coin") return;
			foreach (var player in GameObject.FindGameObjectsWithTag("Player"))
			{
				player.GetComponent<CoinSpawner>().Coin++;
			}
			TrueSyncManager.SyncedDestroy(other.gameObject);
		}
	}
}