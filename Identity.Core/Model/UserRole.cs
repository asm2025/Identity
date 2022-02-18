using System;
using System.Diagnostics;
using essentialMix.Data.Model;
using Microsoft.AspNetCore.Identity;

namespace Identity.Core.Model;

[DebuggerDisplay("User: {UserId} - Role: {RoleId}")]
[Serializable]
public class UserRole<TKey> : IdentityUserRole<TKey>, IEntity
	where TKey : IComparable<TKey>, IEquatable<TKey>
{
	public virtual User<TKey> User { get; set; }
	public virtual Role<TKey> Role { get; set; }
}