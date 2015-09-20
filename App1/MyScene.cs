using System;
using System.Collections.Generic;
using System.Linq;
using App1.classes;
using CoreFoundation;
using System.Timers;
using CoreGraphics;
using Foundation;
using SpriteKit;
using UIKit;

namespace App1
{
    public sealed class MyScene : SKScene
    {

        public List<Wall> Walls { get; set; } = new List<Wall>();            //流れてくる壁
        public SKSpriteNode SpaceShip { get; set; }     //自機

        public SKSpriteNode CeilingNode { get; set; }      //天井
        public SKSpriteNode FloorNode { get; set; }             //床


        public MyScene(CGSize size) : base(size)
        {
            // Setup your scene here
            BackgroundColor = new UIColor(0.15f, 0.15f, 0.3f, 1.0f);

            var myLabel = new SKLabelNode("Chalkduster")
            {
                Text = "Hello, World!",
                FontSize = 30,
                Position = new CGPoint(Frame.Width / 2, Frame.Height / 2)
            };
            AddChild(myLabel);

            CeilingNode = new SKSpriteNode
            {
                Color = UIColor.Orange,
                Size = new CGSize(Frame.Size.Width, 50),
                Position = new CGPoint(Frame.GetMaxX() / 2, Frame.GetMaxY() - 20),

            };
            CeilingNode.PhysicsBody = SKPhysicsBody.CreateRectangularBody(CeilingNode.Size);
            CeilingNode.PhysicsBody.Dynamic = false;
            AddChild(CeilingNode);

            FloorNode = new SKSpriteNode
            {
                Color = UIColor.Orange,
                Size = new CGSize(Frame.Size.Width, 50),
                Position = new CGPoint(Frame.GetMaxX() / 2, 20),

            };
            FloorNode.PhysicsBody = SKPhysicsBody.CreateRectangularBody(FloorNode.Size);
            FloorNode.PhysicsBody.Dynamic = false;
            AddChild(FloorNode);

            SpaceShip = new SKSpriteNode("Spaceship")
            {
                Position = new CGPoint(Frame.X + 100, Frame.GetMidY()),
                XScale = 0.4f,
                YScale = 0.4f,
            };
            SpaceShip.PhysicsBody = SKPhysicsBody.CreateRectangularBody(SpaceShip.Size);
            AddChild(SpaceShip);

            var timer = new Timer()
            {
                Enabled = true,
                AutoReset = true,
                Interval = 300
            };
            timer.Elapsed += (sender, args) =>
            {
                var wall1 = new Wall(UIColor.Blue, new CGSize(50, Frame.Height - 100))
                {
                    Position = new CGPoint(Frame.GetMaxX(), Frame.GetMidY())
                };
                wall1.PhysicsBody = SKPhysicsBody.CreateRectangularBody(wall1.Size);

                AddChild(wall1);
                this.Walls.Add(wall1);
            };
        }



        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            // Called when a touch begins
            //foreach (var touch in touches)
            //{
            //    var location = ((UITouch)touch).LocationInNode(this);
            //}

            SpaceShip.PhysicsBody.Velocity = new CGVector(0, 1000);
        }


        public override void Update(double currentTime)
        {
            // Run before each frame is rendered
            base.Update(currentTime);

            //壁の状態をアップデート
            Walls.Select(wall => wall.Position.X < 0);
            //座標がX0より少ないものは取り除く
            Walls.RemoveAll(wall => wall.Position.X < 0);
        }
    }
}