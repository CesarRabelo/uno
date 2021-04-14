using System;
using System.Collections.Generic;
using Windows.Foundation.Collections;
using Uno.Extensions.Specialized;

namespace Windows.UI.Xaml.Controls
{
	public partial class RowDefinitionCollection : DefinitionCollectionBase, IList<RowDefinition>, IEnumerable<RowDefinition>
	{
		private readonly DependencyObjectCollection<RowDefinition> _inner = new DependencyObjectCollection<RowDefinition>();

		internal event VectorChangedEventHandler<RowDefinition> CollectionChanged;

		public RowDefinitionCollection()
		{
			_inner.VectorChanged += (s, e) => CollectionChanged?.Invoke(s, e);
		}

		internal RowDefinitionCollection(DependencyObject owner) : this()
		{
			_inner.IsAutoPropertyInheritanceEnabled = false;
			_inner.SetParent(owner);
		}

		public int IndexOf(RowDefinition item) => _inner.IndexOf(item);

		public void Insert(int index, RowDefinition item)
		{
			_inner.Insert(index, item);
			(item as DefinitionBase).Changed += OnDefinitionChanged;
		}

		public void RemoveAt(int index)
		{
			(_inner[index] as DefinitionBase).Changed -= OnDefinitionChanged;
			_inner.RemoveAt(index);
		}

		IEnumerable<DefinitionBase> DefinitionCollectionBase.GetItems() => _inner;

		DefinitionBase DefinitionCollectionBase.GetItem(int index) => _inner[index];

		public RowDefinition this[int index]
		{
			get => _inner[index];
			set
			{
				if(_inner[index] != value)
				{
					(_inner[index] as DefinitionBase).Changed -= OnDefinitionChanged;
					(value as DefinitionBase).Changed += OnDefinitionChanged;
					_inner[index] = value;
				}
			}
		}

		public void Add(RowDefinition item)
		{
			_inner.Add(item);
			(item as DefinitionBase).Changed += OnDefinitionChanged;
		}

		public void Clear()
		{
			_inner.ForEach(item=> (item as DefinitionBase).Changed -= OnDefinitionChanged);
			_inner.Clear();
		}

		public bool Contains(RowDefinition item) => _inner.Contains(item);

		public void CopyTo(RowDefinition[] array, int arrayIndex) => _inner.CopyTo(array, arrayIndex);

		public bool Remove(RowDefinition item)
		{
			(item as DefinitionBase).Changed -= OnDefinitionChanged;
			return _inner.Remove(item);
		}

		public int Count => _inner.Count;

		public bool IsReadOnly => false;

		/// <summary>
		/// The inner list is exposed in order to get the struct enumerable exposed by <see cref="List{T}"/> to avoid allocations.
		/// </summary>
		internal List<RowDefinition> InnerList => _inner.Items;

		public global::System.Collections.Generic.IEnumerator<RowDefinition> GetEnumerator() => _inner.GetEnumerator();

		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator() => _inner.GetEnumerator();

		void DefinitionCollectionBase.Lock() => _inner.Lock();

		void DefinitionCollectionBase.Unlock() => _inner.Unlock();

		private void OnDefinitionChanged(object sender, EventArgs e)
		{
			// The event is not important, since the listener will only react to the event itself, not the args
			CollectionChanged?.Invoke(_inner, new VectorChangedEventArgs(CollectionChange.ItemChanged, 0));
		}
	}
}
