using System.Collections.Generic;
using UnityEngine;

public class TransformPriorityQueue
{
    private class PriorityQueueItem
    {
        public Transform Item { get; set; }
        public int Priority { get; set; }

        public PriorityQueueItem(Transform item, int priority)
        {
            Item = item;
            Priority = priority;
        }
    }

    private List<PriorityQueueItem> items = new List<PriorityQueueItem>();

    public void Enqueue(Transform item, int priority)
    {
        items.Add(new PriorityQueueItem(item, priority));
        items.Sort((x, y) => x.Priority.CompareTo(y.Priority));
    }

    public void DecreasePriority(Transform item)
    {
        PriorityQueueItem queueItem = items.Find(x => x.Item == item);

        if (queueItem != null && queueItem.Priority != 0)
        {
            queueItem.Priority--;
            Debug.Log(queueItem.Priority);
            items.Sort((x, y) => x.Priority.CompareTo(y.Priority));
        }
    }

    public Transform Dequeue()
    {
        Transform item = items[0].Item;
        items.RemoveAt(0);
        return item;
    }

    public Transform Peek()
    {
        return items[0].Item;
    }

    public int Count()
    {
        return items.Count;
    }
}