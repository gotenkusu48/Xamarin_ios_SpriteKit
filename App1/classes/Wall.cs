using System;
using System.Collections.Generic;
using System.Text;
using CoreGraphics;
using SpriteKit;
using UIKit;

namespace App1.classes
{
    public class Wall : SKSpriteNode
    {
        public Wall(UIColor color, CGSize size) : base(color, size)
        {
        }

        public int WallSpeed { get; set; } = 10;

        public void Update()
        {
            Position = new CGPoint(x: Position.X - WallSpeed, y: Position.Y);
        }
    }
}
