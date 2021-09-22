namespace AutomatedCar.SystemComponents
{
    using System;
    using AutomatedCar.SystemComponents.Packets;
    using AutomatedCar.Models;

    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket { get; }
        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }
        public override void Process()
        {
            Circle circle = (Circle)World.Instance.WorldObjects[0];
            AutomatedCar automatedCar = World.Instance.ControlledCar;

            this.dummyPacket.DistanceX = Math.Abs(circle.X - automatedCar.X);
            this.dummyPacket.DistanceY = Math.Abs(circle.Y - automatedCar.Y);
        }
    }
}
