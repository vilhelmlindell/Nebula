using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nebula.Engine.GUI;
using Nebula.Engine.Graphics;

namespace Nebula.Engine.Components
{
    public class Inventory : Component
    {
        private ItemStack[] items;
        private ItemStack selectedItem;

        public Inventory(int columns, int rows, Sprite frameSprite)
        {
            items = new ItemStack[columns * rows];
            Container = new Container(columns, rows, frameSprite);
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    Panel panel = Container.GetFrame(x, y);
                    Container.AddChild(panel);
                    panel.AddChild(new TextField(Main.AssetManager.Load<SpriteFont>("Assets/Fonts/Font")));
                }
            }

            Container.OnFrameClicked += FrameClicked;
        }

        public Container Container { get; }

        public override void Update(GameTime gameTime)
        {
            if (Input.LeftMousePressed())
            {
                for (int i = 0; i < Container.Children.Count; i++)
                {
                    Panel panel = (Panel)Container.Children[i];
                    if (panel.AbsoluteBounds.Contains(Input.MousePosition) && items[i] != null)
                    {
                        selectedItem = items[i];
                    }
                }
            }
            if (Input.LeftMouseReleased() && selectedItem != null)
            {
                for (int i = 0; i < Container.Children.Count; i++)
                {
                    Panel panel = (Panel)Container.Children[i];
                    if (items[i].Item == null)
                    {
                        items[i] = selectedItem;
                        selectedItem = null;
                    }
                    else
                    {
                        ItemStack temp = items[i];
                        items[i] = selectedItem;
                        selectedItem = temp;
                    } 
                        
                }
            }
            base.Update(gameTime);
        }

        public void AddItem(ItemStack itemStack, int x, int y)
        {
            items[x * Container.Rows + y] = itemStack;
            Container.GetFrame(x, y).GetChild<TextField>().Text.String = itemStack.Count.ToString();
            itemStack.OnCountChanged += (int count) => Container.GetFrame(x, y).GetChild<TextField>().Text.String = count.ToString();
        }
        public void FrameClicked(int x, int y)
        {
        }
        public ItemStack GetItem(int x, int y)
        {
            return items[x / Container.Rows + y];
        }
    }
}

