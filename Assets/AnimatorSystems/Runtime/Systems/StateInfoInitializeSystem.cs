using Unity.Entities;

namespace Parabole.AnimatorSystems
{
	[UpdateInGroup(typeof(LateSimulationSystemGroup))]
	[UpdateBefore(typeof(AnimatorOverrideSystem))]
	public class StateInfoInitializeSystem : SystemBase
	{
		private EntityQuery query;

		protected override void OnCreate()
		{
			RequireForUpdate(query);
		}

		protected override void OnUpdate()
		{
			Entities.WithStructuralChanges().WithStoreEntityQueryInField(ref query)
				.WithNone<CurrentStateInfo>()
				.WithAll<UpdateStateInfo>()
				.ForEach((Entity entity, DotsAnimator dotsAnimator) =>
				{
					var stateInfoBuffer = EntityManager.AddBuffer<CurrentStateInfo>(entity);

					for (int i = 0; i < dotsAnimator.Animator.layerCount; i++)
					{
						stateInfoBuffer.Add(new CurrentStateInfo());
					}
				}).Run();
		}
	}
}