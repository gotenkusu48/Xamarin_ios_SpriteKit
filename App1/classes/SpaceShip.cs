using System;
using System.Collections.Generic;
using System.Text;
using CoreGraphics;
using Foundation;
using SpriteKit;
using UIKit;

namespace App1.classes
{
    public class SpaceShip : SKSpriteNode
    {
        public SpaceShip()
        {
        }
        

        public SpaceShip(NSCoder coder) : base(coder)
        {
        }

        public SpaceShip(string name) : base(name)
        {
        }

        public SpaceShip(SKTexture texture) : base(texture)
        {
        }

        public SpaceShip(UIColor color, CGSize size) : base(color, size)
        {

        }

        public SpaceShip(SKTexture texture, UIColor color, CGSize size) : base(texture, color, size)
        {
        }

        protected SpaceShip(NSObjectFlag t) : base(t)
        {
        }

        protected internal SpaceShip(IntPtr handle) : base(handle)
        {
        }
    }
}
