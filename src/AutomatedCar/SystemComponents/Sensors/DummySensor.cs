using AutomatedCar.Models;
using AutomatedCar.SystemComponents.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedCar.SystemComponents
{
    public class DummySensor : SystemComponent
    {
        private DummyPacket packet;

        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.packet = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.packet;
        }

        public override void Process()
        {
            var circle = World.Instance.WorldObjects.ElementAt(0);

            int dX = Math.Abs(circle.X - World.Instance.ControlledCar.X);
            int dY = Math.Abs(circle.Y - World.Instance.ControlledCar.Y);

            this.packet.DistanceX = (int)dX;
            this.packet.DistanceY = (int)dY;

            this.virtualFunctionBus.DummyPacket = this.packet;
        }
    }
}
