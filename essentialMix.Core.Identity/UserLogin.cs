using System;
using essentialMix.Data.Model;
using Microsoft.AspNetCore.Identity;

namespace Identity.Model;

[Serializable]
public class UserLogin<TKey> : IdentityUserLogin<TKey>, IEntity
	where TKey : IComparable<TKey>, IEquatable<TKey>
{
}