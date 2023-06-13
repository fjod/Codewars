using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars;

public class OrderedDict<TKey, TValue> : IDictionary<TKey, TValue>
    where TKey : notnull
{
    private readonly Dictionary<TKey, ValueTuple<int,TValue>> _valuesDict = new Dictionary<TKey, ValueTuple<int,TValue>>();
    private readonly Dictionary<int, TKey> _indexesDict = new Dictionary<int, TKey>();
    private int _currentIndex = 0;
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        for (int i = 0; i < _currentIndex; i++)
        {
            if (_indexesDict.TryGetValue(i, out var key))
            {
                yield return new KeyValuePair<TKey, TValue>(key, _valuesDict[key].Item2);
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(KeyValuePair<TKey, TValue> item)
    {
        _valuesDict.Add(item.Key, (_currentIndex, item.Value));
        _indexesDict.Add(_currentIndex, item.Key);
        _currentIndex ++;
    }

    public void Clear()
    {
        _valuesDict.Clear();
        _indexesDict.Clear();
        _currentIndex = 0;
    }

    public bool Contains(KeyValuePair<TKey, TValue> item)
    {
       return _valuesDict.ContainsKey(item.Key);
    }

    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
        for (int i = 0; i < _currentIndex; i++)
        {
            array[arrayIndex++] = new KeyValuePair<TKey, TValue>(_indexesDict[i], _valuesDict[_indexesDict[i]].Item2);
        }
    }

    public bool Remove(KeyValuePair<TKey, TValue> item)
    {
        if (_valuesDict.ContainsKey(item.Key))
        {
            var key = item.Key;
            var index = _valuesDict[key];
            _valuesDict.Remove(key);
            _indexesDict.Remove(index.Item1);
            return true;
        }

        return false;
    }

    public int Count => _currentIndex;
    public bool IsReadOnly => false;
    public void Add(TKey key, TValue value)
    {
        _valuesDict.Add(key, (_currentIndex, value));
        _indexesDict.Add(_currentIndex,key);
        _currentIndex ++;
    }

    public bool ContainsKey(TKey key)
    {
        return _valuesDict.ContainsKey(key);
    }

    public bool Remove(TKey key)
    {
        if (_valuesDict.ContainsKey(key))
        {
            var index = _valuesDict[key];
            _valuesDict.Remove(key);
            _indexesDict.Remove(index.Item1);
            return true;
        }

        return false;
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        if (_valuesDict.ContainsKey(key))
        {
            value = _valuesDict[key].Item2;
            return true;
        }

        value = default;
        return false;
    }

    public TValue this[TKey key]
    {
        get => _valuesDict[key].Item2;
        set => Set(key, value);
    }

    private void Set(TKey key, TValue value)
    {
        var prev = _valuesDict[key];
        prev.Item2 = value;
        _valuesDict[key] = (prev.Item1, value);
    }

    public ICollection<TKey> Keys => _valuesDict.Keys;
    public ICollection<TValue> Values => _valuesDict.Values.Select(v => v.Item2).ToList();
}