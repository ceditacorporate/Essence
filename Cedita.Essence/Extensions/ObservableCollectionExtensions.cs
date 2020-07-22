// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PureSMS.Helpers
{
    public static class ObservableCollectionExtensions
    {
        public static ObservableCollection<T> ToObservable<T>(this List<T> collection) => new ObservableCollection<T>(collection as IEnumerable<T>);

        public static ObservableCollection<T> ToObservable<T>(this IList<T> collection) => new ObservableCollection<T>(collection);
    }
}
