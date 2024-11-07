using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// ReSharper disable NotResolvedInText

namespace Inventories
{
    public sealed class Inventory : IEnumerable<Item>
    {
        private bool[,] grid;
        private Dictionary<Item, Vector2Int> inventory;

        public event Action<Item, Vector2Int> OnAdded;
        public event Action<Item, Vector2Int> OnRemoved;
        public event Action<Item, Vector2Int> OnMoved;
        public event Action OnCleared;

        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Count { get; private set; }

        public Inventory(in int width, in int height)
        {
            ValidateInventorySize(width, height);
            InitializeInventory(width, height);
        }

        public Inventory(in int width, in int height, params KeyValuePair<Item, Vector2Int>[] items
        ) : this(width, height)
        {
            ValidateItemsForNull(items);
            AddItemsToInventory(items);
        }

        public Inventory(in int width, in int height, params Item[] items
        ) : this(width, height)
        {
            ValidateItemsForNull(items);
            AddItemsToInventory(items);
        }

        public Inventory(in int width, in int height, in IEnumerable<KeyValuePair<Item, Vector2Int>> items
        ) : this(width, height)
        {
            ValidateItemsForNull(items);
            AddItemsToInventory(items);
        }

        public Inventory(in int width, in int height, in IEnumerable<Item> items
        ) : this(width, height)
        {
            ValidateItemsForNull(items);
            AddItemsToInventory(items);
        }

        /// <summary>
        /// Checks for adding an item on a specified position
        /// </summary>
        public bool CanAddItem(Item item, Vector2Int position)
        {
            if (item == null)
                return false;

            if (Contains(item))
                return false;

            int endX = position.x + item.Size.x;
            int endY = position.y + item.Size.y;

            for (int x = position.x; x < endX; x++)
            {
                for (int y = position.y; y < endY; y++)
                {
                    if (grid[x, y])
                        return false;
                }
            }

            return true;
        }

        public bool CanAddItem(in Item item, in int x, in int y) => CanAddItem(item, new Vector2Int(x, y));

        /// <summary>
        /// Checks if a specified position is occupied
        /// </summary>
        private static void ValidateInventorySize(int width, int height)
        {
            if (width < 1 || height < 1)
                throw new ArgumentOutOfRangeException(width < 1 ? nameof(width) : nameof(height),
                    "Width and height must be greater than zero.");
        }

        private void InitializeInventory(in int width, in int height)
        {
            Width = width;
            Height = height;
            Count = 0;
            grid = new bool[width, height];
            inventory = new();
        }

        private static void ValidateItemsForNull<T>(IEnumerable<T> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items), "Items array cannot be null.");
            }
        }

        private void AddItemsToInventory(IEnumerable<KeyValuePair<Item, Vector2Int>> items)
        {
            foreach (var item in items)
            {
                AddSingleItemToGrid(item.Key, item.Value);
                AddSingleItemToInventory(item);
            }
        }

        private void AddItemsToInventory(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                var position = Vector2Int.zero;
                AddSingleItemToGrid(item, position);
                AddSingleItemToInventory(new KeyValuePair<Item, Vector2Int>(item, position));
            }
        }

        private void AddSingleItemToInventory(KeyValuePair<Item, Vector2Int> item)
        {
            inventory.Add(item.Key, item.Value);
            Count++;
        }

        private void AddSingleItemToGrid(Item item, Vector2Int position)
        {
            int endX = position.x + item.Size.x;
            int endY = position.y + item.Size.y;

            for (int x = position.x; x < endX; x++)
            {
                for (int y = position.y; y < endY; y++)
                {
                    grid[x, y] = true;
                }
            }
        }

        private bool CheckIsOutOfInventoryBoundary(Item item, Vector2Int position)
        {
            int endX = position.x + item.Size.x;
            int endY = position.y + item.Size.y;

            if (endX > grid.GetLength(0) || endY > grid.GetLength(1))
                return false;

            return true;
        }

        private void PrintGridState(string title)
        {
            Debug.Log(title);
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                string row = "";

                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    row += grid[x, y] ? "1 " : "0 ";
                }

                Debug.Log(row);
            }

            Debug.Log("----------------------------------------");
        }

        /// <summary>
        /// Adds an item on a specified position if not exists
        /// </summary>
        public bool AddItem(in Item item, in Vector2Int position)
        {
            var newItem = new KeyValuePair<Item, Vector2Int>(item, position);
            AddSingleItemToInventory(newItem);
            OnAdded?.Invoke(item, position);
            return true;
        }

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
        public bool Contains(in Item item) => inventory.ContainsKey(item);

        public bool IsOccupied(in Vector2Int position)
        {
            for (int posX = position.x; posX < grid.GetLength(0); posX++)
            {
                for (int posY = position.y; posY < grid.GetLength(1); posY++)
                {
                    if (grid[posX, posY])
                        return false;
                }
            }

            return true;
        }

        public bool IsOccupied(in int x, in int y) => IsOccupied(new Vector2Int(x, y));


        /// <summary>
        /// Checks if a position is free
        /// </summary>
        public bool IsFree(in int x = 0, in int y = 0) => IsFree(new Vector2Int(x, y));

        private bool IsFree(in Vector2Int position)
        {
            for (int i = position.x; i < grid.GetLength(0); i++)
            {
                for (int j = position.y; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j]) return false;
                }
            }

            return true;
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