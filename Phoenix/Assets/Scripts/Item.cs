using System;
using System.Collections.Generic;
using UnityEngine;

namespace ItemControl
{
    [CreateAssetMenu(fileName = "Item", menuName = "Item")]
    public class Item : ScriptableObject
    {
        public string Name;
        public WearArea WearArea;

        public float Weight;
        public Sprite Artwork;
        public List<ItemEffect> Effects { get; set; }
    }

    public struct ItemEffect
    {
        public string Name { get; set; }
        public Action EffectAction { get; set; }
    }
    public class WornPlace
    {
        public WearArea WearArea { get; set; }
        public Item Item { get; set; }
    }

    public class WornItems
    {
        public List<WornPlace> WornPlaces { get; set; }

        public WornPlace this[int i]
        {
            get { return WornPlaces[i]; }
        }

        public Item Wear(Item item)
        {
            foreach (WornPlace wornPlace in WornPlaces)
            {
                if (wornPlace.WearArea == item.WearArea)
                {
                    if (wornPlace.Item == null)
                    {
                        wornPlace.Item = item;
                        return null;
                    }
                    var temp = wornPlace.Item;
                    wornPlace.Item = item;
                    return temp;
                }
            }
            throw new ArgumentOutOfRangeException();
        }
    }

    public enum WearArea
    {
        Head,
        Chest,
        Hands,
        Legs,
        Feet
    }
}