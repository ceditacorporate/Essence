// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System.Collections.Generic;
using System.Linq;

namespace Cedita.Essence.Extensions
{
    public class NameValueCollectionExtensions : List<KeyValuePair<string, string>>
    {
        public new string this[int index] => base[index].Value;
        public string this[string name] => this.SingleOrDefault(kv => kv.Key.Equals(name)).Value;

        public void Add(string name, string value)
        {
            List<KeyValuePair<string, string>> list = this;
            for (int i = Count - 1; i >= 0; --i)
            {
                if (string.Equals(list[i].Key, name))
                {
                    list[i] = new KeyValuePair<string, string>(name, list[i].Value + "," + value);
                    return;
                }
            }
            Add(new KeyValuePair<string, string>(name, value));
        }

        public IEnumerable<string> AllKeys => this.Select(pair => pair.Key);

    }
}
