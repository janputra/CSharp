using System;
using System.Collections.Generic;
using System.Text;
using rec.robotino.com;
using System.Collections;
using System.Threading;
using System.Drawing;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// The class Robot demonstrates the usage of the most common robot component classes.
    /// Furthermore it shows how to handle events and receive incoming camera images.
    /// </summary>
    public class Robot
    {
        public delegate void ConnectedEventHandler(Robot sender);
        public delegate void DisconnectedEventHandler(Robot sender);
        public delegate void ErrorEventHandler(Robot sender, rec.robotino.com.Com.Error error);
        public delegate void ImageReceivedEventHandler(Robot sender, Image img);

        protected readonly Com com;
	    protected readonly OmniDrive omniDrive;
        protected readonly Motor motor;
        protected readonly Bumper bumper;
        protected readonly DistanceSensor Distance;
        protected readonly Camera camera;

        private volatile bool isConnected;

        public Robot()
        {
            com = new MyCom(this);
            omniDrive = new OmniDrive();
            bumper = new Bumper();
            camera = new MyCamera(this);
            motor = new Motor();
            Distance = new DistanceSensor();

            omniDrive.setComId(com.id());
            motor.setComId(com.id());
            bumper.setComId(com.id());
            camera.setComId(com.id());
            Distance.setComId(com.id());
        }

        public event ConnectedEventHandler Connected;
        public event DisconnectedEventHandler Disconnected;
        public event ErrorEventHandler Error;
        public event ImageReceivedEventHandler ImageReceived;

        public bool IsConnected
        {
            get
            {
                return isConnected;
            }
        }

        public bool CameraStreaming
        {
            get
            {
                return camera.isStreaming();
            }
            set
            {
                camera.setStreaming(value);
            }
        }

        public virtual void Connect(String hostname, bool blockUntilConnected)
        {
            com.setAddress(hostname);
            com.connect(blockUntilConnected);
            Console.WriteLine("Connecting...");
            
        }
        public virtual void Disconnect()
        {
            com.disconnect();
            Console.WriteLine("Disconnecting...");

        }
        public virtual void SetVelocity(float vx, float vy, float omega)
        {
            omniDrive.setVelocity(vx, vy, omega);
        }

        public virtual void wheel(uint nummotor, float speed)
        {
            motor.setMotorNumber(nummotor);
            motor.setSpeedSetPoint(speed);
         
        }
        public float distance(uint numsensor)
        {
            Distance.setSensorNumber(numsensor);
            return Distance.voltage();
        }



        private class MyCom : Com
        {
            Robot robot;

            public MyCom(Robot robot)
            {
                this.robot = robot;
            }

            public override void connectedEvent()
            {
                Console.WriteLine("Connected");
                robot.isConnected = true;
                if (robot.Connected != null)
                    robot.Connected.BeginInvoke(robot, null, null);
            }

            public override void connectionClosedEvent()
            {
                Console.WriteLine("Disconnected");
                robot.isConnected = false;
                if (robot.Disconnected != null)
                    robot.Disconnected.BeginInvoke(robot, null, null);
            }

            public override void errorEvent(Error error, String errorStr)
            {
                Console.WriteLine("Error occured: " + error);
                if (robot.Error != null)
                    robot.Error.BeginInvoke(robot, error, null, null);
            }
        }

        private class MyCamera : Camera
        {
            Robot robot;

            public MyCamera(Robot robot)
            {
                this.robot = robot;
            }

            public override void imageReceivedEvent(Image data, uint dataSize, uint width, uint height, uint numChannels, uint bitsPerChannel, uint step)
            {
                if (robot.ImageReceived != null)
                    robot.ImageReceived.BeginInvoke(robot, data, null, null);
            }
        }
    }
}
