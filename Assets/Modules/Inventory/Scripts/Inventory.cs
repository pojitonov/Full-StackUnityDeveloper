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
        private Dictionary<Item, Vector2Int> _inventoryItems;
        private bool[,] _inventorySlots;

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
            AddItemsOnCreation(items);
        }

        public Inventory(in int width, in int height, params Item[] items
        ) : this(width, height)
        {
            AddItemsOnCreation(items);
        }

        public Inventory(in int width, in int height, in IEnumerable<KeyValuePair<Item, Vector2Int>> items
        ) : this(width, height)
        {
            AddItemsOnCreation(items);
        }

        public Inventory(in int width, in int height, in IEnumerable<Item> items
        ) : this(width, height)
        {
            AddItemsOnCreation(items);
        }

        public HashSet<Item> ToHashSet()
        {
            return _inventoryItems.Keys.ToHashSet();
        }

        private void InitializeInventory(in int width, in int height)
        {
            Width = width;
            Height = height;
            Count = 0;
            _inventorySlots = new bool[width, height];
            _inventoryItems = new();
        }

        private static void ValidateInventorySize(int width, int height)
        {
            if (width < 1 || height < 1)
                throw new ArgumentOutOfRangeException(width < 1 ? nameof(width) : nameof(height),
                    "Width and height must be greater than zero.");
        }

        private static void ValidateItemsForNull<T>(IEnumerable<T> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items), "Items array cannot be null.");
            }
        }


        /// <summary>
        /// Checks for adding an item on a specified position
        /// </summary>
        public bool CanAddItem(in Item item, in int x, in int y) => CanAddItem(item, new Vector2Int(x, y));

        public bool CanAddItem(Item item, Vector2Int position)
        {
            if (item == null) return false;
            if (Contains(item)) return false;
            if (OutOfBounds(item, position)) return false;
            if (IsOccupied(item, position)) return false;
            return true;
        }

        private bool OutOfBounds(Item item, Vector2Int position)
        {
            return position.x < 0 || position.y < 0 ||
                   position.x + item.Size.x > Width ||
                   position.y + item.Size.y > Height;
        }

        /// <summary>
        /// Checks for adding an item on a free position
        /// </summary>
        public bool CanAddItem(in Item item)
            => throw new NotImplementedException();


        /// <summary>
        /// Adds an item on a specified position if not exists
        /// </summary>
        public bool AddItem(in Item item, in int x, in int y) => AddItem(item, new Vector2Int(x, y));

        public bool AddItem(in Item item, in Vector2Int position)
        {
            if (!CanAddItem(item, position)) return false;
            _inventoryItems.Add(item, position);
            Count++;
            ManageItemSlots(item, position);
            OnAdded?.Invoke(item, position);
            return true;
        }


        /// <summary>
        /// Adds an item on a free position
        /// </summary>
        public bool AddItem(in Item item)
            => throw new NotImplementedException();

        private void AddItemsOnCreation(IEnumerable<KeyValuePair<Item, Vector2Int>> items)
        {
            ValidateItemsForNull(items);

            foreach (var item in items)
            {
                AddItem(item.Key, item.Value);
            }
        }

        private void AddItemsOnCreation(IEnumerable<Item> items)
        {
            ValidateItemsForNull(items);

            foreach (var item in items)
            {
                var position = Vector2Int.zero;
                AddItem(item, position);
            }
        }

        private void ManageItemSlots(Item item, Vector2Int position)
        {
            int endX = position.x + item.Size.x;
            int endY = position.y + item.Size.y;

            for (int x = position.x; x < endX; x++)
            {
                for (int y = position.y; y < endY; y++)
                {
                    _inventorySlots[x, y] = true;
                }
            }
        }


        /// <summary>
        /// Returns a free position for a specified item
        /// </summary>
        public bool FindFreePosition(in Vector2Int size, out Vector2Int freePosition)
        {
            if (size.x > Width || size.y > Height)
            {
                freePosition = Vector2Int.zero;
                return false;
            }

            for (int y = 0; y <= Height - size.y; y++)
            {
                for (int x = 0; x <= Width - size.x; x++)
                {
                    bool positionIsFree = true;
                    for (int i = 0; i < size.x && positionIsFree; i++)
                    {
                        for (int j = 0; j < size.y; j++)
                        {
                            if (!IsFree(x + i, y + j))
                            {
                                positionIsFree = false;
                                break;
                            }
                        }
                    }

                    if (positionIsFree)
                    {
                        freePosition = new Vector2Int(x, y);
                        return true;
                    }
                }
            }

            freePosition = Vector2Int.zero;
            return false;
        }


        /// <summary>
        /// Checks if a specified item exists
        /// </summary>
        public bool Contains(in Item item)
        {
            return item != null && _inventoryItems.ContainsKey(item);
        }


        /// <summary>
        /// Checks if a specified position is occupied
        /// </summary>
        public bool IsOccupied(in int x, in int y) => IsOccupied(new Vector2Int(x, y));

        public bool IsOccupied(in Vector2Int position)
        {
            return _inventorySlots[position.x, position.y];
        }

        private bool IsOccupied(Item item, Vector2Int position)
        {
            int endX = position.x + item.Size.x;
            int endY = position.y + item.Size.y;

            for (int posX = position.x; posX < endX; posX++)
            {
                for (int posY = position.y; posY < endY; posY++)
                {
                    if (_inventorySlots[posX, posY])
                        return true;
                }
            }

            return false;
        }


        /// <summary>
        /// Checks if a position is free
        /// </summary>
        public bool IsFree(in int x = 0, in int y = 0) => IsFree(new Vector2Int(x, y));

        private bool IsFree(in Vector2Int position)
        {
            return !_inventorySlots[position.x, position.y];
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