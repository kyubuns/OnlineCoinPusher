using TrueSync;

namespace CoinPusher
{
	public class CoinCleaner : TrueSyncBehaviour
	{
		public void OnSyncedTriggerEnter(TSCollision other)
		{
			if (other.gameObject.tag != "Coin") return;
			TrueSyncManager.SyncedDestroy(other.gameObject);
		}
	}
}