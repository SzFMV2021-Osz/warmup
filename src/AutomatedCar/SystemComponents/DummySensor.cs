namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;
    class DummySensor : SystemComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DummySensor"/> class.
        /// </summary>
        /// <param name="virtualFunctionBus">R.</param>
        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.virtualFunctionBus = virtualFunctionBus;
            this.DummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.DummyPacket;
        }

        /// <summary>
        /// Gets or sets the X coordinate.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets the Dummypacket.
        /// </summary>
        public DummyPacket DummyPacket { get; set; }

        /// <summary>
        /// Process.
        /// </summary>
        public override void Process()
        {
            this.Y = World.Instance.WorldObjects[0].Y - World.Instance.ControlledCar.Y;
            this.X = World.Instance.WorldObjects[0].X - World.Instance.ControlledCar.X;
            /*
            this.DummyPacket.DistanceX = this.X;
            this.DummyPacket.DistanceY = this.Y;
            virtualFunctionBus.RegisterComponent(this);
            */
        }
    }
}
