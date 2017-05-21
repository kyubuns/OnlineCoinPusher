using TrueSync;

namespace CoinPusher
{
	public class Pusher : TrueSyncBehaviour
	{
		TSVector InitPosition;

		public override void OnSyncedStart()
		{
			InitPosition = tsTransform.position;
		}

		public override void OnSyncedUpdate()
		{
			var position = new TSVector(InitPosition.x, InitPosition.y, InitPosition.z + TSMath.Sin(TrueSyncManager.Time));
			tsRigidBody.MovePosition(position);
		}
	}
}