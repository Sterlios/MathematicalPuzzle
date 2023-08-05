namespace StateMachine
{
	public class BootstrapState : State
	{
		public BootstrapState(params Transition[] transitions) : base(transitions)
		{
		}

		public override void Start()
		{
		}

		public override void Stop()
		{
		}
	}
}
