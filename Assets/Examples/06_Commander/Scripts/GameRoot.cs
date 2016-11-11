using UnityEngine;
using SimpleContainer.Container;

namespace SimpleContainer.Examples.Commander
{
	public class GameRoot : ContextRoot
    {
		protected ICommandDispatcher dispatcher;

		public override void SetupContainers()
        {
			// ��������
			var container = AddContainer<InjectionContainer>();

			container
				// ע�������������չ
				.RegisterAOT<CommanderContainerAOT>()
				.RegisterAOT<EventContainerAOT>()
				.RegisterAOT<UnityContainerAOT>()
                // ע�� "uMVVMCS.Examples.Commander" �����ռ��µ����� Command
                .RegisterCommands("SimpleContainer.Examples.Commander")
				// �� prefab
				.Bind<Transform>().ToPrefab("06_Commander/Prism");
		
			// ��ȡ commandDispatcher �Ա��� Init() �����е���
			dispatcher = container.GetCommandDispatcher();
		}
		
		public override void Init()
        {
			dispatcher.Dispatch<SpawnGameObjectCommand>();
		}
	}
}