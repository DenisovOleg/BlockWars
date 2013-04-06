﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame2.UI
{
    abstract class UIControl
    {
        public Vector2 Position { get; set; }

        public bool Visible { get; set; }

        public bool Enable { get; set; }

        protected SpriteBatch mSpriteBatch;

        public UIControl(SpriteBatch spriteBatch)
        {
            Position = Vector2.Zero;
            Visible = true;
            Enable = true;
            mSpriteBatch = spriteBatch;
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw();
    }
}
