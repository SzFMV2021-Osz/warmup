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
            this.dummyPacket.DistanceX = World.Instance.WorldObjects[0].X - World.Instance.ControlledCar.X;
            this.dummyPacket.DistanceY = World.Instance.WorldObjects[0].Y - World.Instance.ControlledCar.Y;
        }
    }
} 