namespace Sdde.Collections.Generic;

public abstract class HashTableBase
{
    protected int Size { get; set; }
    protected int Count { get; set; } = 0;
  
    public double LoadFactor => (double) Count / Size;
  
    public abstract void Add(string key, string value);
  
    public abstract void Delete(string key);
  
    public abstract string Lookup(string key);

    public int Hash(string key){
        return key.ToCharArray().Sum(c => (int)c);
    }
  
    public int Index(int val){
        return val % Size;
    }
}