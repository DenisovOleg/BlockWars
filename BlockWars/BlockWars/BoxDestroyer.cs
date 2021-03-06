﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Box2D.XNA;
using Microsoft.Xna.Framework;
using BlockWars.Gameplay;

namespace BlockWars
{
    static class BoxDestroyer
    {
        public static List<Box> Destroy(Box box, World world, float explosionDistance, Player player)
        {
            List<Box> boxes = new List<Box>();

            Vector2 pos = box.mBody.GetPosition();
            Vector2 size = box.mSize;
            Vector2 partBoxSize = size / 2;

            if (size.X < 1f || size.Y < 1)
            {
                return boxes;
            }

            Vector2 force = new Vector2(1.1f / explosionDistance);

            Vector2 partBoxPos = pos - partBoxSize / 2;
            Box partBox = new Box(world, partBoxPos, partBoxSize, box.Texture, false, player);
            partBox.mBody.ApplyLinearImpulse(force * partBox.mBody.GetMass(), Vector2.Zero);
            boxes.Add(partBox);

            partBoxPos = pos + partBoxSize / 2;
            partBox = new Box(world, partBoxPos, partBoxSize, box.Texture, false, player);
            partBox.mBody.ApplyLinearImpulse(force * partBox.mBody.GetMass(), Vector2.Zero);
            boxes.Add(partBox);

            partBoxPos = new Vector2(pos.X + partBoxSize.X / 2, pos.Y - partBoxSize.Y / 2);
            partBox = new Box(world, partBoxPos, partBoxSize, box.Texture, false, player);
            partBox.mBody.ApplyLinearImpulse(force * partBox.mBody.GetMass(), Vector2.Zero);
            boxes.Add(partBox);

            partBoxPos = new Vector2(pos.X - partBoxSize.X / 2, pos.Y + partBoxSize.Y / 2);
            partBox = new Box(world, partBoxPos, partBoxSize, box.Texture, false, player);
            partBox.mBody.ApplyLinearImpulse(force * partBox.mBody.GetMass(), Vector2.Zero);
            boxes.Add(partBox);
            return boxes;
        }
    }
}
