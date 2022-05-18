using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nebula.Engine.GUI;
using Nebula.Engine.Graphics;

namespace Nebula.Engine.GUI
{
    public class Container : Widget
    {
        private Dictionary<Panel, (int, int)> framePositions = new Dictionary<Panel, (int, int)>();

        public Container(int columns, int rows, Sprite frameSprite)
        {
            Columns = columns;
            Rows = rows;
            FrameSprite = frameSprite;

            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    Panel panel = new Panel();
                    AddChild(panel);
                    framePositions.Add(panel, (x, y));
                    panel.Width = FrameSprite.Width;
                    panel.Height = FrameSprite.Height;
                    panel.Position = new Vector2(x * FrameSprite.Width + ColumnMargin * x,
                                                 y * FrameSprite.Height + RowMargin * y);
                    Console.WriteLine(Position);
                    panel.OnClick += FrameClicked;
                    panel.AddChild(new Image(FrameSprite));
                    TextField text = new TextField("Assets/Fonts/Font");
                    text.Text.String = Children.Count.ToString();
                    panel.AddChild(text);
                }
            }
        }

        public int Columns { get; }
        public int Rows { get; }
        public int ColumnMargin { get; }
        public int RowMargin { get; }
        private Sprite FrameSprite { get; }

        public Action<int, int> OnFrameClicked;

        public override void Update(GameTime gameTime)
        {
            if (Input.KeyPressed(Keys.Escape))
            {
                for (int x = 0; x < Columns; x++)
                {
                    for (int y = 1; y < Rows; y++)
                    {
                        GetFrame(x, y).Enabled = !GetFrame(x, y).Enabled;
                    }
                }
            }
            base.Update(gameTime);
        }

        public Panel GetFrame(int x, int y)
        {
            return framePositions.FirstOrDefault(v => v.Value == (x, y)).Key;
        }
        private void FrameClicked(Panel panel)
        {
            OnFrameClicked?.Invoke(framePositions[panel].Item1, framePositions[panel].Item2);
        }
    }
}
