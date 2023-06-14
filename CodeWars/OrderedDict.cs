using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars;

public class OrderedDict<TKey, TValue> : IDictionary<TKey, TValue>
    where TKey : notnull
{
    private readonly Dictionary<TKey, ValueTuple<long,TValue>> _valuesDict = new Dictionary<TKey, ValueTuple<long,TValue>>();
    private readonly Dictionary<long, TKey> _indexesDict = new Dictionary<long, TKey>();
    private long _currentIndex = 0;
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
        if (_valuesDict.TryGetValue(item.Key, out var value))
        {
            return value.Item2.Equals(item.Value);
        }

        return false;
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
        if (_valuesDict.TryGetValue(item.Key, out var value))
        {
            if (value.Item2.Equals(item.Value))
            {
                var key = item.Key;
                var index = _valuesDict[key];
                _valuesDict.Remove(key);
                _indexesDict.Remove(index.Item1);
                return true;
            }
        }
        return false;
    }

    public int Count => _valuesDict.Count;
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
        if (_valuesDict.TryGetValue(key, out var v1))
        {
            value = v1.Item2;
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
    public ICollection<TValue> Values => new ValCollection<TKey, TValue>(_valuesDict);
}

public class ValCollection<TKey, TValue> : ICollection<TValue>
{
    private readonly Dictionary<TKey, (long, TValue)> _valuesDict;

    public ValCollection(Dictionary<TKey, ValueTuple<long,TValue>> valuesDict)
    {
        _valuesDict = valuesDict;
    }

    public IEnumerator<TValue> GetEnumerator()
    {
        foreach (KeyValuePair<TKey,(long, TValue)> kvp in _valuesDict)
        {
            yield return kvp.Value.Item2;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(TValue item)
    {
        throw new NotImplementedException("Values are read only");
    }

    public void Clear()
    {
        throw new NotImplementedException("Values are read only");
    }

    public bool Contains(TValue item)
    {
        return _valuesDict.Any(w => w.Value.Item2.Equals(item)); // O(n) instead of O(1)
    }

    public void CopyTo(TValue[] array, int arrayIndex)
    {
        foreach (var kvp in _valuesDict)
        {
            array[arrayIndex++] = kvp.Value.Item2;
        }
    }

    public bool Remove(TValue item)
    {
        throw new NotImplementedException("Values are read only");
    }

    public int Count => _valuesDict.Count;
    public bool IsReadOnly => true;
}

