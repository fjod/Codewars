using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;

namespace CodeWars;

public class OrderedDict<TKey, TValue> : IDictionary<TKey, TValue>
{
    private readonly Dictionary<TKey, TValue> _valuesDict = new Dictionary<TKey, TValue>();
    private readonly Dictionary<int, TKey> _indexesDict = new Dictionary<int, TKey>();
    private readonly Dictionary<TKey, int> _indexesReverseDict = new Dictionary<TKey, int>();
    private int _currentIndex = 0;
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        for (int i = 0; i < _currentIndex; i++)
        {
            if (_indexesDict.TryGetValue(i, out var key))
            {
                yield return new KeyValuePair<TKey, TValue>(key, _valuesDict[key]);
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(KeyValuePair<TKey, TValue> item)
    {
        _valuesDict.Add(item.Key, item.Value);
        _indexesDict.Add(_currentIndex, item.Key);
        _indexesReverseDict.Add(item.Key, _currentIndex);
        _currentIndex ++;
    }

    public void Clear()
    {
        _valuesDict.Clear();
        _indexesDict.Clear();
        _indexesReverseDict.Clear();
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
            array[arrayIndex++] = new KeyValuePair<TKey, TValue>(_indexesDict[i], _valuesDict[_indexesDict[i]]);
        }
    }

    public bool Remove(KeyValuePair<TKey, TValue> item)
    {
        if (_valuesDict.ContainsKey(item.Key))
        {
            var key = item.Key;
            _valuesDict.Remove(key);
            var index = _indexesReverseDict[key];
            _indexesReverseDict.Remove(key);
            _indexesDict.Remove(index);
            return true;
        }

        return false;
    }

    public int Count => _currentIndex;
    public bool IsReadOnly => false;
    public void Add(TKey key, TValue value)
    {
        _valuesDict.Add(key, value);
        _indexesDict.Add(_currentIndex,key);
        _indexesReverseDict.Add(key, _currentIndex);
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
            _valuesDict.Remove(key);
            var index = _indexesReverseDict[key];
            _indexesReverseDict.Remove(key);
            _indexesDict.Remove(index);
            return true;
        }

        return false;
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        if (_valuesDict.ContainsKey(key))
        {
            value = _valuesDict[key];
            return true;
        }

        value = default;
        return false;
    }

    public TValue this[TKey key]
    {
        get => _valuesDict[key];
        set => _valuesDict[key] = value;
    }

    public ICollection<TKey> Keys => _valuesDict.Keys;
    public ICollection<TValue> Values => _valuesDict.Values;
}