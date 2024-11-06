using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// ReSharper disable NotResolvedInText

namespace Inventories
{
    public sealed class Inventory : IEnumerable<Item>
    {
        private int width;
        private int height;
        private int count;
        
        private bool[,] grid;
        private KeyValuePair<Item, Vector2Int>[] items;
        
        public event Action<Item, Vector2Int> OnAdded;
        public event Action<Item, Vector2Int> OnRemoved;
        public event Action<Item, Vector2Int> OnMoved;
        public event Action OnCleared;

        public int Width => width;
        public int Height => height;
        public int Count => count;

        public Inventory(in int width, in int height)
        {
            ValidateSize(width, height);
            
            this.width = width;
            this.height = height;
            grid = new bool[width, height];
        }

        public Inventory(
            in int width,
            in int height,
            params KeyValuePair<Item, Vector2Int>[] items
        ) : this(width, height)
        {
            ValidateItems(items);
        }

        public Inventory(
            in int width,
            in int height,
            params Item[] items
        ) : this(width, height)
        {
            ValidateItems(items);
        }

        public Inventory(
            in int width,
            in int height,
            in IEnumerable<KeyValuePair<Item, Vector2Int>> items
        ) : this(width, height)
        {
            ValidateItems(items?.ToArray());
        }

        public Inventory(
            in int width,
            in int height,
            in IEnumerable<Item> items
        ) : this(width, height)
        {
            ValidateItems(items?.ToArray());
        }
        
        private static void ValidateItems<T>(T[] items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items), "Items array cannot be null.");
            }

            foreach (var item in items)
            {
                if (item is KeyValuePair<Item, Vector2Int> { Key: null } pair)
                {
                    throw new ArgumentNullException(nameof(pair.Key), "Item in the items array cannot be null.");
                }

                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item), "Item in the items array cannot be null.");
                }
            }
        }
        
        private static void ValidateSize(int width, int height)
        {
            if (width < 1 || height < 1)
                throw new ArgumentOutOfRangeException(width < 1 ? nameof(width) : nameof(height), 
                    "Width and height must be greater than zero.");
        }

        
        // private void FillGridWithValues(int width, int height)
        // {
        //     for (int x = 0; x < width; x++)
        //     {
        //         for (int y = 0; y < height; y++)
        //         {
        //             grid[x, y] = false;
        //         }
        //     }
        // }

        // private void PlaceItemInGrid(Item item, Vector2Int position)
        // {
        //     int endX = position.x + item.Size.x;
        //     int endY = position.y + item.Size.y;
        //
        //     for (int x = position.x; x < endX; x++)
        //     {
        //         for (int y = position.y; y < endY; y++)
        //         {
        //             grid[x, y] = true;
        //         }
        //     }
        // }

        /// <summary>
        /// Checks for adding an item on a specified position
        /// </summary>
        public bool CanAddItem(in Item item, in Vector2Int position)
            => throw new NotImplementedException();

        public bool CanAddItem(in Item item, in int posX, in int posY)
            => throw new NotImplementedException();

        /// <summary>
        /// Adds an item on a specified position if not exists
        /// </summary>
        public bool AddItem(in Item item, in Vector2Int position)
            => throw new NotImplementedException();

        public bool AddItem(in Item item, in int posX, in int posY)
            => throw new NotImplementedException();

        /// <summary>
        /// Checks for adding an item on a free position
        /// </summary>
        public bool CanAddItem(in Item item)
            => throw new NotImplementedException();

        /// <summary>
        /// Adds an item on a free position
        /// </summary>
        public bool AddItem(in Item item)
            => throw new NotImplementedException();

        /// <summary>
        /// Returns a free position for a specified item
        /// </summary>
        public bool FindFreePosition(in Vector2Int size, out Vector2Int freePosition)
            => throw new NotImplementedException();
        
        /// <summary>
        /// Checks if a specified item exists
        /// </summary>
        public bool Contains(in Item item)
            => throw new NotImplementedException();

        /// <summary>
        /// Checks if a specified position is occupied
        /// </summary>
        public bool IsOccupied(in Vector2Int position)
            => throw new NotImplementedException();

        public bool IsOccupied(in int x, in int y)
            => throw new NotImplementedException();

        /// <summary>
        /// Checks if a position is free
        /// </summary>
        public bool IsFree(in Vector2Int position)
            => throw new NotImplementedException();

        public bool IsFree(in int x, in int y)
        {
            return !grid[x, y];
        }

        /// <summary>
        /// Removes a specified item if exists
        /// </summary>
        public bool RemoveItem(in Item item)
            => throw new NotImplementedException();

        public bool RemoveItem(in Item item, out Vector2Int position)
            => throw new NotImplementedException();

        /// <summary>
        /// Returns an item at specified position 
        /// </summary>
        public Item GetItem(in Vector2Int position)
            => throw new NotImplementedException();

        public Item GetItem(in int x, in int y)
            => throw new NotImplementedException();

        public bool TryGetItem(in Vector2Int position, out Item item)
            => throw new NotImplementedException();

        public bool TryGetItem(in int x, in int y, out Item item)
            => throw new NotImplementedException();

        /// <summary>
        /// Returns matrix positions of a specified item 
        /// </summary>
        public Vector2Int[] GetPositions(in Item item)
            => throw new NotImplementedException();

        public bool TryGetPositions(in Item item, out Vector2Int[] positions)
            => throw new NotImplementedException();
        
        /// <summary>
        /// Clears all inventory items
        /// </summary>
        public void Clear()
            => throw new NotImplementedException();
        
        /// <summary>
        /// Returns a count of items with a specified name
        /// </summary>
        public int GetItemCount(string name)
            => throw new NotImplementedException();

        /// <summary>
        /// Moves a specified item to a target position if it exists
        /// </summary>
        public bool MoveItem(in Item item, in Vector2Int newPosition)
            => throw new NotImplementedException();
        
        /// <summary>
        /// Reorganizes inventory space to make the free area uniform
        /// </summary>
        public void ReorganizeSpace()
            => throw new NotImplementedException();

        /// <summary>
        /// Copies inventory items to a specified matrix
        /// </summary>
        public void CopyTo(in Item[,] matrix)
            => throw new NotImplementedException();

        public IEnumerator<Item> GetEnumerator()
            => throw new NotImplementedException();

        IEnumerator IEnumerable.GetEnumerator()
            => throw new NotImplementedException();
    }
}