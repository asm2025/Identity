using System;
using essentialMix.Data.Model;
using Microsoft.AspNetCore.Identity;

namespace Identity.Model;

[Serializable]
public class RoleClaim<TKey> : IdentityRoleClaim<TKey>, IEntity<int>
	where TKey : IComparable<TKey>, IEquatable<TKey>
{
}