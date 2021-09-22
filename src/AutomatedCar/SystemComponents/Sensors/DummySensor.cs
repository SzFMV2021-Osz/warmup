namespace AutomatedCar.SystemComponents.Sensors
{
    using System;
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;

    /// <summary>
    /// A dummy object that calculates the distance between it and the controlled car.
    /// </summary>
    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;

        /// <summary>
        /// Initializes a new instance of the <see cref="DummySensor"/> class.
        /// </summary>
        /// <param name="virtualFunctionBus">Injected virtual function bus.</param>
        public DummySensor(VirtualFunctionBus virtualFunctionBus)
            : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        /// <summary>
        /// Calculates distance between .this and and controlledCar.
        /// </summary>
        public override void Process()
        {
            Circle circle = (Circle)World.Instance.WorldObjects[0];
            AutomatedCar controllerCar = World.Instance.ControlledCar;

            this.dummyPacket.DistanceX = Math.Abs(circle.X - controllerCar.X);
            this.dummyPacket.DistanceY = Math.Abs(circle.Y - controllerCar.Y);
        }
    }
}