using System;
using essentialMix.Data.Model;
using Microsoft.AspNetCore.Identity;

namespace Identity.Model;

[Serializable]
public class UserClaim<TKey> : IdentityUserClaim<TKey>, IEntity<int>
	where TKey : IComparable<TKey>, IEquatable<TKey>
{
}