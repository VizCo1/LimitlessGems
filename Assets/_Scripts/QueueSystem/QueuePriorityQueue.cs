using System.Collections.Generic;
using UnityEngine;

public class QueuePriorityQueue
{
    private class PriorityQueueItem
    {
        public CustomQueue Item { get; set; }
        public int Priority { get; set; }

        public PriorityQueueItem(CustomQueue item, int priority)
        {
            Item = item;
            Priority = priority;
        }
    }

    private readonly List<PriorityQueueItem> items = new();

    public void Enqueue(CustomQueue item, int priority)
    {
        items.Add(new PriorityQueueItem(item, priority));
        items.Sort((x, y) => x.Priority.CompareTo(y.Priority));
    }

    public void DecreasePriority(CustomQueue item)
    {
        PriorityQueueItem queueItem = items.Find(x => x.Item == item);

        if (queueItem != null && queueItem.Priority != 0)
        {
            queueItem.Priority--;
            //Debug.Log(queueItem.Priority);
            items.Sort((x, y) => x.Priority.CompareTo(y.Priority));
        }
    }

    public void IncreasePriority(CustomQueue item)
    {
        PriorityQueueItem queueItem = items.Find(x => x.Item == item);

        if (queueItem != null)
        {
            queueItem.Priority++;
            //Debug.Log(queueItem.Priority);
            items.Sort((x, y) => x.Priority.CompareTo(y.Priority));
        }
    }

    public CustomQueue Dequeue()
    {
        CustomQueue item = items[0].Item;
        items.RemoveAt(0);
        return item;
    }

    public CustomQueue Peek()
    {
        return items[0].Item;
    }

    public int Count()
    {
        return items.Count;
    }
}