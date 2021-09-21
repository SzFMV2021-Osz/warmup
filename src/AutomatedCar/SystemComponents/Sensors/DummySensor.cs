namespace AutomatedCar.SystemComponents.Sensors
{
    using Models;
    using Packets;
    using System;

    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus virtualFunctionBus) 
            : base(virtualFunctionBus)
        {
            dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = dummyPacket;
        }

        public override void Process()
        {
            AutomatedCar car = World.Instance.ControlledCar;
            Circle circle = (Circle)World.Instance.WorldObjects[0];

            dummyPacket.DistanceX = Math.Abs(car.X - circle.X);
            dummyPacket.DistanceY = Math.Abs(car.Y - circle.Y);
        }
    }
}