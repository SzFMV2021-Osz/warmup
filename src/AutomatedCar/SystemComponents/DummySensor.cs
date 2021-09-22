namespace AutomatedCar.SystemComponents
{
    using Packets;
    using Models;
    using System.Linq;
    using System;
    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;
        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        public override void Process()
        {
            AutomatedCar automatedCar = World.Instance.ControlledCar;
            Circle circle = World.Instance.WorldObjects.OfType<Circle>().First();
            
            this.dummyPacket.DistanceX = Math.Abs(automatedCar.X - circle.X);
            this.dummyPacket.DistanceY = Math.Abs(automatedCar.Y - circle.Y);
        }
    }
}