using System.Collections;

namespace Cartesian_Product
{
	public static class Cartesian
	{
		public static IEnumerable<IEnumerable<T>> Product<T>(IEnumerable<IEnumerable<T>> items)
		{
			var slots = items
			// initialize enumerators
			.Select(x => x.GetResetableEnumerator())
			// get only those that could start in case there is an empty collection
			.Where(x => x.MoveNext())
			.ToArray();

			if (slots.Length == 0)
				yield break;

			while (true)
			{
				// yield current values
				yield return slots.Select(x => x.Current);

				// increase enumerators
				foreach (var slot in slots)
				{
					// reset the slot if it couldn't move next
					if (!slot.MoveNext())
					{
						// stop when the last enumerator resets
						if (slot == slots.Last()) { yield break; }
						slot.Reset();
						slot.MoveNext();
						// move to the next enumerator if this reseted
						continue;
					}
					// we could increase the current enumerator without reset so stop here
					break;
				}
			}
		}

		public static IEnumerable<IEnumerable<T>> Product<T>(params IEnumerable<T>[] items)
		{
			return Product(items);
		}
	}

	internal static class ResetabeIEnumerableExtentionMethod
	{
		public static ResetableEnumerator<T> GetResetableEnumerator<T>(this IEnumerable<T> collection)
		{
			return new ResetableEnumerator<T>(collection);
		}

		internal class ResetableEnumerator<U> : IEnumerator<U>
		{
			readonly IEnumerable<U> _collection;
			IEnumerator<U> _originalEnumerator;
			public ResetableEnumerator(IEnumerable<U> collection)
			{
				_collection = collection;
				_originalEnumerator = _collection.GetEnumerator();
			}

			public U Current => _originalEnumerator.Current;
			object IEnumerator.Current => _originalEnumerator.Current;
			public bool MoveNext() => _originalEnumerator.MoveNext();
			public void Reset()
			{
				_originalEnumerator = _collection.GetEnumerator();
			}

			public bool ResetAndMoveNext()
			{
				Reset();
				return MoveNext();
			}

			public void Dispose()
			{ }
		}
	}
}