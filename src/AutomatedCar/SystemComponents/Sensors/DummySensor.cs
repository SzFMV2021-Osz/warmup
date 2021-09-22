namespace AutomatedCar.SystemComponents.Sensors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;

    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = dummyPacket;
        }

        public override void Process()
        {
            Circle circleObject = (Circle)World.Instance.WorldObjects.ElementAt(0);
            Car carObject = World.Instance.ControlledCar;

            dummyPacket.DistanceX = Math.Abs(circleObject.X - carObject.X);
            dummyPacket.DistanceY = Math.Abs(circleObject.Y - carObject.Y);
        }
    }
}
